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
    public class Selection
    {
        public long Start;
        public long End;

        public bool Includes(long position)
        {
            return position >= Start && position <= End;
        }
    }
    public class SelectionsMoveController
    {
        protected VideoCutterTimeline ctrl;
        protected Selections selections;
        protected int? draggedStart;
        protected int? draggedEnd;

        protected bool DragInProgress => draggedStart != null || draggedEnd != null;


        public SelectionsMoveController(VideoCutterTimeline ctrl, Selections selections)
        {
            this.ctrl = ctrl;
            this.selections = selections;
        }

        //protected abstract long? GetCurrentPosition();
        //protected abstract void SetCurrentPosition(long frame);

        protected long? GetCurrentPosition()
        {
            return 0;
        }

        public bool IsDragInProgress()
        {
            return DragInProgress;
        }

        public bool IsDragStartPossible(int posX)
        {
            return !DragInProgress && IsInDragSizeByFrame(posX, GetCurrentPosition());
        }

        public void ProcessMouseMove(MouseEventArgs e)
        {
            if (DragInProgress)
            {
                ctrl.Cursor = Cursors.SizeWE;
                var newPos = ctrl.PixelToPosition(e.X);
                if (draggedStart != null)
                {
                    selections.SetSelectionStart(draggedStart.Value, newPos); 
                }
                else if (draggedEnd != null)
                {
                    selections.SetSelectionEnd(draggedEnd.Value, newPos);
                }
            }
            else
            {
                var start = selections.AllSelections.FindIndex(sel => IsInDragSizeByFrame(e.X, sel.Start));
                var end = selections.AllSelections.FindIndex(sel => IsInDragSizeByFrame(e.X, sel.End));
                if (start >= 0 || end >= 0)
                {
                    ctrl.Cursor = Cursors.SizeWE;
                } 
            }
        }

        public void ProcessMouseLeave(EventArgs e)
        {
            draggedStart = null;
            draggedEnd = null;
        }
        public void ProcessMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                var start = selections.AllSelections.FindIndex(sel => IsInDragSizeByFrame(e.X, sel.Start));
                var end = selections.AllSelections.FindIndex(sel => IsInDragSizeByFrame(e.X, sel.End));
                if (start >= 0)
                {
                    draggedStart = start;
                }
                else if (end >= 0)
                {
                    draggedEnd = end;
                }
            }
        }

        public void ProcessMouseUp(MouseEventArgs e)
        {
            if (DragInProgress)
            {
                draggedStart = null;
                draggedEnd = null;
                var frame = GetCurrentPosition().Value;
                //ctrl.OnPositionChangeRequest(frame);
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

    public class Selections
    {
        public event EventHandler<EventArgs> SelectionsChanged;

        private List<Selection> selections = new List<Selection>();
        public int Count => selections.Count;
        public Selection this[int i] => selections[i];

        public Selections()
        {
            this.AddSelection(1000, 2000);
            this.AddSelection(13000, 14000);
            this.AddSelection(25000, 27000);
        }

        public void AddSelection(long start, long end)
        {
            // TODO: check for overlapping 
            selections.Add(new Selection() { Start = start, End = end });
            // TODO: sort in place
            var sorted = selections.OrderBy(s => s.Start).ToArray();
            selections.Clear();
            selections.AddRange(sorted);
            OnSelectionsChanged();
        }

        public bool Empty => selections.Count == 0;
        public long? OverallStart => selections.FirstOrDefault()?.Start;
        public long? OverallEnd => selections.LastOrDefault()?.End;

        public List<Selection> AllSelections => selections;

        public void Clear()
        {
            selections.Clear();
            OnSelectionsChanged();
        }

        private void OnSelectionsChanged()
        {
            SelectionsChanged?.Invoke(this, new EventArgs());
        }

        public int? IsInSelection(long position)
        {
            var index = selections.FindIndex(s => s.Includes(position));
            if (index == -1)
                return null;
            else
                return index;
        }



        public long? FindNextValidPosition(long position)
        {
            int? selectionIndex = IsInSelection(position);
            if (selectionIndex.HasValue)
            {
                return position;
            }
            var selection = selections.FirstOrDefault(s => s.Start > position);
            return selection?.Start;
        }

        public bool SetSelectionStart(int index, long value)
        {
            var selection = this.selections[index];
            var prev = index > 0 ? this.selections[index-1] : null;
            if (prev != null && prev.End > value)
            {
                selections[index].Start = prev.End+1;
                return false;
            }
               
            selections[index].Start = value > selections[index].End ? selections[index].End : value;
            return true; 
        }

        public bool SetSelectionEnd(int index, long value)
        {
            var selection = this.selections[index];
            var next = index < selections.Count - 1 ? this.selections[index + 1] : null;
            if (next != null && next.Start < value)
            {
                selections[index].End = next.Start - 1;
                return false;
            }

            selections[index].End = value < selections[index].Start ? selections[index].Start : value;
            return true;
        }
    }

    public partial class VideoCutterTimeline : UserControl
    {
        public event EventHandler<TimelineHoverEventArgs> TimelineHover;
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;
        public event EventHandler<PositionChangeRequestEventArgs> PositionChangeRequest;
        private Brush brushBackground = new SolidBrush(Color.FromArgb(0xAD, 0xB5, 0xBD));
        private Brush brushBackgroundInfoArea = new SolidBrush(Color.FromArgb(0xAD, 0xB5, 0xBD)); 
        private Brush brushBackgroundInfoAreaOffset = new SolidBrush(Color.FromArgb(0x6C, 0x75, 0x7D));
        private Brush brushTicksArea = new SolidBrush(Color.FromArgb(0x49, 0x50, 0x57));
        private Brush brushSelectionArea = new SolidBrush(Color.FromArgb(0x6C, 0x75, 0x7D));

        private Brush brushBackgroundSelected = new SolidBrush(Color.FromArgb(0xF8, 0xF9, 0xFA));

        private Brush brushInfoAreaText = new SolidBrush(Color.FromArgb(0xF8, 0xF9, 0xFA));
        private Pen penBigTicks = new Pen(Color.FromArgb(0xE9, 0xEC, 0xEF));
        private Pen penSmallTicks = new Pen(Color.FromArgb(0xAD, 0xB5, 0xBD));
        private Brush brushHoverPosition = new SolidBrush(Color.FromArgb(0xC8, 0x17, 0x17));
        private Brush brushPosition = new SolidBrush(Color.FromArgb(0x00, 0x5C, 0x9E));
        
        private Brush brushSelectionMarker = new SolidBrush(Color.FromArgb(0x21, 0x25, 0x29));
        private Pen penSelectionMarker = new Pen(Color.FromArgb(0x21, 0x25, 0x29));
        //private PositionMoveController selectionStartMoveController;
        //private PositionMoveController selectionEndMoveController;
        private SelectionsMoveController selectionsMoveController;

        private long position = 0;
        private long? hoverPosition = null;
        private long? selectionStart = null;
        private long? selectionEnd = null;
        private Selections selections = new Selections();


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

        public Selections Selections { get => selections; }

        public VideoCutterTimeline()
        {
            InitializeComponent();
            selectionsMoveController = new SelectionsMoveController(this, selections);
            //selectionStartMoveController = new SelectionStartMoveController(this);
            //selectionEndMoveController = new SelectionEndMoveController(this);
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
            if (Length == 0)
            {
                return;
            }

            TimelineTooltip timelineTooltip = null;

            var infoAreaHeight = 22;
            var infoAreaRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, infoAreaHeight);

            e.Graphics.FillRectangle(brushBackgroundInfoArea, infoAreaRect);



            {
                // info area background
                var pixelStart = ((float)offset / Length) * ClientRectangle.Width;
                var pixelEnd = ((float)PixelToPosition(ClientRectangle.Width) / Length) * ClientRectangle.Width;
                e.Graphics.FillRectangle(brushBackgroundInfoAreaOffset, pixelStart, 0, pixelEnd - pixelStart, infoAreaHeight);

                // info area text
                var time = TimeSpan.FromMilliseconds(Position);
                var text = string.Format($"{GlobalStrings.VideoCutterTimeline_Time}: {time:hh\\:mm\\:ss\\:fff} ");
                if (HoverPosition != null)
                {
                    var hoverTime = TimeSpan.FromMilliseconds(HoverPosition.Value);
                    text = text + string.Format($" {GlobalStrings.VideoCutterTimeline_HoveredTime}: {hoverTime:hh\\:mm\\:ss\\:fff} ");
                }
                PaintStringInBox(e.Graphics, null, brushInfoAreaText, text, infoAreaRect, 12);
            }
            e.Graphics.TranslateTransform(0, infoAreaHeight);

            var ticksAreaHeight = 30;
            var selectionAreaHeight = 30;

            var selectionAreaRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ticksAreaHeight+ selectionAreaHeight);
            e.Graphics.FillRectangle(brushSelectionArea, selectionAreaRect);

            // ticks area 
            var ticksAreaRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ticksAreaHeight);
            e.Graphics.FillRectangle(brushTicksArea, ticksAreaRect);
            float pixelsPerSecond = PixelsPerMilliseconds() * 1000.0f;
            for (long position = 0; position <= Length; position += 1000)
            {
                var time = TimeSpan.FromMilliseconds(position);
                var posXPixel = (position - offset) * PixelsPerMilliseconds();
                if (posXPixel >= -ClientRectangle.Width && posXPixel <= ClientRectangle.Width)
                {
                    string text;
                    if (time.TotalHours > 1)
                        text = string.Format($"{time:hh\\:mm\\:ss}");
                    else
                        text = string.Format($"{time:mm\\:ss}");

                    var size = e.Graphics.MeasureString(text, this.Font);

                    var secondsPerSize = Math.Ceiling((size.Width * 2) / pixelsPerSecond);
                    var drawLabel = time.TotalSeconds % secondsPerSize == 0;

                    if (drawLabel)
                    {
                        var rect = new Rectangle((int)posXPixel+2, 0, 100, ticksAreaHeight);
                        e.Graphics.DrawString(text, this.Font, penBigTicks.Brush, rect, StringFormat.GenericDefault);
                    }

                    if (drawLabel)
                        e.Graphics.DrawLine(penBigTicks, (int)posXPixel, (ticksAreaHeight / 2), (int)posXPixel, ticksAreaHeight+selectionAreaHeight);
                    else
                        e.Graphics.DrawLine(penSmallTicks, (int)posXPixel, 3 * (ticksAreaHeight / 4), (int)posXPixel, ticksAreaHeight);

                    //if (time.Seconds == 0)
                    //    e.Graphics.DrawLine(penTickMinute, (int)posXPixel, timeLineHeight / 2, (int)posXPixel, timeLineHeight);


                }

            }
            e.Graphics.TranslateTransform(0, ticksAreaHeight);

            for (int i = 0; i < this.selections.Count; i++)
            {
                var selection = this.selections[i];
                var pixelsStart = PositionToPixel(selection.Start);
                var pixelsEnd = PositionToPixel(selection.End);
                var selectionRect = new Rectangle(pixelsStart, 0, pixelsEnd - pixelsStart, selectionAreaHeight);
                e.Graphics.FillRectangle(brushBackgroundSelected, selectionRect);


                var pixel = PositionToPixel(selection.Start);
                GraphicsUtils.DrawSolidRectangle(e.Graphics, brushSelectionMarker, penSelectionMarker, pixel-1, 0, 2, selectionAreaHeight);
                //e.Graphics.FillRectangle(brushSelectionMarker, pixel, 0, 3, selectionAreaHeight);
                //GraphicsUtils.DrawSolidRectangle(e.Graphics, brushSelectionMarker, penSelectionMarker, pixel-2, 0, 4, selectionAreaHeight);
                //e.Graphics.FillRectangle(brushSelectionMarker, pixel-2, 0, 4, 2);
                //e.Graphics.FillRectangle(brushSelectionMarker, pixel-2, selectionAreaHeight-2, 4, 2);


                pixel = PositionToPixel(selection.End);
                GraphicsUtils.DrawSolidRectangle(e.Graphics, brushSelectionMarker, penSelectionMarker, pixel - 1, 0, 2, selectionAreaHeight);
                //e.Graphics.FillRectangle(brushSelectionMarker, pixel, 0, 3, selectionAreaHeight);
                //e.Graphics.FillRectangle(brushSelectionMarker, pixel-2, 0, 4, 2);
                //e.Graphics.FillRectangle(brushSelectionMarker, pixel - 2, selectionAreaHeight - 2, 4, 2);

            }

            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(0, infoAreaHeight);

            var positionPixel = PositionToPixel(Position);
            e.Graphics.FillRectangle(brushPosition, positionPixel, 0, 3, ticksAreaHeight + selectionAreaHeight);


            if (HoverPosition != null)
            {
                var pixel = PositionToPixel(HoverPosition);
                /*
                if (selectionStartMoveController.IsDragStartPossible(pixel) || selectionStartMoveController.IsDragInProgress())
                {
                    timelineTooltip = new TimelineTooltip() { X = pixel, Text = GlobalStrings.VideoCutterTimeline_MoveClipStart };
                }
                if (selectionEndMoveController.IsDragStartPossible(pixel) || selectionEndMoveController.IsDragInProgress())
                {
                    timelineTooltip = new TimelineTooltip() { X = pixel, Text = GlobalStrings.VideoCutterTimeline_MoveClipEnd };
                }
                */

                e.Graphics.FillRectangle(brushHoverPosition, pixel, 0, 3, ticksAreaHeight + selectionAreaHeight);
                PaintTriangle(e.Graphics, brushHoverPosition, PositionToPixel(HoverPosition) + 1, 8, 8);

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
            return;

            int timeLineHeight = ClientRectangle.Height - infoAreaHeight;

            /*
            if (SelectionStart != null && SelectionEnd != null)
            {
                var pixelsStart = PositionToPixel((long?)SelectionStart.Value);
                var pixelsEnd = PositionToPixel((long?)SelectionEnd.Value);
                var selectionRect = new Rectangle(pixelsStart, 0, pixelsEnd - pixelsStart, timeLineHeight);
                e.Graphics.FillRectangle(brushBackgroundSelected, selectionRect);
            }
            */




                /*

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
                */









            
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
            selectionsMoveController.ProcessMouseMove(e);
            //selectionStartMoveController.ProcessMouseMove(e);
            //selectionEndMoveController.ProcessMouseMove(e);

        }

        private void VideoCutterTimeline_MouseLeave(object sender, EventArgs e)
        {
            HoverPosition = null;
            selectionsMoveController.ProcessMouseLeave(e);
            //selectionStartMoveController.ProcessMouseLeave(e);
            //selectionEndMoveController.ProcessMouseLeave(e);

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
            selectionsMoveController.ProcessMouseDown(e);
            //selectionStartMoveController.ProcessMouseDown(e);
            //selectionEndMoveController.ProcessMouseDown(e);
        }

        private void VideoCutterTimeline_MouseUp(object sender, MouseEventArgs e)
        {
            //if (!selectionStartMoveController.IsDragInProgress() && !selectionEndMoveController.IsDragInProgress())
            if (!selectionsMoveController.IsDragInProgress())
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
                selectionsMoveController.ProcessMouseUp(e);
                //selectionStartMoveController.ProcessMouseUp(e);
                //selectionEndMoveController.ProcessMouseUp(e);
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
        /*
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
        */
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

    internal static class GraphicsUtils
    {

        public static void DrawSolidRectangle(Graphics g, Brush b, Pen p, Rectangle r)
        {
            g.DrawRectangle(p, r);
            g.FillRectangle(b, r);
        }

        public static void DrawSolidRectangle(Graphics g, Brush b, Pen p, int x, int y, int width, int height)
        {
            g.DrawRectangle(p, x, y, width, height);
            g.FillRectangle(b, x, y, width, height);
        }
    }
}
