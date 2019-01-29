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
        public event EventHandler<TimelineClickedEventArgs> TimelineClicked;

        public long Length { get; set; }


        private long position = 0;
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
                hoverPosition = value;
                Invalidate();
            }
        }

        private long? selectionStart = null;
        public long? SelectionStart
        {
            get { return selectionStart; }
            set
            {
                if ((value == null && selectionEnd != null) ||  (value != null && selectionEnd != null && value.Value >= selectionEnd.Value))
                    return; 

                selectionStart = value;
                Invalidate();
            }
        }

        private long? selectionEnd = null;
        public long? SelectionEnd
        {
            get { return selectionEnd; }
            set
            {
                if (selectionStart == null || (value != null && value.Value <= selectionStart))
                    return;
                selectionEnd = value;
                Invalidate();
            }
        }

        private Rectangle timeLineRect = default(Rectangle); 

        public VideoCutterTimeline()
        {
            InitializeComponent();
            timeLineRect = ClientRectangle;
        }

        private void VideoCutterTimeline_Paint(object sender, PaintEventArgs e)
        {
            var rect = ClientRectangle;
            e.Graphics.FillRectangle(Brushes.White, rect);
            e.Graphics.FillRectangle(Brushes.LightGray, timeLineRect);

            if (Length != 0)
            {
                if (SelectionStart != null)
                {
                    if (SelectionEnd == null)
                    {
                        var selectionStartRect = PrepareTimeLineRectangle(TimeLinePositionToPixel(SelectionStart.Value), 5);
                        e.Graphics.FillRectangle(Brushes.Navy, selectionStartRect);
                    }
                    else
                    {
                        var pixelsStart = TimeLinePositionToPixel(SelectionStart.Value);
                        var pixelsEnd = TimeLinePositionToPixel(SelectionEnd.Value);
                        var selectionRect = new Rectangle(pixelsStart, 0, pixelsEnd - pixelsStart, timeLineRect.Height);
                        e.Graphics.FillRectangle(Brushes.Navy, selectionRect);
                    }
                }


                float pixelsPerSecond = (float)timeLineRect.Width / Length * 1000.0f;
                float pixelsPerMinute = pixelsPerSecond / 60.0f;

                if (pixelsPerSecond > 3)
                {
                    float position = 0;
                    float endPosition = Length / 1000 * pixelsPerSecond;
                    while (position <= endPosition)
                    {
                        e.Graphics.DrawLine(Pens.Gray, (int)position, 0, (int)position, timeLineRect.Height/2);
                        position += pixelsPerSecond;
                    }
                }

                var locationMarkerRect = PrepareTimeLineRectangle(TimeLinePositionToPixel(Position), 3);
                e.Graphics.FillRectangle(Brushes.Yellow, locationMarkerRect);



                if (HoverPosition != null)
                {
                    var hoverLocationMarkerRect = PrepareTimeLineRectangle(TimeLinePositionToPixel(HoverPosition), 2);
                    e.Graphics.FillRectangle(Brushes.Red, hoverLocationMarkerRect);
                }
            }
        }

        private int TimeLinePositionToPixel(long? time)
        {
            if (time == null)
                return 0;

            return (Length == 0 ? 0 : (int)(((float)time.Value / (float)(Length)) * timeLineRect.Width));
        }

        private Rectangle PrepareTimeLineRectangle(int positionPixels, int thickness)
        {
            return new Rectangle(positionPixels - thickness / 2, 0, thickness, timeLineRect.Height);
        }

        private void VideoCutterTimeline_Resize(object sender, EventArgs e)
        {
            timeLineRect = ClientRectangle;
            Invalidate();
        }


        private void VideoCutterTimeline_MouseMove(object sender, MouseEventArgs e)
        {
            HoverPosition = (Length == 0 ? (long)0 : (long)(e.Location.X / (float)ClientRectangle.Width * (float)Length));

            if (MouseButtons == MouseButtons.Left)
            {
                var clientLocation = e.Location;
                var pos = (Length == 0 ? (long)0 : (long)(clientLocation.X / (float)ClientRectangle.Width * (float)Length));

                TimelineClicked?.Invoke(this, new TimelineClickedEventArgs()
                {
                    ClickedPosition = pos,
                });
            }
        }

        private void VideoCutterTimeline_MouseEnter(object sender, EventArgs e)
        {
        }

        private void VideoCutterTimeline_MouseLeave(object sender, EventArgs e)
        {
            HoverPosition = null;
        }

        private void VideoCutterTimeline_MouseClick(object sender, MouseEventArgs e)
        {
            var clientLocation = e.Location;
            var pos = (Length == 0 ? (long)0 : (long)(clientLocation.X / (float)ClientRectangle.Width * (float)Length));

            if (e.Button == MouseButtons.Left)
            {
                TimelineClicked?.Invoke(this, new TimelineClickedEventArgs()
                {
                    ClickedPosition = pos,
                });
            }
            if (e.Button == MouseButtons.Right)
            {
                if (SelectionStart != null && SelectionEnd != null)
                {
                    SelectionStart = null;
                    SelectionEnd = null;
                }

                if (SelectionStart == null)
                    SelectionStart = pos;
                else
                    SelectionEnd = pos;

                Invalidate();
            }
        }
    }


    public class TimelineClickedEventArgs : EventArgs
    {
        public long ClickedPosition { get; set; }
    }
}
