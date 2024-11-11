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
    public partial class Form2 : Form
    {
        Button btn;
        TextBox txtA, txtH;
        ListView listView1;
        PictureBox trianglePicture; // Сделано полем класса

        public Form2()
        {
            // Свойства формы
            this.Height = 800;
            this.Width = 900;
            this.Text = "Töö kolmnurgaga";

            // Кнопка
            btn = new Button();
            btn.Text = "Käivitamine";
            btn.Font = new Font("Arial", 28);
            btn.AutoSize = true;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Location = new Point(320, 100);
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;

            Controls.Add(btn);
            btn.Click += Btn_Click;

            // Метка для txtA
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

            // TextBox - txtH
            txtH = new TextBox();
            txtH.Location = new Point(320, 320);
            txtH.Font = new Font("Arial", 10);
            txtH.Width = 200;
            Controls.Add(txtH);

            // Метка для txtH
            Label lblH = new Label();
            lblH.Text = "Kõrgus:";
            lblH.Location = new Point(220, 320);
            lblH.Font = new Font("Arial", 10);
            Controls.Add(lblH);

            // ListView
            listView1 = new ListView();
            listView1.Location = new Point(100, 400);
            listView1.Font = new Font("Arial", 10);
            listView1.Width = 400;
            listView1.Height = 200;
            Controls.Add(listView1);

            // PictureBox для отображения треугольника
            trianglePicture = new PictureBox();
            trianglePicture.Location = new Point(600, 200); // Позиция картинки на форме
            trianglePicture.Size = new Size(200, 200); // Размер картинки
            Controls.Add(trianglePicture);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            double a, ha;
            listView1.Items.Clear();
            try
            {
                a = Convert.ToDouble(txtA.Text);
                ha = Convert.ToDouble(txtH.Text);

                Triangle1 triangle = new Triangle1(a, ha);

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
                AddListViewItem("Perimetr", triangle.Perimeter().ToString());
                AddListViewItem("Pindala", triangle.Area().ToString());
                AddListViewItem("Kas on olemas?", triangle.ExistTriangle1.ToString());

                // Определение типа треугольника
                string triangleType = triangle.GetTriangleType();
                AddListViewItem("Tüüp", triangleType);

                // Обновление картинки в зависимости от типа треугольника
                if (triangleType == "Равносторонний")
                {
                    trianglePicture.Image = Image.FromFile(@"C:\Users\opilane\Source\Repos\Triangle1_\ravnostoron.png"); // путь к картинке
                }
                else if (triangleType == "Равнобедренный")
                {
                    trianglePicture.Image = Image.FromFile(@"C:\Users\opilane\Source\Repos\Triangle1_\ravnobed.png");
                }
                else if (triangleType == "Прямоугольный")
                {
                    trianglePicture.Image = Image.FromFile(@"C:\Users\opilane\Source\Repos\Triangle1_\prjamugol.png");
                }
                else if (triangleType == "Тупоугольный")
                {
                    trianglePicture.Image = Image.FromFile(@"C:\Users\opilane\Source\Repos\Triangle1_\tipougol.png");
                }
                else if (triangleType == "Остроугольный")
                {
                    trianglePicture.Image = Image.FromFile(@"C:\Users\opilane\Source\Repos\Triangle1_\ostrougol.jpg");
                }
                else if (triangleType == "Разносторонний")
                {
                    trianglePicture.Image = Image.FromFile(@"C:\Users\opilane\Source\Repos\Triangle1_\raznostoron.png");
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Palun sisestage andmed õigesti!");
            }
        }
    }
}
