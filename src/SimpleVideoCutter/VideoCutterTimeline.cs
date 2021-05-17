using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleVideoCutter.Properties;

namespace SimpleVideoCutter
{
    public partial class VideoCutterTimeline : UserControl
    {
        public event EventHandler<TimelineHoverEventArgs> TimelineHover;
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;
        public event EventHandler<PositionChangeRequestEventArgs> PositionChangeRequest;

        private Brush brushBackground = new SolidBrush(Color.FromArgb(0x4C, 0x4C, 0x4C));
        private Brush brushBackgroundInfoArea = new SolidBrush(Color.FromArgb(0x5C, 0x5C, 0x5C));
        private Brush brushBackgroundInfoAreaOffset = new SolidBrush(Color.FromArgb(0x6B, 0x6B, 0x6B));
        private Brush brushBackgroundSelected = new SolidBrush(Color.FromArgb(0xAD, 0xAD, 0xAD));
        private Pen penTickSeconds = new Pen(Color.SlateGray);
        private Pen penTickMinute = new Pen(Color.Silver);
        private Brush brushHoverPosition = new SolidBrush(Color.FromArgb(0xC8, 0x17, 0x17));
        private Brush brushSelectionMarker = new SolidBrush(Color.FromArgb(0xFF, 0xE9, 0x7F));
        private Brush brushPosition = new SolidBrush(Color.FromArgb(0x00, 0x5C, 0x9E));

        private PositionMoveController selectionStartMoveController;
        private PositionMoveController selectionEndMoveController;

        private long position = 0;
        private long? hoverPosition = null;
        private long? selectionStart = null;
        private long? selectionEnd = null;

        private float scale = 1.0f;
        private long offset = 0;

        private long length = 0;

