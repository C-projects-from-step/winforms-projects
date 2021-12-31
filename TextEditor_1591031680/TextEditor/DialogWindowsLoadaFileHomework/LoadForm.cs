using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogWindowsLoadaFileHomework
{
    public partial class LoadForm : Form
    {
        Form1 parent;
        TextBox tbtextE;
        public LoadForm()
        {
            InitializeComponent();
           
        }

        public LoadForm(Form1 reff)
        {
            InitializeComponent();
            parent = reff;
            Size = new Size(500, 500);
            BackColor = Color.FromArgb(31, 26, 26);
            ForeColor = Color.FromArgb(227, 60, 57);
            tbtextE = new TextBox()
            {
                Location = new Point(10, 10),
                Size = new Size(470, 400),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top,
                Text = parent.TBTEXT.Text,
                BackColor = Color.FromArgb(242, 239, 216)



        };
            Controls.Add(tbtextE);

            Button btSave = new Button()
            {
                Location = new Point(10, 420),
                Size = new Size(170, 30),
                Text = "Save",
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom,
                 Font = new Font("Georgia", 12, FontStyle.Bold)


            };
            Controls.Add(btSave);
            btSave.Click += (s, e) => { parent.TBTEXT.Text = tbtextE.Text;  Close(); } ;

            Button btCancel = new Button()
            {
                Location = new Point(310, 420),
                Size = new Size(170, 30),
                Text = "Cancel",
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
                Font = new Font("Georgia", 12, FontStyle.Bold)

            };
            Controls.Add(btCancel);
            btCancel.Click += (s, e) => Close();




        }
    }
}
