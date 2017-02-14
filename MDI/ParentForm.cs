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

        private void openFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ChildForm child = new ChildForm();
                child.MdiParent = this;
                child.Text = openFileDialog1.FileName;
                child.Image = new Bitmap(openFileDialog1.FileName);
                child.Show();
            }
        }

        private void saveASToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewImageForm newImage = new NewImageForm();
            if(newImage.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
