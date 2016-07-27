using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
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



            cmbWebsites.Items.Clear();
            cmbWebsites.Items.AddRange(enumerateSites());
            if (cmbWebsites.Items.Count > 0)
                cmbWebsites.SelectedIndex = 0;
        }
        private enum eStates
        {
            Start = 2,
            Stop = 4,
            Pause = 6,
        }

        private string lastWebsite;

        /// <summary>
		/// Return a string array of the available website names
		/// </summary>
		/// <returns></returns>
		private string[] enumerateSites()
        {
            List<string> siteNames = new List<string>();
            try
            {
                DirectoryEntry root = getDirectoryEntry("IIS://" + txtServer.Text + "/W3SVC");
                foreach (DirectoryEntry e in root.Children)
                {
                    if (e.SchemaClassName == "IIsWebServer")
                    {
                        siteNames.Add(e.Properties["ServerComment"].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Can't enumerate websites");
                lastWebsite = null;
                txtServer.Focus();
                txtServer.SelectAll();
            }
            return siteNames.ToArray();
        }
        /// <summary>
		/// Return a DirectoryEntry object for path using optional userId and password
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		private DirectoryEntry getDirectoryEntry(string path)
        {
            if (txtUserID.Text.Length > 0)
                return new DirectoryEntry(path, txtUserID.Text, txtPassword.Text);
            else
                return new DirectoryEntry(path);
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
                Increase(0);

                if (!file.Contains(".min.js"))
                    continue;

                if (File.Exists(file))
                {
                    File.Delete(file);
                }
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
                Increase(0);
                if (file.Contains(".min.js"))
                    continue;


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
                Increase(0);
                if (file.Contains("bin")
                    || file.Contains("obj")
                    || file.Contains("debug")
                    || file.Contains("release")
                    || file.Contains("properties"))
                    continue;


                if (file.EndsWith(".cs"))
                {
                    if (File.Exists(file))
                        File.Delete(file);

                }
            }
            MessageBox.Show("It's done");
            ResetProgress();
        }


        private void Increase(double count)
        {
            //double xx = (double)progressBar1.Maximum / count;
            //progressBar1.Value = progressBar1.Value + (int)xx;
            try
            {
                if (progressBar1.Value < progressBar1.Maximum)
                    progressBar1.Value++;
            }
            catch
            {
            }
        }
        private void SetProgress(int maximum, int value)
        {
            progressBar1.Maximum = maximum;
            progressBar1.Value = 0;
        }
        private void ResetProgress()
        {
            progressBar1.Maximum = 0;
            progressBar1.Value = 0;
        }
        /// <summary>
        /// Set up ID and status of selected website
        /// </summary>
        private void cmbWebsites_SelectedIndexChanged(object sender, EventArgs e)
        {
            findWebsite(cmbWebsites.SelectedItem.ToString());
        }
        /// <summary>
		/// Lookup a website by name and update the display for the site ID and status
		/// </summary>
		/// <param name="siteName"></param>
		private void findWebsite(string siteName)
        {
            string site = getSiteIdByName(siteName);
            if (site == null)
            {
                MessageBox.Show("Website '" + siteName + "' not found", "Error");
                showStatus(site);
                return;
            }
            lblSite.Text = site;
            showStatus(site);
        }
        /// <summary>
		/// Show the running/stopped state for the specified site ID
		/// </summary>
		/// <param name="siteId">Numeric site ID</param>
		private void showStatus(string siteId)
        {
            string result = "unknown";
            DirectoryEntry root = getDirectoryEntry("IIS://" + txtServer.Text + "/W3SVC/" + siteId);
            PropertyValueCollection pvc;
            pvc = root.Properties["ServerState"];
            if (pvc.Value != null)
                result = (pvc.Value.Equals((int)eStates.Start) ? "Running" :
                          pvc.Value.Equals((int)eStates.Stop) ? "Stopped" :
                          pvc.Value.Equals((int)eStates.Pause) ? "Paused" :
                          pvc.Value.ToString());
            lblStatus.Text = result + " (" + pvc.Value + ")";
        }
        /// <summary>
		/// Find the siteId for a specified website name. This assumes that the website's
		/// ServerComment property contains the website name.
		/// </summary>
		/// <param name="siteName"></param>
		/// <returns></returns>
		private string getSiteIdByName(string siteName)
        {
            DirectoryEntry root = getDirectoryEntry("IIS://" + txtServer.Text + "/W3SVC");
            foreach (DirectoryEntry e in root.Children)
            {
                if (e.SchemaClassName == "IIsWebServer")
                {
                    if (e.Properties["ServerComment"].Value.ToString().Equals(siteName, StringComparison.OrdinalIgnoreCase))
                    {
                        return e.Name;
                    }
                }
            }
            return null;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            siteInvoke(eStates.Start);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            siteInvoke(eStates.Stop);
        }
        /// <summary>
		/// Given an eStates of "Start" or "Stop", set the state on the currently
		/// selected website
		/// </summary>
		/// <param name="state">Either eStates.Stop or eStates.Start to stop or start the website</param>
		private void siteInvoke(eStates state)
        {
            string site = getSiteIdByName(cmbWebsites.SelectedItem.ToString());
            if (site == null)
            {
                // on the odd chance that someone removed the website since we
                // enumerated the list
                MessageBox.Show("Website '" + cmbWebsites.SelectedItem + "' not found", "Can't " + state + " website");
                showStatus(site);
                return;
            }
            lblSite.Text = site;

            try
            {
                ConnectionOptions connectionOptions = new ConnectionOptions();

                if (txtUserID.Text.Length > 0)
                {
                    connectionOptions.Username = txtUserID.Text;
                    connectionOptions.Password = txtPassword.Text;
                }
                else
                {
                    connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
                }

                ManagementScope managementScope =
                    new ManagementScope(@"\\" + txtServer.Text + @"\root\microsoftiisv2", connectionOptions);

                managementScope.Connect();
                if (managementScope.IsConnected == false)
                {
                    MessageBox.Show("Could not connect to WMI namespace " + managementScope.Path, "Connect Failed");
                }
                else
                {
                    SelectQuery selectQuery =
                        new SelectQuery("Select * From IIsWebServer Where Name = 'W3SVC/" + site + "'");
                    using (ManagementObjectSearcher managementObjectSearcher =
                            new ManagementObjectSearcher(managementScope, selectQuery))
                    {
                        foreach (ManagementObject objMgmt in managementObjectSearcher.Get())
                            objMgmt.InvokeMethod(state.ToString(), new object[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Invalid namespace"))
                {
                    MessageBox.Show("Invalid Namespace Exception" + Environment.NewLine + Environment.NewLine +
                                    "This program only works with IIS 6 and later", "Can't " + state + " website");
                }
                else
                {
                    MessageBox.Show(ex.Message, "Can't " + state + " website");
                }
            }

            showStatus(site);
        }

    }
}
