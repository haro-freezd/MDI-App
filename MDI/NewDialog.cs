using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class NewDialog : Form
    {
        public NewDialog()
        {
            InitializeComponent();
        }

        private int sizeSelected;

        private void sizeRadioButton_ClickedChange(object sender, EventArgs e)
        {
            if (sender.ToString().Equals("640 x 460"))
                sizeSelected = 1;
            else if (sender.ToString().Equals("800 x 600"))
                sizeSelected = 2;
            else
                sizeSelected = 3;
        }

        public Size getSelection()
        {
            if (sizeSelected == 1)
                return new Size(640, 460);
            else if (sizeSelected == 2)
                return new Size(800, 600);
            return new Size(1024, 768);
        }
    }
}
