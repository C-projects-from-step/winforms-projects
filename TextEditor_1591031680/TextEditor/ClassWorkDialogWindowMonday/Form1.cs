using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassWorkDialogWindowMonday
{
    public partial class Form1 : Form
    {
        FindForm form;
        private List<string> listt;

        public List<string> Listt
        {
            get { return listt; }
            set { listt = value; }
        }



        public Form1()
        {
            InitializeComponent();
            Listt = new List<string>();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            form = new FindForm(this);
            form.Text = "Files to find.";
            form.Show();
        }
    }
}
