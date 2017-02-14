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
    public partial class WebForm : Form {
        public WebForm() {
            InitializeComponent();
        }
        
        private String url;

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

        private void WebCancelButton_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        public String GetURL() {
            return url;
        }
    }
}
