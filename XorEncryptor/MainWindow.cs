namespace XorEncryptor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using XorEncryptionLibrary;

    /// <summary>
    /// The Main Windows
    /// </summary>
    public partial class MainWindow : Form
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.sourceFile.Text = String.Empty;
            this.keyType.SelectedIndex = 0;
            this.xorButton.Enabled = false;
        }

        /// <summary>
        /// When the source file changes
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void sourceFile_TextChanged(object sender, EventArgs e)
        {
            this.XorButtonEnabled();
        }

        /// <summary>
        /// When the key time changes
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void keyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.keyType.SelectedItem.ToString().Trim())
            {
                case "Text":
                {
                    this.keyText.Enabled = true;
                    this.keyWeb.Enabled = false;
                    this.keyFile.Enabled = false;
                    this.keyFileBrowse.Enabled = false;
                    break;
                }
                case "Web":
                {
                    this.keyText.Enabled = false;
                    this.keyWeb.Enabled = true;
                    this.keyFile.Enabled = false;
                    this.keyFileBrowse.Enabled = false;
                    break;
                }
                case "File":
                {
                    this.keyText.Enabled = false;
                    this.keyWeb.Enabled = false;
                    this.keyFile.Enabled = true;
                    this.keyFileBrowse.Enabled = true;
                    break;
                }
            }
            this.XorButtonEnabled();
        }

        /// <summary>
        /// When the destFile changes
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void destFile_TextChanged(object sender, EventArgs e)
        {
            this.XorButtonEnabled();
        }

        /// <summary>
        /// When the key file changes
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void keyFile_TextChanged(object sender, EventArgs e)
        {
            this.XorButtonEnabled();
        }

        /// <summary>
        /// When the web key changes
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void keyWeb_TextChanged(object sender, EventArgs e)
        {
            this.XorButtonEnabled();
        }

        /// <summary>
        /// When the text key changes
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void keyText_TextChanged(object sender, EventArgs e)
        {
            this.XorButtonEnabled();
        }

        /// <summary>
        /// Look for a source file
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void browseSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files (.*)|*.*";
            dlg.FilterIndex = 0;
            dlg.Multiselect = false;
            dlg.InitialDirectory = (this.sourceFile.Text.Trim() == String.Empty) ? Environment.CurrentDirectory : Path.GetDirectoryName(this.sourceFile.Text);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.sourceFile.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Look for a key file
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void keyFileBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files (.*)|*.*";
            dlg.FilterIndex = 0;
            dlg.Multiselect = false;
            dlg.InitialDirectory = (this.keyFile.Text.Trim() == String.Empty) ? Environment.CurrentDirectory : Path.GetDirectoryName(this.keyFile.Text);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.keyFile.Text = dlg.FileName;
            }
        }

        /// <summary>
        /// Xor the file with the selected key
        /// </summary>
        /// <param name="sender">caused the event</param>
        /// <param name="e">event params</param>
        private void xorButton_Click(object sender, EventArgs e)
        {

            // var init
            byte[] key = null;

            // load the key
            switch (this.keyType.SelectedItem.ToString().Trim())
            {
                case "Text":
                {
                    key = Encoding.ASCII.GetBytes(this.keyText.Text.Trim());
                    break;
                }
                case "Web":
                {
                    key = XorEncryptionMethods.GetWebPage(this.keyWeb.Text.Trim());
                    break;
                }
                case "File":
                {
                    key = File.ReadAllBytes(this.keyFile.Text.Trim());
                    break;
                }
            }

            // xor
            Boolean success = XorEncryptionMethods.XorFile(this.sourceFile.Text, key, this.destFile.Text.Trim());
        
            // handle success failure
            if (success == true)
            {
                MessageBox.Show("The file was Xor encrypted / decrypted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("An error occurred while Xor encrypting / decrypting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Updates whether or not the xorButton is enabled
        /// </summary>
        private void XorButtonEnabled()
        {

            // var init
            Boolean xorButtonEnabled = false;

            // button enabled logic
            if ((this.sourceFile.Text.Trim() != String.Empty) && (this.destFile.Text.Trim() != String.Empty))
            {
                switch (this.keyType.SelectedItem.ToString().Trim())
                {
                    case "Text":
                    {
                        xorButtonEnabled = (this.keyText.Text.Trim() != String.Empty);
                        break;
                    }
                    case "Web":
                    {
                        xorButtonEnabled = (this.keyWeb.Text.Trim() != String.Empty);
                        break;
                    }
                    case "File":
                    {
                        xorButtonEnabled = (this.keyFile.Text.Trim() != String.Empty);
                        break;
                    }
                }
            }

            // set enabled status
            this.xorButton.Enabled = xorButtonEnabled;
        }
    }
}
