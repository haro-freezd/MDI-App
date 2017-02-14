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
    public partial class NewImageForm : Form
    {
        public NewImageForm()
        {
            InitializeComponent();
        }

        private int sizeSelected;

        private void sizeRadioButton_ClickedChange(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                sizeSelected = 1;
            else if (radioButton2.Checked == true)
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
