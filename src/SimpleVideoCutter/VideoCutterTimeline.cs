using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    public partial class VideoCutterTimeline : UserControl
    {
        public event EventHandler<TimelineHoverEventArgs> TimelineHover;
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;
        public event EventHandler<PositionChangeRequestEventArgs> PositionChangeRequest;

        private Brush brushBackground = new SolidBrush(Color.FromArgb(0x4C, 0x4C, 0x4C));
        private Brush brushBackgroundInfoArea = new SolidBrush(Color.FromArgb(0x5C, 0x5C, 0x5C));
        private Brush brushBackgroundSelected = new SolidBrush(Color.FromArgb(0xAD, 0xAD, 0xAD));
        private Pen penTick = new Pen(Color.FromArgb(0x5A, 0x5A, 0x5A));
        private Brush brushHoverPosition = new SolidBrush(Color.FromArgb(0xC8, 0x17, 0x17));
        private Brush brushSelectionMarker = new SolidBrush(Color.FromArgb(0xFF, 0xE9, 0x7F));
        private Brush brushPosition = new SolidBrush(Color.FromArgb(0x00, 0x5C, 0x9E));

        private PositionMoveController selectionStartMoveController;
        private PositionMoveController selectionEndMoveController;

        private long position = 0;
        private long? hoverPosition = null;
        private long? selectionStart = null;
        private long? selectionEnd = null;

        public long Length { get; set; }

        public long Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                Invalidate();
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

        private void VideoCutterTimeline_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(brushBackground, ClientRectangle);

            TimelineTooltip timelineTooltip = null;

            var infoAreaHeight = 30;
            var infoAreaRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, infoAreaHeight);

            e.Graphics.FillRectangle(brushBackgroundInfoArea, infoAreaRect);

            e.Graphics.TranslateTransform(0, infoAreaHeight);

            int timeLineHeight = ClientRectangle.Height - infoAreaHeight;

            if (Length != 0)
            {
                float pixelsPerSecond = (float)ClientRectangle.Width / Length * 1000.0f;
                float pixelsPerMinute = pixelsPerSecond / 60.0f;

                if (pixelsPerSecond > 3)
                {
                    float position = 0;
                    float endPosition = Length / 1000 * pixelsPerSecond;
                    while (position <= endPosition)
                    {
                        e.Graphics.DrawLine(penTick, (int)position, 0, (int)position, timeLineHeight / 4);
                        position += pixelsPerSecond;
                    }
                }


                if (SelectionStart != null && SelectionEnd != null)
                {
                    var pixelsStart = FrameToPixel((long?)SelectionStart.Value);
                    var pixelsEnd = FrameToPixel((long?)SelectionEnd.Value);
                    var selectionRect = new Rectangle(pixelsStart, 0, pixelsEnd - pixelsStart, timeLineHeight);
                    e.Graphics.FillRectangle(brushBackgroundSelected, selectionRect);
                }

                if (SelectionStart != null)
                {
                    var pixel = FrameToPixel(SelectionStart.Value);
                    e.Graphics.FillRectangle(brushSelectionMarker, pixel, 0, 2, timeLineHeight);
                    PaintUpperHalfTriangle(e.Graphics, brushSelectionMarker, pixel, 8, 8, true);
                    PaintBottomHalfTriangle(e.Graphics, brushSelectionMarker, pixel, 8, 8, true, timeLineHeight);
                }
                if (SelectionEnd != null)
                {
                    var pixel = FrameToPixel(SelectionEnd.Value);
                    e.Graphics.FillRectangle(brushSelectionMarker, pixel, 0, 2, timeLineHeight);
                    PaintUpperHalfTriangle(e.Graphics, brushSelectionMarker, pixel, 8, 8, false);
                    PaintBottomHalfTriangle(e.Graphics, brushSelectionMarker, pixel, 8, 8, false, timeLineHeight);
                }

                var positionPixel = FrameToPixel(Position);
                PaintTriangle(e.Graphics, brushPosition, positionPixel, 8, 8);
                e.Graphics.FillRectangle(brushPosition, positionPixel, 0, 1, timeLineHeight);



                if (HoverPosition != null)
                {
                    var pixel = FrameToPixel(HoverPosition);

                    if (selectionStartMoveController.IsDragStartPossible(pixel) || selectionStartMoveController.IsDragInProgress())
                    {
                        timelineTooltip = new TimelineTooltip() { X = pixel, Text = "move clip start" };
                    }
                    if (selectionEndMoveController.IsDragStartPossible(pixel) || selectionEndMoveController.IsDragInProgress())
                    {
                        timelineTooltip = new TimelineTooltip() { X = pixel, Text = "move clip end" };
                    }



                    e.Graphics.FillRectangle(brushHoverPosition, pixel, 0, 1, timeLineHeight);
                    PaintTriangle(e.Graphics, brushHoverPosition, FrameToPixel(HoverPosition), 8, 8);

                    if (SelectionStart == null)
                    {
                        timelineTooltip = new TimelineTooltip() { X = pixel, Text = "middle click to set clip start here" };
                    }
                    else if (SelectionEnd == null)
                    {
                        timelineTooltip = new TimelineTooltip() { X = pixel, Text = "middle click to set clip end here" };
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



        private int FrameToPixel(long? frame)
        {
            if (frame == null)
                return 0;

            return (Length == 0 ? 0 : (int)(((float)frame.Value / (float)(Length)) * ClientRectangle.Width));
        }

        private long PixelToFrame(int x)
        {
            var pos = (Length == 0 ? (long)0 : (long)(x / (float)ClientRectangle.Width * (float)Length));
            return pos;
        }

        private void VideoCutterTimeline_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }


        private void VideoCutterTimeline_MouseMove(object sender, MouseEventArgs e)
        {
            HoverPosition = PixelToFrame(e.Location.X);

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
                var frame = PixelToFrame(e.X);
                if (e.Button == MouseButtons.Middle && e.Clicks == 1)
                {
                    if (SelectionStart == null)
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
                    var newPos = ctrl.PixelToFrame(e.X);
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
                var refX = ctrl.FrameToPixel(refFrame.Value);
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
