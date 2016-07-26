using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpeMinifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = @"C:\inetpub\wwwroot\app\Areas";





            //}










            //if (File.Exists(args[argc - 1]))
            //{
            //    if (File.GetAttributes(args[argc - 1]) == FileAttributes.ReadOnly)
            //        File.SetAttributes(args[argc - 1], FileAttributes.Normal);
            //}

            //using (var sw = new StreamWriter(args[argc - 1]))
            //{
            //    for (var i = 0; i < argc - 1; ++i)
            //    {
            //        string source = String.Empty;
            //        try
            //        {
            //            source = File.ReadAllText(args[i]);
            //        }
            //        catch (IOException)
            //        {
            //            Console.WriteLine("File \"{0}\" was not found.", args[i]);
            //            continue;
            //        }

            //        sw.WriteLine((new Minifier()).MinifyJavaScript(source));
            //        /* css */
            //        //sw.WriteLine((new Minifier()).MinifyStyleSheet(source, new CssSettings { ColorNames = CssColor.Hex }));
            //    }
            //    sw.Flush();
            //}
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue?", "Delete .min.js min.js.map files", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var basePath = textBox1.Text.Trim();

            var files1 = Directory.GetFiles(basePath, "*.min.js", SearchOption.AllDirectories);
            var files2 = Directory.GetFiles(basePath, "*.min.js.map", SearchOption.AllDirectories);
            var files = files1.ToList().Concat(files2.ToList());
            var count = files.Count();
            ResetProgress();
            SetProgress(count, 0);
            foreach (var file in files)
            {
                if (!file.Contains(".min.js"))
                {
                    Increase(count);
                    continue;
                }

                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                Increase(count);
            }
            MessageBox.Show("It's done"); ResetProgress();
        }

        private void buttonMinify_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue?", "Minify .js files", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var basePath = textBox1.Text.Trim();


            var files = Directory.GetFiles(basePath, "*.js", SearchOption.AllDirectories);

            foreach (var file in files)
            {

                if (file.Contains(".min.js"))
                {
                    Increase(0);
                    continue;
                }


                var fileName = Path.GetFileName(file);
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                var extension = Path.GetExtension(file);
                var path = Path.GetDirectoryName(file);

                var minifiedFileName = path + "\\" + fileNameWithoutExtension + ".min" + extension;
                var count = files.Count();
                ResetProgress();
                SetProgress(count, 0);
                using (var sw = new StreamWriter(minifiedFileName))
                {
                    string source = String.Empty;
                    try
                    {
                        source = File.ReadAllText(file);
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("File \"{0}\" was not found.", fileName);
                        continue;
                    }

                    sw.WriteLine((new Minifier()).MinifyJavaScript(source));
                    /* css */
                    //sw.WriteLine((new Minifier()).MinifyStyleSheet(source, new CssSettings { ColorNames = CssColor.Hex }));
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();





                    if (checkBoxDeleteAfterMinify.Checked && File.Exists(file))
                    {
                        File.Delete(file);
                    }

                    if (checkBoxRenameMinJsToJs.Checked)
                    {
                        var fileName2 = Path.GetFileName(minifiedFileName);
                        var fileNameWithoutExtension2 = Path.GetFileNameWithoutExtension(minifiedFileName);
                        var extension2 = Path.GetExtension(minifiedFileName);
                        var path2 = Path.GetDirectoryName(minifiedFileName);
                        var minifiedContentNotFileName = path2 + "\\" + fileNameWithoutExtension2.Replace(".min", "") + "" + extension2;

                        File.Move(minifiedFileName, minifiedContentNotFileName);
                    }
                    Increase(count);



                }
            }
            MessageBox.Show("It's done"); ResetProgress();
        }

        private void buttonBrowseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;

            }
        }
        private void Increase(double count)
        {
            //double xx = (double)progressBar1.Maximum / count;
            //progressBar1.Value = progressBar1.Value + (int)xx;
            progressBar1.Value++;
        }
        private void SetProgress(int maximum,int value)
        {
            progressBar1.Maximum = maximum;
            progressBar1.Value= 0;
        }
        private void ResetProgress()
        {
            progressBar1.Maximum = 0;
            progressBar1.Value = 0;
        }
        private void buttonDeleteCSharpFiles_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue?", "Delete cs files", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var basePath = textBox1.Text.Trim();


            var files = Directory.GetFiles(basePath, "*.cs", SearchOption.AllDirectories);
            ResetProgress(); var count = files.Count();
            SetProgress(count, 0);
            foreach (var file in files)
            {

                if (file.Contains("bin") 
                    || file.Contains("obj") 
                    || file.Contains("debug")
                    || file.Contains("release")
                    || file.Contains("properties"))
                {
                    Increase(count);
                    continue;
                }


                if (file.EndsWith(".cs"))
                {
                    if (File.Exists(file))
                    File.Delete(file);

                }
                Increase(count);
            }
            MessageBox.Show("It's done");
            ResetProgress();
        }
    }
}
