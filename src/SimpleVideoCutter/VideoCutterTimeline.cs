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
using System.Drawing.Drawing2D;
using System.Runtime.Versioning;

namespace SimpleVideoCutter
{
    public class Selection
    {
        public long Start;
        public long End;
        public long Duration => End - Start;

        public bool Includes(long position)
        {
            return position >= Start && position <= End;
        }
        public bool Overlaps(Selection other)
        {
            if (other.End < this.Start || other.Start > this.End)
                return false;
            return true; 
        }
    }
    [SupportedOSPlatform("windows")]
    public class SelectionsMoveController
    {
        protected VideoCutterTimeline ctrl;
        protected Selections selections;
        protected int? indexDraggedStartOfSelection;
        protected int? indexDraggedEndOfSelection;

        protected bool DragInProgress => indexDraggedStartOfSelection != null || indexDraggedEndOfSelection != null;


        public SelectionsMoveController(VideoCutterTimeline ctrl, Selections selections)
        {
            this.ctrl = ctrl;
            this.selections = selections;
        }
        public bool IsDragInProgress()
        {
            return DragInProgress;
        }

        public void ProcessMouseMoveFrame(long newPos)
        {
            if (DragInProgress)
            {
                ctrl.Cursor = Cursors.SizeWE;
                if (indexDraggedStartOfSelection != null)
                {
                    selections.SetSelectionStart(indexDraggedStartOfSelection.Value, newPos); 
                }
                else if (indexDraggedEndOfSelection != null)
                {
                    selections.SetSelectionEnd(indexDraggedEndOfSelection.Value, newPos);
                }
            }
            else
            {
                var start = selections.AllSelections.FindIndex(sel => IsInDragSizeByFrame(newPos, sel.Start));
                var end = selections.AllSelections.FindIndex(sel => IsInDragSizeByFrame(newPos, sel.End));
                if (start >= 0 || end >= 0)
                {
                    ctrl.Cursor = Cursors.SizeWE;
                } 
            }
        }

        public void ProcessMouseLeaveFrame()
        {
            indexDraggedStartOfSelection = null;
            indexDraggedEndOfSelection = null;
        }
        public void ProcessMouseDownFrame(long frame, MouseButtons button, int clicks)
        {
            if (button == MouseButtons.Left && clicks == 1)
            {
                var start = selections.AllSelections.FindIndex(sel => IsInDragSizeByFrame(frame, sel.Start));
                var end = selections.AllSelections.FindIndex(sel => IsInDragSizeByFrame(frame, sel.End));
                if (start >= 0)
                {
                    indexDraggedStartOfSelection = start;
                }
                else if (end >= 0)
                {
                    indexDraggedEndOfSelection = end;
                }
            }
        }

        public void ProcessMouseUpFrame(long frame)
        {
            if (DragInProgress)
            {
                indexDraggedStartOfSelection = null;
                indexDraggedEndOfSelection = null;
                ctrl.OnPositionChangeRequest(frame);
            }
        }

        private bool IsInDragSizeByFrame(long testedFrame, long? refFrame)
        {
            if (refFrame == null)
                return false;
            var refX = ctrl.PositionToPixel(refFrame.Value);
            var testedFrameX = ctrl.PositionToPixel(testedFrame);

            return Math.Abs(testedFrameX - refX) < SystemInformation.DragSize.Width;
        }

        public bool IsDragStartPossibleFrame(long frame)
        {
            var start = selections.AllSelections.FindIndex(sel => IsInDragSizeByFrame(frame, sel.Start));
            return start >= 0;
        }

        public bool IsDragEndPossibleFrame(long frame)
        {
            var start = selections.AllSelections.FindIndex(sel => IsInDragSizeByFrame(frame, sel.End));
            return start >= 0;
        }


    }

    public class Selections
    {
        public event EventHandler<EventArgs>? SelectionsChanged;

        private List<Selection> selections = new List<Selection>();
        public int Count => selections.Count;
        public Selection this[int i] => selections[i];

        public Selections()
        {
        }

        public void AddSelection(long start, long end)
        {
            if (!CanAddSelection(start, end))
                return;
            var newSelection = new Selection() { Start = start, End = end };
            selections.Add(newSelection);
            // TODO: sort in place
            var sorted = selections.OrderBy(s => s.Start).ToArray();
            selections.Clear();
            selections.AddRange(sorted);
            OnSelectionsChanged();
        }

