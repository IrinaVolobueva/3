using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static double ReplaceWithGeometricMean<T>(T a, T b, T c, T d) where T : struct
        {
            dynamic da = a;
            dynamic db = b;
            dynamic dc = c;
            dynamic dd = d;

            double abcd = da * db * dc * dd;
            double geomMean = Math.Round(Math.Pow(abcd, 1.0 / 4), 3);
            return geomMean;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(textBox1.Text) & String.IsNullOrWhiteSpace(textBox2.Text) & String.IsNullOrWhiteSpace(textBox3.Text) & String.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else if (Double.TryParse(textBox1.Text, out double a) & Double.TryParse(textBox2.Text, out double b) & Double.TryParse(textBox3.Text, out double c) & Double.TryParse(textBox4.Text, out double d))
                {
                    if (a <= 0 || b <= 0 || c <= 0 || d <= 0)
                    {
                        MessageBox.Show("Числа должны быть больше 0!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    double sr = ReplaceWithGeometricMean(a, b, c, d);
                    textBox5.Text = $"{sr}";
                }
                else if (UInt32.TryParse(textBox1.Text, out uint a1) & UInt32.TryParse(textBox2.Text, out uint b1) & UInt32.TryParse(textBox3.Text, out uint c1) & UInt32.TryParse(textBox4.Text, out uint d1))
                {
                    if (a <= 0 || b <= 0 || c <= 0 || d <= 0)
                    {
                        MessageBox.Show("Числа должны быть больше 0!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    double sr1 = ReplaceWithGeometricMean(a1, b1, c1, d1);
                    textBox5.Text = $"{sr1}";
                }
                else
                {
                    MessageBox.Show("Неверный формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
