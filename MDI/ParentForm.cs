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
    public partial class MDIApp : Form
    {
        public MDIApp()
        {
            InitializeComponent();
        }
        //TODO: File filters
        //TODO: Child window counter        

        private void openFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ChildForm child = new ChildForm();
                child.MdiParent = this;
                child.Text = openFileDialog1.FileName;
                child.Image = Image.FromFile(openFileDialog1.FileName);
                child.Show();
            }
        }

        private void saveASToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDialog newImage = new NewDialog();
            if(newImage.ShowDialog() == DialogResult.OK)
            {
                ChildForm child = new ChildForm();
                child.MdiParent = this;
                Size size = newImage.getSelection();                
                Bitmap imageBitmap = new Bitmap(size.Width, size.Height);
                Graphics imageFromBitmap = Graphics.FromImage(imageBitmap);
                imageFromBitmap.FillRectangle(Brushes.Blue, 0, 0, size.Width, size.Height);
                child.Image = new Bitmap(size.Width, size.Height, imageFromBitmap);
                child.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openFromWebToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