        public bool Empty => selections.Count == 0;
        public long? OverallStart => selections.FirstOrDefault()?.Start;
        public long? OverallEnd => selections.LastOrDefault()?.End;
        public long OverallDuration => selections.Sum(sel => sel.Duration);

        public List<Selection> AllSelections => selections;

        public void Clear()
        {
            selections.Clear();
            OnSelectionsChanged();
        }

        public void ReplaceAll(IList<Selection> newSelections)
        {
            selections.Clear();
            selections.AddRange(newSelections);
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

        public void DeleteSelection(int index)
        {
            selections.RemoveAt(index);
            OnSelectionsChanged();
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
            var prevStart = selection.Start;
            try
            {
                var prev = index > 0 ? this.selections[index - 1] : null;
                if (prev != null && prev.End > value)
                {
                    selections[index].Start = prev.End + 1;
                    return false;
                }

                selections[index].Start = value > selections[index].End ? selections[index].End : value;
                return true;
            }
            finally
            {
                if (selections[index].Start != prevStart)
                {
                    OnSelectionsChanged();
                }
            }
        }

        public bool SetSelectionEnd(int index, long value)
        {
            var selection = this.selections[index];
            var prevEnd = selection.End;
            try
            {
                var next = index < selections.Count - 1 ? this.selections[index + 1] : null;
                if (next != null && next.Start < value)
                {
                    selections[index].End = next.Start - 1;
                    return false;
                }

                selections[index].End = value < selections[index].Start ? selections[index].Start : value;
                return true;
            }
            finally
            {
                if (selections[index].End != prevEnd)
                {
                    OnSelectionsChanged();
                }
            }
        }

        public bool CanStartSelectionAtFrame(long frame)
        {
            return !selections.Any(s => s.Includes(frame));
        }

        public bool CanAddSelection(long start, long end)
        {
            if (end <= start)
                return false;

            var newSelection = new Selection() { Start = start, End = end };
            if (selections.Any(s => s.Overlaps(newSelection)))
                return false;
            
            return true;
        }
    }

    [SupportedOSPlatform("windows")]
    public partial class VideoCutterTimeline : UserControl
    {
        public event EventHandler<TimelineHoverEventArgs>? TimelineHover;
        public event EventHandler<SelectionChangedEventArgs>? SelectionChanged;
        public event EventHandler<PositionChangeRequestEventArgs>? PositionChangeRequest;
        public event EventHandler<KeyframesRequestEventArgs>? KeyframesRequest;

        private Brush brushBackground = new SolidBrush(Color.FromArgb(0xAD, 0xB5, 0xBD));
        private Brush brushBackgroundInfoArea = new SolidBrush(Color.FromArgb(0xAD, 0xB5, 0xBD)); 
        private Brush brushBackgroundInfoAreaOffset = new SolidBrush(Color.FromArgb(0x6C, 0x75, 0x7D));
        private Brush brushTicksArea = new SolidBrush(Color.FromArgb(0x49, 0x50, 0x57));
        private Brush brushSelectionArea = new SolidBrush(Color.FromArgb(0x6C, 0x75, 0x7D));
        private Brush brushBackgroundSelected = new HatchBrush(HatchStyle.DarkDownwardDiagonal, 
            Color.FromArgb(0xF8, 0xF9, 0xFA), Color.FromArgb(128, 0xF8, 0xF9, 0xFA));
        private Brush brushInfoAreaText = new SolidBrush(Color.FromArgb(0xF8, 0xF9, 0xFA));
        private Pen penBigTicks = new Pen(Color.FromArgb(0xE9, 0xEC, 0xEF));
        private Pen penSmallTicks = new Pen(Color.FromArgb(0xAD, 0xB5, 0xBD));
        private Brush brushHoverPosition = new SolidBrush(Color.FromArgb(0xC8, 0x17, 0x17));
        private Brush brushPosition = new SolidBrush(Color.FromArgb(0x00, 0x5C, 0x9E));
        private Brush brushKeyFrames = new SolidBrush(Color.FromArgb(0x87, 0x92, 0x9B));

        private Brush brushSelectionMarker = new SolidBrush(Color.FromArgb(0x21, 0x25, 0x29));
        private Pen penSelectionMarker = new Pen(Color.FromArgb(0x21, 0x25, 0x29));
        private SelectionsMoveController selectionsMoveController;

        private long position = 0;
        private long? hoverPosition = null;
        private Selections selections = new Selections();
        private long? newSelectionStart = null;
        public bool NewSelectionStartRegistered => this.newSelectionStart != null;

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

