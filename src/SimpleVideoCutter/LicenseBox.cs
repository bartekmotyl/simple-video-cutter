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
    public partial class LicenseBox : Form
    {
        public LicenseBox()
        {
            InitializeComponent();

        }

        private void LicenseBox_Shown(object sender, EventArgs e)
        {
            textBoxLicense.DeselectAll();
        }
    }
}
