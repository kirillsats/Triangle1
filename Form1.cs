using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle1
{
    public partial class Form1 : Form
    {

        Button btn;
        TextBox txtA, txtB, txtC, txtH;
        ListView listView1;

        public Form1()
        {

            this.Height = 800;
            this.Width = 900;
            this.Text = "Töö kolmnurgaga";

            // Button
            btn = new Button();
            btn.Text = "Käivitamine";
            btn.Font = new Font("Arial", 28);
            btn.AutoSize = true;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Location = new Point(320, 100);
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderSize = 0; // Убираем границу
            Controls.Add(btn);
            btn.Click += Btn_Click;


            // Label для txtA (Külg 1)
            Label lblA = new Label();
            lblA.Text = "alus:";
            lblA.Location = new Point(220, 200);
            lblA.Font = new Font("Arial", 10);
            Controls.Add(lblA);

            // TextBox - txtA
            txtA = new TextBox();
            txtA.Location = new Point(320, 200);
            txtA.Font = new Font("Arial", 10);
            txtA.Width = 200;
            Controls.Add(txtA); 

            // Label для txtB (Külg 2)
            Label lblB = new Label();
            lblB.Text = "Katet 1:";
            lblB.Location = new Point(220, 240);
            lblB.Font = new Font("Arial", 10);
            Controls.Add(lblB);

            // TextBox - txtB
            txtB = new TextBox();
            txtB.Location = new Point(320, 240);
            txtB.Font = new Font("Arial", 10);
            txtB.Width = 200;
            Controls.Add(txtB); 


            // TextBox - txtC
            txtC = new TextBox();
            txtC.Location = new Point(320, 280);
            txtC.Font = new Font("Arial", 10);
            txtC.Width = 200;
            Controls.Add(txtC);

            // Label для txtC (Külg 3)
            Label lblC = new Label();
            lblC.Text = "Katet 2:";
            lblC.Location = new Point(220, 280); // Положение метки на форме
            lblC.Font = new Font("Arial", 10);
            Controls.Add(lblC);

         


            // listView1
            listView1 = new ListView();
            listView1.Location = new Point(100, 400);
            listView1.Font = new Font("Arial", 10);
            listView1.Width = 400;
            listView1.Height = 200;
            Controls.Add(listView1);

            //button
            Button btnOpenForm = new Button();
            btnOpenForm.Text = "Arvutada poole aluse ";
            btnOpenForm.Location = new Point(600, 100);
            btnOpenForm.Font = new Font("Arial", 12);
            btnOpenForm.AutoSize = true;
            btnOpenForm.FlatStyle = FlatStyle.Flat;
            Controls.Add(btnOpenForm);
            btnOpenForm.Click += BtnOpenForm_Click;

           
        }

        private void BtnOpenForm_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

       

        private void Btn_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            double a, b, c;
            try
            {
                a = Convert.ToDouble(txtA.Text);
                b = Convert.ToDouble(txtB.Text);
                c = Convert.ToDouble(txtC.Text);

                Triangle1 triangle = new Triangle1(a, b, c);

                // Настройка ListView
                listView1.View = View.Details;
                listView1.Columns.Add("Nimi", 150);
                listView1.Columns.Add("Väärtus", 150);

                // Метод для добавления элементов в ListView
                void AddListViewItem(string name, string value)
                {
                    listView1.Items.Add(new ListViewItem(new[] { name, value }));
                }

                // Добавление данных в ListView с помощью метода
                AddListViewItem("külg a", a.ToString());
                AddListViewItem("külg b", b.ToString());
                AddListViewItem("külg c", c.ToString());
                AddListViewItem("Perimetr", triangle.Perimeter().ToString());
                AddListViewItem("Pindala", triangle.Area().ToString());
                AddListViewItem("Kas on olemas?", triangle.ExistTriangle.ToString());
                AddListViewItem("Täpsustaja", $"{triangle.GetSetA}, {triangle.GetSetB}, {triangle.GetSetC}");


            }
            catch (FormatException)
            {
                MessageBox.Show("Palun sisestage andmed õigesti!");
            }
        }
    }
}

// Пример класса Triangle (вам нужно создать класс Triangle с методами Perimeter(), Area(),