        public Selections Selections { get => selections; }

        public bool AreSelectionsOnKeyFrames 
        {  
            get
            {
                return Selections.AllSelections.All(sel =>
                {
                    var distanceStart = Math.Abs(sel.Start - LocateNearestKeyFrame(sel.Start));
                    var distanceEnd = Math.Abs(sel.End - LocateNearestKeyFrame(sel.End));

                    var acceptable = 500;
                    return Math.Max(distanceStart, distanceEnd) < acceptable;
                });
            } 
        }

        public void AdjustSelectionsToKeyFrames()
        {
            bool anyChanged = false; 
            var newSelections = Selections.AllSelections.Select(sel =>
            {
                var nearestStartKeyFrame = LocateNearestKeyFrame(sel.Start);
                var nearestEndKeyFrame = LocateNearestKeyFrame(sel.End);
                var distanceStart = Math.Abs(sel.Start - nearestStartKeyFrame);
                var distanceEnd = Math.Abs(sel.End - nearestEndKeyFrame);
                if (distanceStart > 0 || distanceEnd > 0)
                {
                    anyChanged = true;
                    return new Selection() { Start = nearestStartKeyFrame, End = nearestEndKeyFrame };
                }
                return sel;
            }).ToList();
            if (anyChanged)
            {
                Selections.ReplaceAll(newSelections.Where(sel => sel.End - sel.Start > 0).ToList());
            }
        }

        public VideoCutterTimeline()
        {
            InitializeComponent();
            selectionsMoveController = new SelectionsMoveController(this, selections);
            selections.SelectionsChanged += (s, e) =>
            {
                Invalidate();
                OnSelectionChanged();
            };
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

        private KeyframesRequestEventArgs? GetKeyframesData()
        {
            if (KeyframesRequest != null)
            {
                var eventArgs = new KeyframesRequestEventArgs();
                KeyframesRequest(this, eventArgs);
                return eventArgs;
            }
            else
            {
                return null;
            }
        }

        private long LocateNearestKeyFrame(long position)
        {
            var keyframesData = GetKeyframesData();
            if (keyframesData == null || keyframesData.Keyframes == null || keyframesData.Keyframes.Count == 0)
                return position;
            var keyframes = keyframesData.Keyframes;
            var foundIndex = keyframes.BinarySearch(position);
            if (foundIndex >= 0)
                return position;

            var indexFirstGreater = ~foundIndex;
            long keyFrameNext = indexFirstGreater < keyframes.Count ? keyframes[indexFirstGreater] : Length - 1;
            long keyFramePrev = indexFirstGreater > 0 ? keyframes[indexFirstGreater - 1] : 0;

            var distanceNext = Math.Abs(position - keyFrameNext);
            var distancePrev = Math.Abs(position - keyFramePrev);

            return distanceNext < distancePrev ? keyFrameNext : keyFramePrev;
        }

        private long FindNearestAcceptableKeyFrame(long position)
        {
            var nearestKeyFrame = LocateNearestKeyFrame(position);
            var acceptablePixelRadius = 5;
            var accpetableMsRadius = (long)(acceptablePixelRadius / PixelsPerMilliseconds());
            var minDistanceFound = Math.Abs(position - nearestKeyFrame);
            if (minDistanceFound > accpetableMsRadius)
                return position;
            return nearestKeyFrame;
        }

        private void VideoCutterTimeline_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.FillRectangle(brushBackground, ClientRectangle);
            if (Length == 0)
            {
                return;
            }

            TimelineTooltip? timelineTooltip = null;

            var infoAreaHeight = 22;
            var infoAreaRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, infoAreaHeight);

            e.Graphics.FillRectangle(brushBackgroundInfoArea, infoAreaRect);



            {
                // info area background
                var pixelStart = ((float)offset / Length) * ClientRectangle.Width;
                var pixelEnd = ((float)PixelToPosition(ClientRectangle.Width) / Length) * ClientRectangle.Width;
                e.Graphics.FillRectangle(brushBackgroundInfoAreaOffset, pixelStart, 0, pixelEnd - pixelStart, infoAreaHeight);


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
                    string text = time.ToNormalizedString();

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
                }

            }

