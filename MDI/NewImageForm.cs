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
    /// <summary>
    /// Dialog for creating a new image
    /// </summary>
    public partial class NewImageForm : Form
    {
        public NewImageForm()
        {
            InitializeComponent();
        }

        private int sizeSelected;

        /// <summary>
        /// Assigns the size to the sizeSelected for user's choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sizeRadioButton_ClickedChange(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                sizeSelected = 1;
            else if (radioButton2.Checked == true)
                sizeSelected = 2;
            else 
                sizeSelected = 3;
        }

        /// <summary>
        /// Gets the size that user selected
        /// </summary>
        /// <returns></returns>
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
