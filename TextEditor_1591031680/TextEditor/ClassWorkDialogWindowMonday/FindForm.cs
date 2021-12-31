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

namespace ClassWorkDialogWindowMonday
{
    public partial class FindForm : Form
    {
        Form1 parent;
        public FindForm()
        {
            InitializeComponent();
        }

        public FindForm(Form1 form)
        {
            InitializeComponent();
            parent = form;
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                lbCurFolder.Text=fd.SelectedPath;
                foreach (var item in Directory.GetFiles(fd.SelectedPath, tbMask.Text, SearchOption.AllDirectories))
                {
                    listBox1.Items.Add(item);
                    parent.Listt.Add(item);
                }
            }
        }
    }
}