            e.Graphics.TranslateTransform(0, ticksAreaHeight);
            var keyframesData = GetKeyframesData();
            var keyframes = keyframesData?.Keyframes;
            if (keyframes != null)
            {
                var length = keyframesData!.InProgress ? keyframes.Count - 1 : keyframes.Count;
                for (var i = 1; i <= length; i += 2)
                {
                    var keyframeCurr = i == keyframes.Count ? Length : keyframes[i];
                    var keyframePrev = keyframes[i - 1];
                    var posXPixel1 = (keyframePrev - offset) * PixelsPerMilliseconds();
                    var posXPixel2 = (keyframeCurr - offset) * PixelsPerMilliseconds();
                    e.Graphics.FillRectangle(brushKeyFrames, posXPixel1, 0, posXPixel2 - posXPixel1, selectionAreaHeight);
                }
            }

            for (int i = 0; i < this.selections.Count; i++)
            {
                var selection = this.selections[i];
                var pixelsStart = PositionToPixel(selection.Start);
                var pixelsEnd = PositionToPixel(selection.End);
                var selectionRect = new Rectangle(pixelsStart, 0, pixelsEnd - pixelsStart, selectionAreaHeight);
                e.Graphics.FillRectangle(brushBackgroundSelected, selectionRect);


                var pixel = PositionToPixel(selection.Start);
                GraphicsUtils.DrawSolidRectangle(e.Graphics, brushSelectionMarker, penSelectionMarker, pixel-1, 0, 2, selectionAreaHeight);

                pixel = PositionToPixel(selection.End);
                GraphicsUtils.DrawSolidRectangle(e.Graphics, brushSelectionMarker, penSelectionMarker, pixel - 1, 0, 2, selectionAreaHeight);

            }

            if (newSelectionStart != null)
            {
                var pixel = PositionToPixel(newSelectionStart.Value);
                GraphicsUtils.DrawSolidRectangle(e.Graphics, brushSelectionMarker, penSelectionMarker, pixel - 1, 0, 2, selectionAreaHeight);

            }

            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(0, infoAreaHeight);

            var positionPixel = PositionToPixel(Position);
            e.Graphics.FillRectangle(brushPosition, positionPixel, 0, 3, ticksAreaHeight + selectionAreaHeight);


            if (HoverPosition != null)
            {
                var normalizedHover = HoverPosition.Value;
                var pixel = PositionToPixel(normalizedHover);
                if (selectionsMoveController.IsDragStartPossibleFrame(normalizedHover))
                {
                    timelineTooltip = new TimelineTooltip() { X = pixel, Text = GlobalStrings.VideoCutterTimeline_MoveClipStart };
                }
                if (selectionsMoveController.IsDragEndPossibleFrame(normalizedHover))
                {
                    timelineTooltip = new TimelineTooltip() { X = pixel, Text = GlobalStrings.VideoCutterTimeline_MoveClipEnd };
                }

                e.Graphics.FillRectangle(brushHoverPosition, pixel, 0, 3, ticksAreaHeight + selectionAreaHeight);
                PaintTriangle(e.Graphics, brushHoverPosition, PositionToPixel(normalizedHover) + 1, 8, 8);

                string? tooltipSetClipOverrideText = null;
                if (ModifierKeys == Keys.Shift)
                    tooltipSetClipOverrideText = GlobalStrings.VideoCutterTimeline_SetClipFromHereTillEnd;
                else if (ModifierKeys == Keys.Control)
                    tooltipSetClipOverrideText = GlobalStrings.VideoCutterTimeline_SetClipFromStartTillHere;

                if (newSelectionStart == null && selections.CanStartSelectionAtFrame(HoverPosition.Value))
                {
                    timelineTooltip = new TimelineTooltip() { X = pixel, Text = tooltipSetClipOverrideText ?? GlobalStrings.VideoCutterTimeline_SetClipStartHere };
                }
                else if (newSelectionStart != null && normalizedHover > newSelectionStart.Value 
                    && selections.CanAddSelection(newSelectionStart.Value, HoverPosition.Value))
                {
                    timelineTooltip = new TimelineTooltip() { X = pixel, Text = tooltipSetClipOverrideText ?? GlobalStrings.VideoCutterTimeline_SetClipEndHere };
                }
            }

            e.Graphics.ResetTransform();

            /*
            if (timelineTooltip != null)
            {
                PaintStringInBox(e.Graphics, Brushes.LightYellow, Brushes.Gray, timelineTooltip.Text, infoAreaRect, timelineTooltip.X);
            }
            */

