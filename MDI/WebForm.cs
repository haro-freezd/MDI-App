using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI {
    /// <summary>
    /// Form for loading image from web url
    /// </summary>
    public partial class WebForm : Form {
        public WebForm() {
            InitializeComponent();
        }
        
        private String url;

        /// <summary>
        /// Validates the url exists and close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebOpenButton_Click(object sender, EventArgs e) {
            if (webTextBox.Text != null) { 
                url = webTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else {
                MessageBox.Show("Type the URL");
            }
        }

        /// <summary>
        /// Closes this diagram
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebCancelButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        /// <summary>
        /// Gets url for web image
        /// </summary>
        /// <returns></returns>
        public String GetURL() {
            return url;
        }
    }
}