        public long Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
                offset = 0;
                scale = 1.0f;
                Refresh();
            }
        }
        
        public long Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;

                if (PositionToPixel(position) > ClientRectangle.Width)
                {
                    var newOffset = position;
                    if (newOffset + ClientRectangle.Width * MillisecondsPerPixels() > Length)
                        newOffset = Length - (long)(ClientRectangle.Width * MillisecondsPerPixels());
                    offset = newOffset;
                    EnsureOffsetInBounds();
                }

                Refresh();
            }
        }

        public long? HoverPosition
        {
            get
            {
                return hoverPosition;
            }
            set
            {
                if (hoverPosition == value)
                    return; 

                hoverPosition = value;
                Invalidate();
                TimelineHover?.Invoke(this, new TimelineHoverEventArgs());
            }
        }

        public long? SelectionStart
        {
            get { return selectionStart; }
        }
        public long? SelectionEnd
        {
            get { return selectionEnd; }
        }

        public VideoCutterTimeline()
        {
            InitializeComponent();
            selectionStartMoveController = new SelectionStartMoveController(this);
            selectionEndMoveController = new SelectionEndMoveController(this);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            var delta = e.Delta * (ModifierKeys.HasFlag(Keys.Shift) ? 10 : 1);
            var hoveredPosition = HoverPosition;

            HoverPosition = null;

            if (ModifierKeys.HasFlag(Keys.Control))
            {
                float newScale = scale + (delta / SystemInformation.MouseWheelScrollDelta * 0.25f);

                if (newScale < 1)
                    newScale = 1;

                if (newScale > scale)
                {
                    var zoomCenter = ClientRectangle.Width / 2.0f;
                    
                    if (hoveredPosition != null)
                        zoomCenter = PositionToPixel(hoveredPosition);

                    var currPosZoomCenter = PixelToPosition(zoomCenter);
                    var newPosZoomCenter = PixelToPosition(zoomCenter, newScale);

                    offset = offset + (currPosZoomCenter - newPosZoomCenter);
                    offset = Math.Max(offset, 0);
                }
                else if (newScale < scale)
                {
                    var zoomCenter = ClientRectangle.Width / 2.0f;

                    if (hoveredPosition != null)
                        zoomCenter = PositionToPixel(hoveredPosition);

                    var currPosZoomCenter = PixelToPosition(zoomCenter);
                    var newPosZoomCenter = PixelToPosition(zoomCenter, newScale);

                    offset = offset + (currPosZoomCenter - newPosZoomCenter);
                    offset = Math.Max(offset, 0);
                }

                scale = newScale;
            }
            else
            {
                var step = (ClientRectangle.Width * MillisecondsPerPixels()) / 10.0f;
                
                long newOffset = offset - (int)(delta / SystemInformation.MouseWheelScrollDelta * step);

                newOffset = Math.Max(newOffset, 0);

                this.offset = newOffset;
            }

            EnsureOffsetInBounds();

            Refresh();

        }

        private void EnsureOffsetInBounds()
        {
            if (offset + ClientRectangle.Width * MillisecondsPerPixels() > Length)
                offset = Length - (long)(ClientRectangle.Width * MillisecondsPerPixels());

            offset = Math.Max(offset, 0);
        }

        private void VideoCutterTimeline_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(brushBackground, ClientRectangle);

            TimelineTooltip timelineTooltip = null;

            var infoAreaHeight = 30;
            var infoAreaRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, infoAreaHeight);



            e.Graphics.FillRectangle(brushBackgroundInfoArea, infoAreaRect);

            if (Length != 0)
            {
                var pixelStart = ((float)offset / Length) * ClientRectangle.Width;
                var pixelEnd = ((float)PixelToPosition(ClientRectangle.Width)/Length) * ClientRectangle.Width;
                e.Graphics.FillRectangle(brushBackgroundInfoAreaOffset, pixelStart, 0, pixelEnd - pixelStart, infoAreaHeight);
            }

            if (Length != 0)
            {
                var time = TimeSpan.FromMilliseconds(Position);

                var text = string.Format($"{GlobalStrings.VideoCutterTimeline_Time}: {time:hh\\:mm\\:ss\\:fff} ");

                if (HoverPosition != null)
                {
                    var hoverTime = TimeSpan.FromMilliseconds(HoverPosition.Value);
                    text = text + string.Format($" {GlobalStrings.VideoCutterTimeline_HoveredTime}: {hoverTime:hh\\:mm\\:ss\\:fff} ");
                }
                PaintStringInBox(e.Graphics, null, Brushes.LightGray, text, infoAreaRect, 10);
            }


            e.Graphics.TranslateTransform(0, infoAreaHeight);

            int timeLineHeight = ClientRectangle.Height - infoAreaHeight;

            if (SelectionStart != null && SelectionEnd != null)
            {
                var pixelsStart = PositionToPixel((long?)SelectionStart.Value);
                var pixelsEnd = PositionToPixel((long?)SelectionEnd.Value);
                var selectionRect = new Rectangle(pixelsStart, 0, pixelsEnd - pixelsStart, timeLineHeight);
                e.Graphics.FillRectangle(brushBackgroundSelected, selectionRect);
            }

            if (Length != 0)
            {
                float pixelsPerSecond = PixelsPerMilliseconds() * 1000.0f; 

                for (long position = 0; position <= Length; position += 1000)
                {
                    var time = TimeSpan.FromMilliseconds(position);

                    var posXPixel = (position - offset) * PixelsPerMilliseconds();

                    if (posXPixel >= -ClientRectangle.Width && posXPixel <= ClientRectangle.Width)
                    {
                        e.Graphics.DrawLine(penTickSeconds, (int)posXPixel, 3 * (timeLineHeight / 4), (int)posXPixel, timeLineHeight);
                            
                        if (time.Seconds == 0)
                            e.Graphics.DrawLine(penTickMinute, (int)posXPixel, timeLineHeight / 2, (int)posXPixel, timeLineHeight);

                        string text;

                        if (time.TotalHours > 1)
                            text = string.Format($"{time:hh\\:mm\\:ss}");
                        else 
                            text = string.Format($"{time:mm\\:ss}");

                        var size = e.Graphics.MeasureString(text, this.Font);

                        if (pixelsPerSecond > size.Width + 5)
                        {
                            var rect = new Rectangle((int)posXPixel, (int)(timeLineHeight - size.Height), 100, 15);
                            e.Graphics.DrawString(text, this.Font, penTickSeconds.Brush, rect, StringFormat.GenericDefault);
                        }
                    }

                }




                if (SelectionStart != null)
                {
                    var pixel = PositionToPixel(SelectionStart.Value);
                    e.Graphics.FillRectangle(brushSelectionMarker, pixel, 0, 2, timeLineHeight);
                    PaintUpperHalfTriangle(e.Graphics, brushSelectionMarker, pixel, 8, 8, true);
                    PaintBottomHalfTriangle(e.Graphics, brushSelectionMarker, pixel, 8, 8, true, timeLineHeight);
                }
                if (SelectionEnd != null)
                {
                    var pixel = PositionToPixel(SelectionEnd.Value);
                    e.Graphics.FillRectangle(brushSelectionMarker, pixel, 0, 2, timeLineHeight);
                    PaintUpperHalfTriangle(e.Graphics, brushSelectionMarker, pixel, 8, 8, false);
                    PaintBottomHalfTriangle(e.Graphics, brushSelectionMarker, pixel, 8, 8, false, timeLineHeight);
                }

                var positionPixel = PositionToPixel(Position);
                PaintTriangle(e.Graphics, brushPosition, positionPixel+1, 8, 8);
                e.Graphics.FillRectangle(brushPosition, positionPixel, 0, 2, timeLineHeight);



                if (HoverPosition != null)
                {
                    var pixel = PositionToPixel(HoverPosition);

                    if (selectionStartMoveController.IsDragStartPossible(pixel) || selectionStartMoveController.IsDragInProgress())
                    {
                        timelineTooltip = new TimelineTooltip() { X = pixel, Text = GlobalStrings.VideoCutterTimeline_MoveClipStart };
                    }
                    if (selectionEndMoveController.IsDragStartPossible(pixel) || selectionEndMoveController.IsDragInProgress())
                    {
                        timelineTooltip = new TimelineTooltip() { X = pixel, Text = GlobalStrings.VideoCutterTimeline_MoveClipEnd };
                    }

                    e.Graphics.FillRectangle(brushHoverPosition, pixel, 0, 2, timeLineHeight);
                    PaintTriangle(e.Graphics, brushHoverPosition, PositionToPixel(HoverPosition)+1, 8, 8);
                    
                    string tooltipSetClipOverrideText = null;
                    if (ModifierKeys == Keys.Shift)
                        tooltipSetClipOverrideText = GlobalStrings.VideoCutterTimeline_SetClipFromHereTillEnd;
                    else if (ModifierKeys == Keys.Control)
                        tooltipSetClipOverrideText = GlobalStrings.VideoCutterTimeline_SetClipFromStartTillHere;

                    if (SelectionStart == null)
                    {
                        timelineTooltip = new TimelineTooltip() { X = pixel, Text = tooltipSetClipOverrideText ?? GlobalStrings.VideoCutterTimeline_SetClipStartHere };
                    }
                    else if (SelectionEnd == null && HoverPosition.Value > SelectionStart.Value)
                    {
                        timelineTooltip = new TimelineTooltip() { X = pixel, Text = tooltipSetClipOverrideText ?? GlobalStrings.VideoCutterTimeline_SetClipEndHere };
                    }
                }


                e.Graphics.ResetTransform();


                if (timelineTooltip != null)
                {
                    PaintStringInBox(e.Graphics, Brushes.LightYellow, Brushes.Gray, timelineTooltip.Text, infoAreaRect, timelineTooltip.X);
                }

            }
        }

        private void PaintStringInBox(Graphics gr, Brush background, Brush textBrush, string str, Rectangle parentRectangle, int location)
        {
            var font = this.Font;
            var strSize = gr.MeasureString(str, font);

            var tmpRect = new RectangleF(location, 0f, strSize.Width, strSize.Height);
            tmpRect.Inflate(2, 2);

            var rect = new RectangleF(Math.Max(0, tmpRect.X - tmpRect.Width / 2.0f), tmpRect.Y + (parentRectangle.Height - strSize.Height)/2.0f, tmpRect.Width, tmpRect.Height);
            if (background != null)
                gr.FillRectangle(background, rect);
            
            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            gr.DrawString(str, font, textBrush, rect, stringFormat);
        }

        private void PaintTriangle(Graphics gr, Brush brush, int location, int width, int height)
        {
            gr.FillPolygon(brush, new PointF[]
            {
                new PointF(location - width/2.0f, 0),
                new PointF(location + width/2.0f, 0),
                new PointF(location, height)
            });
        }


        private void PaintUpperHalfTriangle(Graphics gr, Brush brush, int location, int width, int height, bool forward)
        {
            gr.FillPolygon(brush, new PointF[]
            {
                new PointF(location, 0),
                new PointF(forward ? location + width : location-width, 0),
                new PointF(location, height)
            });
        }

        private void PaintBottomHalfTriangle(Graphics gr, Brush brush, int location, int width, int height, bool forward, int offsetY)
        {
            gr.FillPolygon(brush, new PointF[]
            {
                new PointF(location, offsetY),
                new PointF(forward ? location + width : location-width, offsetY),
                new PointF(location, offsetY-height)
            });
        }

        private float PixelsPerMilliseconds(float? givenScale = null)
        {
            
            return ((float)ClientRectangle.Width / Length) * (givenScale ?? scale);
        }
        private float MillisecondsPerPixels(float? givenScale = null)
        {
            return ((float)Length / ClientRectangle.Width) / (givenScale ?? scale);
        }


        public int PositionToPixel(long? position, float? givenScale = null)
        {
            if (position == null)
                return 0;

            if (Length == 0)
                return 0;

            return (int)((position.Value - offset) * PixelsPerMilliseconds(givenScale));
        }

        public long PixelToPosition(float x, float? givenScale = null)
        {
            if (Length == 0)
                return 0;

            long pos = (long)(offset + x * MillisecondsPerPixels(givenScale));

            // Do not allow negative starting position
            if (pos < 0) {
                pos = 0;
            }
            // Do not exceed total video length
            if (pos > Length) {
                pos = Length;
            }
            
            return pos;
        }

        public void ZoomOut()
        {
            scale = 1.0f;
            offset = 0;

            this.InvokeIfRequired(() => {
                Refresh();
            });
        }

        public void ZoomAuto()
        {

            offset = 0;
            scale = 1.0f;
            if (Length != 0)
            {
                var desiredPixelsPerMs = 50 / 1000.0f;
                var fullPixelsPerMs = (float)ClientRectangle.Width / length;
                scale = desiredPixelsPerMs / fullPixelsPerMs;
                scale = Math.Max(scale, 1);
                GoToCurrentPosition();
            }

            this.InvokeIfRequired(() => {
                Refresh();
            });
        }
        
        public void GoToCurrentPosition()
        {
            GoToPosition(Position);
        }

        public void GoToPosition(long position)
        {
            if (Length > 0)
            {
                offset = position - (long)MillisecondsPerPixels() * (ClientSize.Width / 2);
                EnsureOffsetInBounds();
            }

            this.InvokeIfRequired(() => {
                Refresh();
            });
        }

        private void VideoCutterTimeline_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }


        private void VideoCutterTimeline_MouseMove(object sender, MouseEventArgs e)
        {
            HoverPosition = PixelToPosition(e.Location.X);

            Cursor = Cursors.Default;
            
            selectionStartMoveController.ProcessMouseMove(e);
            selectionEndMoveController.ProcessMouseMove(e);

        }

        private void VideoCutterTimeline_MouseLeave(object sender, EventArgs e)
        {
            HoverPosition = null;
            
            selectionStartMoveController.ProcessMouseLeave(e);
            selectionEndMoveController.ProcessMouseLeave(e);

            Cursor = Cursors.Default;
        }

        private void OnSelectionChanged()
        {
            SelectionChanged?.Invoke(this, new SelectionChangedEventArgs());
        }


        private void OnPositionChangeRequest(long frame)
        {
            PositionChangeRequest?.Invoke(this, new PositionChangeRequestEventArgs() { Position = frame });
        }

        /// <summary>
        /// Creates/updates/clears selection. 
        /// Once selection is changed, the 'SelectionChanged' event is raised. 
        /// </summary>
        public void SetSelection(long? selectionStart, long? selectionEnd)
        {
            if ((selectionStart == null && selectionEnd != null) || (selectionStart != null && selectionEnd != null && selectionStart.Value >= selectionEnd.Value))
                return;

            if ((selectionStart == null && selectionEnd  != null) || (selectionEnd != null && selectionEnd.Value <= selectionStart))
                return;

            this.selectionStart = selectionStart;
            this.selectionEnd = selectionEnd;

            Invalidate();

            OnSelectionChanged();
        }


        private void VideoCutterTimeline_MouseDown(object sender, MouseEventArgs e)
        {
            selectionStartMoveController.ProcessMouseDown(e);
            selectionEndMoveController.ProcessMouseDown(e);
        }

        private void VideoCutterTimeline_MouseUp(object sender, MouseEventArgs e)
        {
            if (!selectionStartMoveController.IsDragInProgress() && !selectionEndMoveController.IsDragInProgress())
            {
                var frame = PixelToPosition(e.X);
                if (e.Button == MouseButtons.Middle && e.Clicks == 1)
                {
                    if (ModifierKeys == Keys.Shift)
                    {
                        SetSelection(frame, Length);
                    } 
                    else if (ModifierKeys == Keys.Control)
                    {
                        SetSelection(0, frame);
                    }
                    else if (SelectionStart == null)
                    {
                        SetSelection(frame, null);
                    }
                    else if (SelectionEnd == null)
                    {
                        SetSelection(SelectionStart.Value, frame);
                    }
                }
                else if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {

                    OnPositionChangeRequest(frame);
                }
            }
            else
            {
                selectionStartMoveController.ProcessMouseUp(e);
                selectionEndMoveController.ProcessMouseUp(e);
            }
        }

        private abstract class PositionMoveController
        {
            protected VideoCutterTimeline ctrl;
            protected bool dragInProgress = false; 
            
            public PositionMoveController(VideoCutterTimeline ctrl)
            {
                this.ctrl = ctrl;
            }

            protected abstract long? GetCurrentPosition();
            protected abstract void SetCurrentPosition(long frame);

            public bool IsDragInProgress()
            {
                return dragInProgress;
            }

            public bool IsDragStartPossible(int posX)
            {
                return !dragInProgress && IsInDragSizeByFrame(posX, GetCurrentPosition());
            }

            public void ProcessMouseMove(MouseEventArgs e)
            {
                if (dragInProgress)
                {
                    ctrl.Cursor = Cursors.SizeWE;
                    var newPos = ctrl.PixelToPosition(e.X);
                    SetCurrentPosition(newPos);
                }
                else
                {
                    if (IsInDragSizeByFrame(e.X, GetCurrentPosition()))
                    {
                        ctrl.Cursor = Cursors.SizeWE;
                    }
                }
            }
            
            public void ProcessMouseLeave(EventArgs e)
            {
                dragInProgress = false;
            }
            public void ProcessMouseDown(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    if (IsInDragSizeByFrame(e.X, GetCurrentPosition()))
                    {
                        dragInProgress = true; 
                    }
                }
            }

            public void ProcessMouseUp(MouseEventArgs e)
            {
                if (dragInProgress)
                {
                    dragInProgress = false;
                    var frame = GetCurrentPosition().Value;
                    ctrl.OnPositionChangeRequest(frame);
                }
            }

            private bool IsInDragSizeByFrame(int testedX, long? refFrame)
            {
                if (refFrame == null)
                    return false;
                var refX = ctrl.PositionToPixel(refFrame.Value);
                return Math.Abs(testedX - refX) < SystemInformation.DragSize.Width;
            }
        }
        private class SelectionStartMoveController : PositionMoveController
        {
            public SelectionStartMoveController(VideoCutterTimeline ctrl) : base(ctrl)
            {
            }

            protected override long? GetCurrentPosition()
            {
                return ctrl.SelectionStart;
            }

            protected override void SetCurrentPosition(long frame)
            {
                if (ctrl.SelectionEnd == null || ctrl.SelectionEnd > frame  + 1)
                    ctrl.SetSelection(frame, ctrl.selectionEnd);
            }
        }
        private class SelectionEndMoveController : PositionMoveController
        {
            public SelectionEndMoveController(VideoCutterTimeline ctrl) : base(ctrl)
            {
            }

            protected override long? GetCurrentPosition()
            {
                return ctrl.SelectionEnd;
            }
            protected override void SetCurrentPosition(long frame)
            {
                if (ctrl.SelectionStart != null && frame > ctrl.SelectionStart + 1)
                    ctrl.SetSelection(ctrl.selectionStart, frame);
            }
        }

        private class TimelineTooltip
        {
            public int X { get; set; }
            public string Text { get; set; }
        }
    }


    public class TimelineHoverEventArgs : EventArgs
    {
    }


    public class SelectionChangedEventArgs : EventArgs
    {
    }

    public class PositionChangeRequestEventArgs : EventArgs
    {
        public long Position { get; set; }
    }
}
