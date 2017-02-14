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
        private const string fileFilters = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG";
        private const string saveFileFilters = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
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
            enableSave();
        }

        private void saveASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = saveFileFilters;
            saveFileDialog1.FilterIndex = 2;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form child = ActiveMdiChild;
                if((child as ChildForm).Image != null)
                {
                    (child as ChildForm).Image.Save(saveFileDialog1.FileName);
                } else if((child as ChildForm).Size != null)
                {
                    Size size = (child as ChildForm).Size;
                    Bitmap bit = new Bitmap(size.Width, size.Height);
                    Graphics g = Graphics.FromImage(bit);
                    g.FillRectangle(Brushes.Blue, 0, 0, size.Width, size.Height);
                    bit.Save(saveFileDialog1.FileName);
                    bit.Dispose();
                }
                
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewImageForm newImage = new NewImageForm();
            if(newImage.ShowDialog() == DialogResult.OK)
            {
                ChildForm child = new ChildForm();
                child.MdiParent = this;
                child.Size = newImage.getSelection();
                child.Show();
            }
            enableSave();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void enableSave()
        {
            if(this.MdiChildren.Length > 0)
            {
                this.saveASToolStripMenuItem.Enabled = true;
                this.saveToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.saveASToolStripMenuItem.Enabled = false;
                this.saveToolStripMenuItem.Enabled = false;
            }
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
    }
}
