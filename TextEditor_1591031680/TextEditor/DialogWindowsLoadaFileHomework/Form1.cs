using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Разработайте  приложение,  которое  состоит  из  двух  форм  Первая 
форма  содержит  TextBox  доступный  только  для  чтения  и  две 
кнопки  «загрузить  файл»  и  «редактировать»  Кнопка 
«редактировать»  изначально  неактивна  При  нажатии  на  первую 
кнопку,  открывается  диалог  и  пользователю  предлагают  выбрать 
текстовый файл Выбранный файл загружается в TextBox и кнопка 
«редактировать»  становится  активной  При  нажатии  на  вторую 
кнопку  открывается  вторая  форма  (не  модально),  которая 
содержит  TextBox  доступный  для  редактирования  и  две  кнопки 
«Сохранить»  и  «Отменить»  При  нажатии  на  первую  кнопку 
изменения отображаются в TextBox первой формы 
*/
namespace DialogWindowsLoadaFileHomework
{
    public partial class Form1 : Form
    {
        private LoadForm load;
        private OpenFileDialog OpenFile;
        private TextBox tbtext;
        public TextBox TBTEXT
        {
            get { return tbtext; }
            set { tbtext = value; }
        }
        public Form1()
        {
            InitializeComponent();
            Size = new Size(500, 500);
            Text = "Text Editor";
            BackColor = Color.FromArgb(31, 26, 26);
            ForeColor = Color.FromArgb(227, 60, 57);
            tbtext = new TextBox()
            {
                Location = new Point(10, 10),
                Size = new Size(470, 400),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top,
                ReadOnly = true,
                BackColor = Color.FromArgb(242, 239, 216)

            };
            Controls.Add(tbtext);

            Button btAdd = new Button()
            {
                Location = new Point(10, 420),
                Size = new Size(170, 30),
                Text = "Load file...",
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom,
                Font = new Font("Georgia", 12, FontStyle.Bold)
        };
            btAdd.Click += new EventHandler(ButtonAddClicked);
            Controls.Add(btAdd);

            OpenFile = new OpenFileDialog();
        }

        private void ButtonAddClicked(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(OpenFile.FileName, Encoding.Default))
                    {
                        tbtext.Text = sr.ReadToEnd();
                    }

                    ExtraButtonsInisialization();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n");
                }
            }
        }

        private void ButtonEditClicked(object sender, EventArgs e)
        {
            load = new LoadForm(this)
            {
                Text = "Load Form"
            };
            load.Show();
        }

        private void ExtraButtonsInisialization()
        {
            Button btEdit = new Button()
            {
                Location = new Point(310, 420),
                Size = new Size(170, 30),
                Text = "Edit file...",
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
                Font = new Font("Georgia", 12, FontStyle.Bold)
            };
            btEdit.Click += new EventHandler(ButtonEditClicked);
            Controls.Add(btEdit);

            Button btSaveFile = new Button()
            {
                Location = new Point(190, 420),
                Size = new Size(110, 30),
                Text = "Save file...",
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom|AnchorStyles.Left,
                 Font = new Font("Georgia", 12, FontStyle.Bold)
            };
            btSaveFile.Click += (s,e)=>
            {
               


                try
                {
                    Stream myStream;
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if ((myStream = saveFileDialog1.OpenFile()) != null)
                        {
                            string name = saveFileDialog1.FileName;
                            myStream.Close();
                            using (StreamWriter sw = new StreamWriter(name))
                            {
                                sw.Write(tbtext.Text);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n");
                }
            };
            Controls.Add(btSaveFile);
        }
    }
}
