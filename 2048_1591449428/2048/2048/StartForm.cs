using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    [Serializable]
    public partial class StartForm : Form
    {
        Form1 parent;
        public StartForm(Form1 form)
        {
            InitializeComponent();
            parent = form;
            comboBox1.Items.Add("4x4");
            comboBox1.Items.Add("5x5");
            comboBox1.Items.Add("6x6");
            comboBox1.Items.Add("7x7");
            comboBox1.Items.Add("8x8");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 20)
            {
                MessageBox.Show("The name can't be so big. Change it, please.");
                textBox1.Clear();
            }


            if (textBox1.Text != ""&&comboBox1.SelectedIndex!=-1)
            {
               
                parent.Index = comboBox1.SelectedIndex;
                parent.FullName = textBox1.Text;
                Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;


        }
    }
}
