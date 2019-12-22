using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleVideoCutter
{
    public partial class DialogProfileName : Form
    {
        public DialogProfileName(string profileName)
        {
            InitializeComponent();

            this.textBoxProfileName.Text = profileName;
        }

        public string ProfileName
        {
            get
            {
                return this.textBoxProfileName.Text;
            }
        }
    }
}
