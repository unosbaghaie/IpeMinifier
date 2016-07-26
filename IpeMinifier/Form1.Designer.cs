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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteCSharpFiles = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(431, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path : ";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(40, 94);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(164, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete .min.js and .map files";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonMinify
            // 
            this.buttonMinify.Location = new System.Drawing.Point(40, 65);
            this.buttonMinify.Name = "buttonMinify";
            this.buttonMinify.Size = new System.Drawing.Size(164, 23);
            this.buttonMinify.TabIndex = 3;
            this.buttonMinify.Text = "Minify ";
            this.buttonMinify.UseVisualStyleBackColor = true;
            this.buttonMinify.Click += new System.EventHandler(this.buttonMinify_Click);
            // 
            // buttonBrowseFolder
            // 
            this.buttonBrowseFolder.Location = new System.Drawing.Point(510, 27);
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
            this.checkBoxDeleteAfterMinify.Location = new System.Drawing.Point(17, 19);
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
            this.checkBoxRenameMinJsToJs.Location = new System.Drawing.Point(17, 42);
            this.checkBoxRenameMinJsToJs.Name = "checkBoxRenameMinJsToJs";
            this.checkBoxRenameMinJsToJs.Size = new System.Drawing.Size(144, 17);
            this.checkBoxRenameMinJsToJs.TabIndex = 6;
            this.checkBoxRenameMinJsToJs.Text = "Rename .min.js files to .js";
            this.checkBoxRenameMinJsToJs.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.buttonBrowseFolder);
            this.groupBox1.Location = new System.Drawing.Point(7, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 271);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxDeleteAfterMinify);
            this.groupBox2.Controls.Add(this.buttonMinify);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.checkBoxRenameMinJsToJs);
            this.groupBox2.Location = new System.Drawing.Point(15, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 165);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Javascript";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDeleteCSharpFiles);
            this.groupBox3.Location = new System.Drawing.Point(260, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 165);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "C#";
            // 
            // buttonDeleteCSharpFiles
            // 
            this.buttonDeleteCSharpFiles.Location = new System.Drawing.Point(21, 94);
            this.buttonDeleteCSharpFiles.Name = "buttonDeleteCSharpFiles";
            this.buttonDeleteCSharpFiles.Size = new System.Drawing.Size(164, 23);
            this.buttonDeleteCSharpFiles.TabIndex = 4;
            this.buttonDeleteCSharpFiles.Text = "Delete .cs files";
            this.buttonDeleteCSharpFiles.UseVisualStyleBackColor = true;
            this.buttonDeleteCSharpFiles.Click += new System.EventHandler(this.buttonDeleteCSharpFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 279);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPE JS Minifier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonDeleteCSharpFiles;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