            // info area text
            {
                var time = TimeSpan.FromMilliseconds(Position);
                var text = string.Format($"{GlobalStrings.VideoCutterTimeline_Time}: {time.ToNormalizedString(true)} ");
                if (HoverPosition != null)
                {
                    var normalizedHover = HoverPosition.Value;
                    var hoverTime = TimeSpan.FromMilliseconds(HoverPosition.Value);
                    text = text + string.Format($" {GlobalStrings.VideoCutterTimeline_HoveredTime}: {hoverTime.ToNormalizedString(true)} ");

                    if (timelineTooltip != null)
                        text += " " + timelineTooltip.Text.Replace("\n", "; ");

                }


                PaintStringInBox(e.Graphics, null, brushInfoAreaText, text, infoAreaRect, 12);
            }
        }

        private void PaintStringInBox(Graphics gr, Brush? background, Brush textBrush, string str, Rectangle parentRectangle, int location)
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
            Cursor = Cursors.Default;
            var normalizedPosX = NormalizeMouseEventX(e.Location.X);
            HoverPosition = PixelToPosition(normalizedPosX);
            var frame = PixelToPosition(normalizedPosX);
            var normalizedFrame = FindNearestAcceptableKeyFrame(frame);
            selectionsMoveController.ProcessMouseMoveFrame(normalizedFrame);
        }

        private void VideoCutterTimeline_MouseLeave(object sender, EventArgs e)
        {
            HoverPosition = null;
            selectionsMoveController.ProcessMouseLeaveFrame();
            Cursor = Cursors.Default;
        }

        private void OnSelectionChanged()
        {
            SelectionChanged?.Invoke(this, new SelectionChangedEventArgs());
        }


        internal void OnPositionChangeRequest(long frame)
        {
            PositionChangeRequest?.Invoke(this, new PositionChangeRequestEventArgs() { Position = frame });
        }
        
        public void RegisterNewSelectionStart(long frame)
        {
            this.newSelectionStart = frame;
            OnSelectionChanged();
            Refresh();
        }
        public void RegisterNewSelectionEnd(long frame)
        {
            if (newSelectionStart == null)
                return; 

            var start = newSelectionStart.Value;
            newSelectionStart = null;
            selections.AddSelection(start, frame);
            OnSelectionChanged();
        }



        private int NormalizeMouseEventX(int x)
        {
            var frame = PixelToPosition(x);
            var isShift = ModifierKeys == Keys.Shift;
            var nearestFrame = isShift ? frame : FindNearestAcceptableKeyFrame(frame);
            return frame != nearestFrame ? PositionToPixel(nearestFrame) : x;
        }

        private void VideoCutterTimeline_MouseDown(object sender, MouseEventArgs e)
        {
            var frame = PixelToPosition(e.X);
            var normalizedFrame = FindNearestAcceptableKeyFrame(frame);
            selectionsMoveController.ProcessMouseDownFrame(normalizedFrame, e.Button, e.Clicks);
        }

        private void VideoCutterTimeline_MouseUp(object sender, MouseEventArgs e)
        {
            var frame = PixelToPosition(e.X);
            var normalizedFrame = FindNearestAcceptableKeyFrame(frame);
            if (!selectionsMoveController.IsDragInProgress())
            {
                if (e.Button == MouseButtons.Middle && e.Clicks == 1)
                {
                    /*
                    if (ModifierKeys == Keys.Shift)
                    {
                        SetSelection(frame, Length);
                    } 
                    else if (ModifierKeys == Keys.Control)
                    {
                        SetSelection(0, frame);
                    }
                    */

                    if (newSelectionStart == null && selections.CanStartSelectionAtFrame(normalizedFrame))
                    {
                        RegisterNewSelectionStart(normalizedFrame);
                    }
                    else if (newSelectionStart != null && selections.CanAddSelection(newSelectionStart.Value, normalizedFrame))
                    {
                        RegisterNewSelectionEnd(normalizedFrame);
                    }
                }
                else if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {

                    OnPositionChangeRequest(normalizedFrame);
                }
            }
            else
            {
                selectionsMoveController.ProcessMouseUpFrame(normalizedFrame);
            }
        }

        private class TimelineTooltip
        {
            public int X { get; set; }
            public string Text { get; set; } = "";
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

    public class KeyframesRequestEventArgs : EventArgs
    {
        public List<long>? Keyframes { get; set; }
        public bool InProgress { get; set; }
    }
    [SupportedOSPlatform("windows")]
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
