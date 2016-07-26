namespace IpeMinifier
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonMinify = new System.Windows.Forms.Button();
            this.buttonBrowseFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxDeleteAfterMinify = new System.Windows.Forms.CheckBox();
            this.checkBoxRenameMinJsToJs = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(431, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path : ";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(267, 130);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(164, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete .min.js and .map files";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonMinify
            // 
            this.buttonMinify.Location = new System.Drawing.Point(46, 130);
            this.buttonMinify.Name = "buttonMinify";
            this.buttonMinify.Size = new System.Drawing.Size(119, 23);
            this.buttonMinify.TabIndex = 3;
            this.buttonMinify.Text = "Minify ";
            this.buttonMinify.UseVisualStyleBackColor = true;
            this.buttonMinify.Click += new System.EventHandler(this.buttonMinify_Click);
            // 
            // buttonBrowseFolder
            // 
            this.buttonBrowseFolder.Location = new System.Drawing.Point(514, 12);
            this.buttonBrowseFolder.Name = "buttonBrowseFolder";
            this.buttonBrowseFolder.Size = new System.Drawing.Size(33, 23);
            this.buttonBrowseFolder.TabIndex = 4;
            this.buttonBrowseFolder.Text = "...";
            this.buttonBrowseFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseFolder.Click += new System.EventHandler(this.buttonBrowseFolder_Click);
            // 
            // checkBoxDeleteAfterMinify
            // 
            this.checkBoxDeleteAfterMinify.AutoSize = true;
            this.checkBoxDeleteAfterMinify.Checked = true;
            this.checkBoxDeleteAfterMinify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteAfterMinify.Location = new System.Drawing.Point(36, 84);
            this.checkBoxDeleteAfterMinify.Name = "checkBoxDeleteAfterMinify";
            this.checkBoxDeleteAfterMinify.Size = new System.Drawing.Size(165, 17);
            this.checkBoxDeleteAfterMinify.TabIndex = 5;
            this.checkBoxDeleteAfterMinify.Text = "Delete .js file after minification";
            this.checkBoxDeleteAfterMinify.UseVisualStyleBackColor = true;
            // 
            // checkBoxRenameMinJsToJs
            // 
            this.checkBoxRenameMinJsToJs.AutoSize = true;
            this.checkBoxRenameMinJsToJs.Checked = true;
            this.checkBoxRenameMinJsToJs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRenameMinJsToJs.Location = new System.Drawing.Point(36, 107);
            this.checkBoxRenameMinJsToJs.Name = "checkBoxRenameMinJsToJs";
            this.checkBoxRenameMinJsToJs.Size = new System.Drawing.Size(144, 17);
            this.checkBoxRenameMinJsToJs.TabIndex = 6;
            this.checkBoxRenameMinJsToJs.Text = "Rename .min.js files to .js";
            this.checkBoxRenameMinJsToJs.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 202);
            this.Controls.Add(this.checkBoxRenameMinJsToJs);
            this.Controls.Add(this.checkBoxDeleteAfterMinify);
            this.Controls.Add(this.buttonBrowseFolder);
            this.Controls.Add(this.buttonMinify);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IPE JS Minifier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonMinify;
        private System.Windows.Forms.Button buttonBrowseFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox checkBoxDeleteAfterMinify;
        private System.Windows.Forms.CheckBox checkBoxRenameMinJsToJs;
    }
}

