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
using System.Drawing.Imaging;

/// <summary>
/// Purpose:    Lab06 - Grpahic file viewer, loader and saver.
/// Author:     Harmandeep Mahal, A00914315
///             Dongwon (Shawn) Kim, A00957091
/// Date:       2017-02-14
/// Updated:    2017-02-14
/// Based On:   Assignment critera
/// What the superviosr should know: 
///                             - New file
///                             - Open from file / Web
///                             - Save, Save As
///                             - Exit
///                             - Allignment of child windows
///                                 - Cascade
///                                 - Tile Horizontal
///                                 - Tile Vertical
///                             
/// </summary>
namespace MDI {
    /// <summary>
    /// Parent form for the image create, view, load, save
    /// </summary>
    public partial class MDIApp : Form {
        //TODO: File filters
        private const string fileFilters = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG";
        private const string saveFileFilters = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
        //TODO: Child window counter        
        public static MDIApp Instance { get; set; }


        /// <summary>
        /// Constructor of the app
        /// </summary>
        public MDIApp() {
            InitializeComponent();
            Instance = this;
        }
        /// <summary>
        /// Creates a new image from another diagram
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            NewImageForm newImage = new NewImageForm();
            if (newImage.ShowDialog() == DialogResult.OK) {
                ChildForm child = new ChildForm();
                child.MdiParent = this;
                child.Size = newImage.getSelection();
                child.Show();
            }
            enableSave();
        }

        /// <summary>
        /// Opens the file from local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFromFileToolStripMenuItem_Click(object sender, EventArgs e) {
            openFileDialog.Filter = fileFilters;
            openFileDialog.FilterIndex = 2;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                ChildForm child = new ChildForm();
                child.MdiParent = this;
                child.Text = openFileDialog.FileName;
                child.Image = Image.FromFile(openFileDialog.FileName);
                child.Saved = true;
                child.Show();
            }
            enableSave();
        }

        /// <summary>
        /// Opens the file from Web url
        /// </summary>
        /// <param name="sender"></pasram>
        /// <param name="e"></param>
        private void openFromWebToolStripMenuItem_Click(object sender, EventArgs e) {
            WebForm webform = new MDI.WebForm();

            if (webform.ShowDialog() == DialogResult.OK) {
                WebRequest request = WebRequest.Create(webform.GetURL());

                using (WebResponse response = request.GetResponse())

                using (Stream stream = response.GetResponseStream()) {

                    ChildForm child = new ChildForm();
                    child.MdiParent = this;
                    child.Text = openFileDialog.FileName;
                    child.Image = new Bitmap(Image.FromStream(stream));
                    child.Show();
                }
            }
            enableSave();
        }


        /// <summary>
        /// Saves as the file with different name to the local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveASToolStripMenuItem_Click(object sender, EventArgs e) {

            Form child = ActiveMdiChild;

            if ((child as ChildForm) == null) {
                enableSave();
            }
            
            saveFileDialog.FileName = (child as ChildForm).Text;
            saveFileDialog.Filter = saveFileFilters;
            saveFileDialog.FilterIndex = 2;

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                if ((child as ChildForm).Image != null) {
                    (child as ChildForm).Image.Save(saveFileDialog.FileName);
                    (child as ChildForm).Saved = true;
                } else if ((child as ChildForm).ImageSize != null) {
                    Size size = (child as ChildForm).ImageSize;
                    Bitmap bit = new Bitmap(size.Width, size.Height);
                    Graphics g = Graphics.FromImage(bit);
                    g.FillRectangle(Brushes.Blue, 0, 0, size.Width, size.Height);
                    bit.Save(saveFileDialog.FileName);
                    bit.Dispose();
                    (child as ChildForm).Saved = true;
                }
            }

            enableSave();
        }

        /// <summary>
        /// Saves the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if ((this.ActiveMdiChild as ChildForm).Saved) {
                    enableSave();
                } else {
                    String fileName = (this.ActiveMdiChild as ChildForm).Text;

                    if (fileName == "New Image")
                        saveASToolStripMenuItem_Click(sender, e);
                    else {
                        try {
                            // save to a memorystream
                            MemoryStream mStream = new MemoryStream();
                            (this.ActiveMdiChild as ChildForm).Image.Save(mStream, (this.ActiveMdiChild as ChildForm).Image.RawFormat);

                            // dispose old image
                            (this.ActiveMdiChild as ChildForm).Image.Dispose();

                            // save new image to same filename
                            Image newImage = Image.FromStream(mStream);
                            newImage.Save(fileName);

                        } catch (Exception ex) {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            enableSave();
        }


        /// <summary>
        /// Enable or Disable the both save and save as button
        /// </summary>
        public void enableSave() {
            if (this.MdiChildren.Length > 0) {
                this.saveASToolStripMenuItem.Enabled = true;
                this.saveToolStripMenuItem.Enabled = true;
            } else {
                this.saveASToolStripMenuItem.Enabled = false;
                this.saveToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Arrange child windows in cascade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        /// <summary>
        /// Arranges child windows horizontally
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);

        }

        /// <summary>
        /// Arranges child windows vertically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }
        

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {
            enableSave();
        }

        /// <summary>
        /// Prompts the user to save the images opened in MDI child forms if the images are not already saved. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitForm exit = new ExitForm();
            foreach (Form form in MdiChildren)
            {
                if (!((form as ChildForm).Saved))
                {
                    if (exit.ShowDialog() == DialogResult.OK)
                    {                   
                        saveASToolStripMenuItem_Click(sender, e);
                        form.Dispose();
                    }
                }
            }
            this.Close();
        }
    }
}
