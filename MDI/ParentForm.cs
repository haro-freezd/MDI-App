using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace MDI
{
    public partial class MDIApp : Form
    {
        public MDIApp()
        {
            InitializeComponent();
        }
        //TODO: File filters
        private const string fileFilters = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF)|*JPEG;*.BMP;*.JPG;*.GIF";
        //TODO: Child window counter        

        private void openFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = fileFilters;
            openFileDialog1.FilterIndex = 2;
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
            NewImageForm newImage = new NewImageForm();
            if(newImage.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openFromWebToolStripMenuItem_Click(object sender, EventArgs e) {
            WebForm webform = new MDI.WebForm();
            
            if (webform.ShowDialog() == DialogResult.OK) {
                WebRequest request = WebRequest.Create(webform.GetURL());

                using (WebResponse response = request.GetResponse())

                using (Stream stream = response.GetResponseStream()) {
                    
                    ChildForm child = new ChildForm();
                    child.MdiParent = this;
                    child.Text = openFileDialog1.FileName;
                    child.Image = new Bitmap(Image.FromStream(stream));
                    child.Show(); 
                }

            }
        }

        private void openFromWebToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
