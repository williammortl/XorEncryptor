namespace XorEncryptor
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourceFile = new System.Windows.Forms.TextBox();
            this.keyText = new System.Windows.Forms.TextBox();
            this.keyFile = new System.Windows.Forms.TextBox();
            this.keyWeb = new System.Windows.Forms.TextBox();
            this.keyType = new System.Windows.Forms.ComboBox();
            this.keyFileBrowse = new System.Windows.Forms.Button();
            this.browseSource = new System.Windows.Forms.Button();
            this.destFile = new System.Windows.Forms.TextBox();
            this.xorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sourceFile
            // 
            this.sourceFile.Location = new System.Drawing.Point(27, 50);
            this.sourceFile.Name = "sourceFile";
            this.sourceFile.Size = new System.Drawing.Size(814, 31);
            this.sourceFile.TabIndex = 0;
            this.sourceFile.TextChanged += new System.EventHandler(this.sourceFile_TextChanged);
            // 
            // keyText
            // 
            this.keyText.Location = new System.Drawing.Point(529, 157);
            this.keyText.Multiline = true;
            this.keyText.Name = "keyText";
            this.keyText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.keyText.Size = new System.Drawing.Size(494, 195);
            this.keyText.TabIndex = 1;
            this.keyText.TextChanged += new System.EventHandler(this.keyText_TextChanged);
            // 
            // keyFile
            // 
            this.keyFile.Location = new System.Drawing.Point(27, 411);
            this.keyFile.Name = "keyFile";
            this.keyFile.Size = new System.Drawing.Size(814, 31);
            this.keyFile.TabIndex = 2;
            this.keyFile.TextChanged += new System.EventHandler(this.keyFile_TextChanged);
            // 
            // keyWeb
            // 
            this.keyWeb.Location = new System.Drawing.Point(27, 321);
            this.keyWeb.Name = "keyWeb";
            this.keyWeb.Size = new System.Drawing.Size(476, 31);
            this.keyWeb.TabIndex = 3;
            this.keyWeb.Text = "http://";
            this.keyWeb.TextChanged += new System.EventHandler(this.keyWeb_TextChanged);
            // 
            // keyType
            // 
            this.keyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyType.FormattingEnabled = true;
            this.keyType.Items.AddRange(new object[] {
            "Text",
            "Web",
            "File"});
            this.keyType.Location = new System.Drawing.Point(27, 157);
            this.keyType.Margin = new System.Windows.Forms.Padding(6);
            this.keyType.Name = "keyType";
            this.keyType.Size = new System.Drawing.Size(476, 33);
            this.keyType.TabIndex = 20;
            this.keyType.SelectedIndexChanged += new System.EventHandler(this.keyType_SelectedIndexChanged);
            // 
            // keyFileBrowse
            // 
            this.keyFileBrowse.Location = new System.Drawing.Point(860, 401);
            this.keyFileBrowse.Name = "keyFileBrowse";
            this.keyFileBrowse.Size = new System.Drawing.Size(163, 50);
            this.keyFileBrowse.TabIndex = 21;
            this.keyFileBrowse.Text = "Browse >>";
            this.keyFileBrowse.UseVisualStyleBackColor = true;
            this.keyFileBrowse.Click += new System.EventHandler(this.keyFileBrowse_Click);
            // 
            // browseSource
            // 
            this.browseSource.Location = new System.Drawing.Point(860, 40);
            this.browseSource.Name = "browseSource";
            this.browseSource.Size = new System.Drawing.Size(163, 50);
            this.browseSource.TabIndex = 22;
            this.browseSource.Text = "Browse >>";
            this.browseSource.UseVisualStyleBackColor = true;
            this.browseSource.Click += new System.EventHandler(this.browseSource_Click);
            // 
            // destFile
            // 
            this.destFile.Location = new System.Drawing.Point(27, 516);
            this.destFile.Name = "destFile";
            this.destFile.Size = new System.Drawing.Size(996, 31);
            this.destFile.TabIndex = 23;
            this.destFile.TextChanged += new System.EventHandler(this.destFile_TextChanged);
            // 
            // xorButton
            // 
            this.xorButton.BackColor = System.Drawing.Color.Lime;
            this.xorButton.Location = new System.Drawing.Point(276, 580);
            this.xorButton.Name = "xorButton";
            this.xorButton.Size = new System.Drawing.Size(517, 161);
            this.xorButton.TabIndex = 24;
            this.xorButton.Text = "Encrypt / Decrypt File >>";
            this.xorButton.UseVisualStyleBackColor = false;
            this.xorButton.Click += new System.EventHandler(this.xorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Source file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Type of key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "Key text:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 25);
            this.label4.TabIndex = 28;
            this.label4.Text = "Web address key (HTTP / HTTPS):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 380);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 29;
            this.label5.Text = "Key file:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 25);
            this.label6.TabIndex = 30;
            this.label6.Text = "Destination file:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1060, 769);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xorButton);
            this.Controls.Add(this.destFile);
            this.Controls.Add(this.browseSource);
            this.Controls.Add(this.keyFileBrowse);
            this.Controls.Add(this.keyType);
            this.Controls.Add(this.keyWeb);
            this.Controls.Add(this.keyFile);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.sourceFile);
            this.Name = "MainWindow";
            this.Text = "Xor Encryptor / Decryptor by William Mortl";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sourceFile;
        private System.Windows.Forms.TextBox keyText;
        private System.Windows.Forms.TextBox keyFile;
        private System.Windows.Forms.TextBox keyWeb;
        private System.Windows.Forms.ComboBox keyType;
        private System.Windows.Forms.Button keyFileBrowse;
        private System.Windows.Forms.Button browseSource;
        private System.Windows.Forms.TextBox destFile;
        private System.Windows.Forms.Button xorButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

