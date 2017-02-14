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
    /// Child form which contains the image from local, web, own
    /// </summary>
    public partial class ChildForm : Form {
        
        public ChildForm()
        {
            InitializeComponent();
        }

        private Image childImage;
        private bool saved;
        private Size _size;

        public bool Saved
        {
            get
            {
                return saved;
            }
            set
            {
                saved = value;
            }
        }
        
        public Size ImageSize
        {
            get
            {
                return _size;
            }
            set {
                _size = value;
                this.AutoScrollMinSize = _size;
            }
        }

        public Image Image {
            get {
                return childImage;
            }
            set {
                childImage = value;
            }
        }


        /// <summary>
        /// Draws the image from the user selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicsObject = e.Graphics;
            if (childImage != null)
                graphicsObject.DrawImage(childImage, 0, 0);
            else if (_size != null)
            {
                graphicsObject.FillRectangle(Brushes.Blue, 0, 0, _size.Width, _size.Height);                
            }                       
        }

        /// <summary>
        /// Send this to parent form when it's closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form parent = this.MdiParent;            
        }
    }
}
