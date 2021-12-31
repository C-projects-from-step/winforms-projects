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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace _2048
{
    [Serializable]
    public partial class Form1 : Form
    {
        private List<Label> tile;
        int number = 0, occurence = 0;
        int numberofCells = 4;
        int points = 0;

        public int Index { get; set; }
        public string FullName { get; set; }

        Label text;
        Random rand;
        TableLayoutPanel panel;
        ComboBox combo;
        StartForm start;
        Label records;
        List<Person> people;
        Label instruction;



        public Form1()
        {
            start = new StartForm(this);
           start.ShowDialog();

            if (FullName == null)
            {
                return;
            }


            people = new List<Person>();
            rand = new Random();
            tile = new List<Label>();
            InitializeComponent();
            Text = "2048";
            BackColor = Color.FromArgb(143,123,69);
            number = rand.Next(0, (numberofCells * numberofCells) + 1);

           

            text = new Label
            {
                Text = $"Points: {points}",
                Location = new Point(475, 10),
                Size = new Size(80, 50),
                Font = new Font("GAlacia", 12, FontStyle.Italic | FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
                

            };

            records = new Label {

               
                Location = new Point(475, 80),
                Size = new Size(116, 150),
                BackColor = Color.FromArgb(240,205,108),
                Font = new Font("GAlacia", 8, FontStyle.Italic | FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Right 

            };
            Controls.Add(records);

            instruction = new Label {
                Location = new Point(475, 300),
                Size = new Size(116, 80),
                BackColor = Color.FromArgb(240, 205, 108),
                Font = new Font("GAlacia", 8, FontStyle.Italic | FontStyle.Bold),
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom
            };
            Controls.Add(instruction);

            if (Index == 0)
                instruction.Text = "You need to get only 2048 points.";
            else if (Index==1)
                instruction.Text = "You need to get only 8192 points.";
            else if (Index==2)
                instruction.Text = "You need to get only 32768 points.";
            else if (Index==3)
                instruction.Text = "You need to get only 65536 points.";
            else if (Index==4)
                instruction.Text = "You need to get only 1048576 points.";
           


            Controls.Add(text);
            ReadFromFile();
           
            NewGame(4 + Index);
            



        }

        private void AddTile()
        {
            occurence++;
            do
            {
                number = rand.Next(0, numberofCells * numberofCells);
                if (tile[number].Text == "")
                {
                    if (occurence == 9)
                    {
                        tile[number].Text = "4";
                        occurence = 0;
                    }
                    else tile[number].Text = "2";

                    break;
                }

            } while (true);




            if (Index == 0)
                if (tile.Where(i => i.Text == "2048").Count() > 0)
                {
                    MessageBox.Show("you won!");
                    WritetoFile();
                }
                else if (Index == 1)
                    if (tile.Where(i => i.Text == "8192").Count() > 0)
                    { MessageBox.Show("you won! Try a higher level. Congratulations!!!"); WritetoFile(); }
                    else if (Index == 2)
                        if (tile.Where(i => i.Text == "32768").Count() > 0)
                        { MessageBox.Show("you won! Try a higher level. Congratulations!!!"); WritetoFile(); }
                        else if (Index == 3)
                            if (tile.Where(i => i.Text == "65536").Count() > 0)
                            { MessageBox.Show("you won! Try a higher level. Congratulations!!!"); WritetoFile(); }
                            else if (Index == 4)
                                if (tile.Where(i => i.Text == "1048576").Count() > 0)
                                { MessageBox.Show("you won! Try a higher level. Congratulations!!!"); WritetoFile(); }


            if (tile.Where(i => i.Text != "").Count() == numberofCells * numberofCells)
            { MessageBox.Show("You lost the game"); WritetoFile(); }
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {

            int m = 0;
            bool f = true;
            if (e.KeyCode == Keys.Left)
            {
                while (f == true)
                {
                    f = false;
                    for (int i = 0; i < (numberofCells * numberofCells) - 1; i++)
                    {
                        if ((i + 1) % numberofCells != 0)
                        {
                            if (tile[i].Text == tile[i + 1].Text && tile[i].Text != "")
                            {
                                m = (Convert.ToInt32(tile[i].Text) * 2);
                                points += m;
                                tile[i].Text = m.ToString();
                                tile[i + 1].Text = "";
                                f = true;
                            }


                            if (tile[i].Text == "" && tile[i + 1].Text != "")
                            {
                                tile[i].Text = tile[i + 1].Text;
                                tile[i + 1].Text = "";
                                f = true;
                            }

                        }
                    }
                }

            }

            if (e.KeyCode == Keys.Right)
            {


                while (f == true)
                {
                    f = false;
                    for (int i = (numberofCells * numberofCells); i > 0; i--)
                    {
                        if ((i) % numberofCells != 0)
                        {
                            if (tile[i].Text == tile[i - 1].Text && tile[i].Text != "")
                            {
                                m = (Convert.ToInt32(tile[i - 1].Text) * 2);
                                points += m;
                                tile[i].Text = m.ToString();
                                tile[i - 1].Text = "";
                                f = true;
                            }

                            if (tile[i].Text == "" && tile[i - 1].Text != "")
                            {
                                tile[i].Text = tile[i - 1].Text;
                                tile[i - 1].Text = "";
                                f = true;
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Down)
            {


                while (f == true)
                {
                    f = false;
                    for (int i = (numberofCells * numberofCells) - 1; i > 0; i--)
                    {
                        if (i >= numberofCells)
                        {
                            if (tile[i].Text == tile[i - numberofCells].Text && tile[i].Text != "")
                            {
                                m = (Convert.ToInt32(tile[i].Text) * 2);
                                points += m;
                                tile[i].Text = m.ToString();
                                tile[i - numberofCells].Text = "";
                                f = true;
                            }

                            if (tile[i].Text == "" && tile[i - numberofCells].Text != "")
                            {
                                tile[i].Text = tile[i - numberofCells].Text;
                                tile[i - numberofCells].Text = "";
                                f = true;
                            }
                        }
                    }
                }

            }

            if (e.KeyCode == Keys.Up)
            {
                while (f == true)
                {
                    f = false;
                    for (int i = 0; i < (numberofCells * numberofCells); i++)
                    {
                        if (i < (numberofCells * numberofCells - numberofCells))
                        {
                            if (tile[i].Text == tile[i + numberofCells].Text && tile[i].Text != "")
                            {
                                m = (Convert.ToInt32(tile[i].Text) * 2);
                                points += m;
                                tile[i].Text = m.ToString();
                                tile[i + numberofCells].Text = "";
                                f = true;
                            }

                            if (tile[i].Text == "" && tile[i + numberofCells].Text != "")
                            {
                                tile[i].Text = tile[i + numberofCells].Text;
                                tile[i + numberofCells].Text = "";
                                f = true;
                            }
                        }
                    }
                }

            }

            AddTile();
            PaintTiles();
            text.Text = $"Points: {points}";

        }

        private void PaintTiles()
        {
            for (int i = 0; i < numberofCells * numberofCells; i++)
            {
                if (tile[i].Text == "")
                    tile[i].BackColor = Color.FromArgb(204, 192, 179);
                else if (tile[i].Text == "2")
                {
                    tile[i].BackColor = Color.FromArgb(238, 228, 218);
                    tile[i].ForeColor = Color.FromArgb(119, 110, 101);
                }
                else if (tile[i].Text == "4")
                {
                    tile[i].BackColor = Color.FromArgb(237, 224, 200);
                    tile[i].ForeColor = Color.FromArgb(119, 110, 101);
                }
                else if (tile[i].Text == "8")
                {
                    tile[i].BackColor = Color.FromArgb(242, 177, 121);
                    tile[i].ForeColor = Color.FromArgb(249, 246, 242);
                }
                else if (tile[i].Text == "16")
                {
                    tile[i].BackColor = Color.FromArgb(245, 149, 99);
                    tile[i].ForeColor = Color.FromArgb(249, 246, 242);
                }
                else if (tile[i].Text == "32")
                {
                    tile[i].BackColor = Color.FromArgb(246, 124, 95);
                    tile[i].ForeColor = Color.FromArgb(249, 246, 242);
                }
                else if (tile[i].Text == "64")
                {
                    tile[i].BackColor = Color.FromArgb(246, 94, 59);
                    tile[i].ForeColor = Color.FromArgb(249, 246, 242);
                }
                else if (tile[i].Text == "128")
                {
                    tile[i].BackColor = Color.FromArgb(237, 207, 114);
                    tile[i].ForeColor = Color.FromArgb(249, 246, 242);
                   

                }
                else if (tile[i].Text == "256")
                {
                    tile[i].BackColor = Color.FromArgb(237, 204, 97);
                    tile[i].ForeColor = Color.FromArgb(249, 246, 242);
                   
                }
                else if (tile[i].Text == "512")
                {
                    tile[i].BackColor = Color.FromArgb(237, 200, 80);
                    tile[i].ForeColor = Color.FromArgb(249, 246, 242);
                   
                }
                else if (tile[i].Text == "1024")
                {
                    tile[i].BackColor = Color.FromArgb(237, 197, 63);
                    tile[i].ForeColor = Color.FromArgb(249, 246, 242);
                   
                }
                else if (tile[i].Text == "2048")
                {
                    tile[i].BackColor = Color.FromArgb(237, 194, 46);
                    tile[i].ForeColor = Color.FromArgb(249, 246, 242);
                    
                }
                else
                {
                    tile[i].BackColor = Color.FromArgb(62, 57, 51);
                    tile[i].ForeColor = Color.FromArgb(249, 246, 242);
                }

                if (tile[i].Text != "" && (Convert.ToInt32(tile[i].Text)) < 1000 && (Convert.ToInt32(tile[i].Text)) > 65)
                    tile[i].Font = new Font("Arial", 18, FontStyle.Bold);
                else if (tile[i].Text != "" && (Convert.ToInt32(tile[i].Text)) < 9999 && (Convert.ToInt32(tile[i].Text)) > 1000)
                    tile[i].Font = new Font("Arial", 15, FontStyle.Bold);
                else if (tile[i].Text != "" && (Convert.ToInt32(tile[i].Text)) < 99999 && (Convert.ToInt32(tile[i].Text)) > 10000)
                    tile[i].Font = new Font("Arial", 11, FontStyle.Bold);
                else if((tile[i].Text != ""  && (Convert.ToInt32(tile[i].Text)) > 100000))
                    tile[i].Font = new Font("Arial", 9, FontStyle.Bold);
               




        }
        }

        private void NewGame(int n)
        {
           
            numberofCells = n;
            panel = new TableLayoutPanel
            {
                ColumnCount = numberofCells,
                RowCount = numberofCells,
                Size = new Size(473, 473),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom

            };

            Controls.Add(panel);

            for (int i = 0; i < numberofCells; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            }

            for (int i = 0; i < numberofCells * numberofCells; i++)
            {
                tile.Add(new Label()
                {

                    Font = new Font("Arial", 20, FontStyle.Bold),
                    BorderStyle = BorderStyle.Fixed3D,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(205, 193, 180),
                    ForeColor = Color.SaddleBrown,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0),
                   
                    


                });

                if (number == i)
                {
                    tile[i].Text = (i % 2 == 0 ? 2 : 4).ToString();

                }

                panel.Controls.Add(tile[i]);
            }

            AddTile();
            PaintTiles();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WritetoFile();
        }

        private void WritetoFile()
        {
            DialogResult res;
            res = MessageBox.Show("Write your results?", "Saving...", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes)
            {
                try
                {
                    Person person = new Person();
                    person.Name = FullName;
                    person.Points = points;
                    person.Board = (4 + Index).ToString();
                    people.Add(person);


                    var bf = new BinaryFormatter();
                    using (var fs = File.Create("records.bin"))
                    {
                        bf.Serialize(fs, people);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n");
                }
            }
        }

        private void ReadFromFile()
        {
            try
            {
                var bf = new BinaryFormatter();
                using (var fs = File.OpenRead("records.bin"))
                {
                    people = (List<Person>)bf.Deserialize(fs);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n");
            }

            IEnumerable<Person> query = people.OrderByDescending(x => x.Points);
            records.Text = "Records: ";
            int m = 0;
            foreach (var item in query)
            {
                if (item.Board == (Index + 4).ToString())
                {
                    records.Text += item.ToString() + '\n';
                    m++;
                }
                if (m == 5)
                    break;
            }
        }
    }
}
