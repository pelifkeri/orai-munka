using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WinFormsFileDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnSelectFilesButtonClick(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    listBox1.Items.AddRange(files);
                }
            }
        }

        private void OnOpenFileClick(object sender, EventArgs e)
        {
            var path = (string)listBox1.SelectedItem;
            
            if (path != null)
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
        }
    }
}
