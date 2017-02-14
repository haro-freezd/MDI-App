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
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        private Image childImage;

        private Size _size;

        public Size Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                this.AutoScrollMinSize = _size;
            }
        }

        public Image Image
        {
            get
            {
                return childImage;
            }
            set
            {
                childImage = value;
                this.AutoScrollMinSize = childImage.Size;
            }
        }

        private void ChildForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicsObject = e.Graphics;
            if (childImage != null)
                graphicsObject.DrawImage(childImage, 0, 0);
            else if (_size != null)
                graphicsObject.FillRectangle(Brushes.Blue, 0, 0, _size.Width, _size.Height);        
        }
    }
}
