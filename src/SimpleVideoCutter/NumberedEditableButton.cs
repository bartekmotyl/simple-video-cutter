using System;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    [SupportedOSPlatform("windows")]
    internal class NumberedEditableButton: TableLayoutPanel
    {
        public Button Button { get; private set; }
        public TextBox TextBox { get; private set; }

        public Label Label { get; private set; }

        private bool editMode = false;

        private string caption = string.Empty;
        public bool EditMode
        {
            get { return editMode; }

            set 
            {
                editMode = value;
                this.TextBox.Visible = editMode;
                this.Button.Visible = !editMode;
                this.Caption = this.TextBox.Text;
            }
        }

        public string Caption
        {
            get { return caption; }

            set
            {
                caption = value;
                this.TextBox.Text = caption;
                this.Button.Text = caption;
            }
        }

        public event EventHandler<EventArgs>? ButtonClick;

        public NumberedEditableButton(int number, string caption, int width, int height, ColumnStyle[] columnStyles)
        {
            this.Size = new Size(width, height);
            //this.AutoSize = true;

            this.ColumnStyles.Clear();
            this.ColumnStyles.Add(columnStyles[0]);
            this.ColumnStyles.Add(columnStyles[1]);

            this.Label = new Label
            {
                Text = number.ToString(),
                Anchor = AnchorStyles.Left
            };

            this.Button = new Button
            {
                Dock = DockStyle.Fill,
                Text = caption,
                TextAlign = ContentAlignment.MiddleLeft
            };

            this.Button.Click += this.NumberedEditableButton_ButtonClick;

            this.TextBox = new TextBox
            {
                Dock = DockStyle.Fill,
                Text = caption,
                Visible = false
            };

            this.Controls.AddRange(new Control[] { this.Label, this.Button, this.TextBox });

            this.SetCellPosition(this.Label, new TableLayoutPanelCellPosition(0, 0));
            this.SetCellPosition(this.Button, new TableLayoutPanelCellPosition(1, 0));
            this.SetCellPosition(this.TextBox, new TableLayoutPanelCellPosition(1, 0));
        }


        private void NumberedEditableButton_ButtonClick(object? sender, EventArgs e)
        {
            this.ButtonClick?.Invoke(this, e);
        }
    }
}
