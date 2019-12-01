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

        public long Length { get; set; }

        private Brush brushBackground = new SolidBrush(Color.FromArgb(0x4C, 0x4C, 0x4C));
        private Brush brushBackgroundSelected = new SolidBrush(Color.FromArgb(0xAD, 0xAD, 0xAD));
        private Pen penTick = new Pen(Color.FromArgb(0x5A, 0x5A, 0x5A));
        private Brush brushHoverPosition = new SolidBrush(Color.FromArgb(0xC8, 0x17, 0x17));
        private Brush brushSelectionMarker = new SolidBrush(Color.FromArgb(0xFF, 0xE9, 0x7F));
        private Brush brushPosition = new SolidBrush(Color.FromArgb(0x00, 0x5C, 0x9E));

        private long position = 0;

        private PositionMoveController selectionStartMoveController;
        private PositionMoveController selectionEndMoveController;


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

        private long? hoverPosition = null;
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

        private long? selectionStart = null;
        public long? SelectionStart
        {
            get { return selectionStart; }
        }

        private long? selectionEnd = null;
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

            var infoAreaHeight = 30;
            var infoAreaRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, infoAreaHeight);


            e.Graphics.TranslateTransform(0, infoAreaHeight);
            
            var timeLineRect = ClientRectangle;

            if (Length != 0)
            {
                float pixelsPerSecond = (float)timeLineRect.Width / Length * 1000.0f;
                float pixelsPerMinute = pixelsPerSecond / 60.0f;

                if (pixelsPerSecond > 3)
                {
                    float position = 0;
                    float endPosition = Length / 1000 * pixelsPerSecond;
                    while (position <= endPosition)
                    {
                        e.Graphics.DrawLine(penTick, (int)position, 0, (int)position, timeLineRect.Height / 4);
                        position += pixelsPerSecond;
                    }
                }


                if (SelectionStart != null && SelectionEnd != null)
                {
                    var pixelsStart = FrameToPixel((long?)SelectionStart.Value);
                    var pixelsEnd = FrameToPixel((long?)SelectionEnd.Value);
                    var selectionRect = new Rectangle(pixelsStart, 0, pixelsEnd - pixelsStart, timeLineRect.Height);
                    e.Graphics.FillRectangle(brushBackgroundSelected, selectionRect);
                }

                if (SelectionStart != null)
                {
                    var selectionStartRect = PrepareTimeLineRectangle(FrameToPixel((long?)SelectionStart.Value), 5, timeLineRect.Height);
                    e.Graphics.FillRectangle(brushSelectionMarker, selectionStartRect);
                }
                if (SelectionEnd != null)
                {
                    var selectionEndRect = PrepareTimeLineRectangle(FrameToPixel((long?)SelectionEnd.Value), 5, timeLineRect.Height);
                    e.Graphics.FillRectangle(brushSelectionMarker, selectionEndRect);
                }

                var locationMarkerRect = PrepareTimeLineRectangle(FrameToPixel((long?)Position), 3, timeLineRect.Height / 2);
                e.Graphics.FillRectangle(brushPosition, locationMarkerRect);


                e.Graphics.ResetTransform();



                if (HoverPosition != null)
                {
                    var pixel = FrameToPixel(HoverPosition);

                    var hoverLocationMarkerRect = PrepareTimeLineRectangle(pixel, 2, timeLineRect.Height);
                    e.Graphics.FillRectangle(brushHoverPosition, hoverLocationMarkerRect);

                    if (SelectionStart == null)
                    {
                        PaintStringInBox(e.Graphics, Brushes.LightYellow, Brushes.Gray, "middle click to set clip start here", infoAreaRect, pixel);
                    }
                    else if (SelectionEnd == null)
                    {
                        PaintStringInBox(e.Graphics, Brushes.LightYellow, Brushes.Gray, "middle click to set clip end here", infoAreaRect, pixel);
                    }
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

        private Rectangle PrepareTimeLineRectangle(int positionPixels, int thickness, int height)
        {
            return new Rectangle(positionPixels - thickness / 2, 0, thickness, height);
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

        private void VideoCutterTimeline_MouseEnter(object sender, EventArgs e)
        {
        }

        private void VideoCutterTimeline_MouseLeave(object sender, EventArgs e)
        {
            HoverPosition = null;
            
            selectionStartMoveController.ProcessMouseLeave(e);
            selectionEndMoveController.ProcessMouseLeave(e);

            Cursor = Cursors.Default;
        }

        private void VideoCutterTimeline_MouseClick(object sender, MouseEventArgs e)
        {
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
