// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoinIndex
{
    public partial class Form1 : Form
    {
        public char[] cmp = {' ', 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к',
                                'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х',
                                'ц', 'ч', 'ш', 'щ', 'ы', 'ь', 'э', 'ю', 'я' };

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter k", "Debil");
                return;
            }

            button1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Text = "";

            int k = Convert.ToInt32(textBox3.Text);
            char[] str = textBox1.Text.ToArray();
            for(int i = 0; i<str.Length; i++)
            {
                if (i % k == 0)
                {
                    textBox2.Text +=Convert.ToString(str[i]);
                }
            }
            int L = textBox2.Text.Length;

            char[] str2 = textBox2.Text.ToArray();
            double[] count = new double[cmp.Length];
            double[] indexes = new double[cmp.Length];
            double result;

            for (int j = 0; j < cmp.Length; j++)
            {
                count[j] = 0;
                foreach (char c in str2)
                {
                    if (c == cmp[j])
                    {
                        count[j]++;
                    }

                }
                indexes[j] = (count[j] * (count[j] - 1)) / (L * (L - 1));
                if (cmp[j] == ' ')
                {
                    textBox4.Text = "пробел" + "-" + count[j] + " "; ;
                    textBox5.Text = "пробел" + "-" + indexes[j] + " ";
                }
                else
                {
                    textBox4.Text += cmp[j] + "-" + count[j] + " ";
                    textBox5.Text += cmp[j] + "-" + indexes[j] + " ";
                }
            }
            result = indexes.Sum();
            textBox6.Text = Convert.ToString(Math.Round(result, 5));
            textBox6.Visible = true;
            }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter k", "Debil");
                return;
            }
            button2.Enabled = false;

            char[] s1 = textBox1.Text.ToArray();
            int K = Convert.ToInt32(textBox3.Text);
            textBox7.Text = textBox1.Text.Remove(0, K);
            string temp = "";
            for (int i = 0; i < K; i++)
            {
                temp += s1[i];
                if (i == K - 1)
                {
                    textBox7.Text += temp;
                }

            }
            char[] s2 = textBox7.Text.ToArray();
            double coin = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i])
                {
                    coin++;
                }
            }
            double N = coin / s1.Length;
            textBox8.Text = Convert.ToString(coin) + "-совпадений, доля совпадений: " + Convert.ToString(Math.Round(N, 5));
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if ((textBox9.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("Enter key's symbol position or/and key","Debil");
                return;
            }
            textBox10.Text = "";

                int N = Convert.ToInt32(textBox9.Text);
                char[] str1 = textBox1.Text.ToArray();
                int K = Convert.ToInt32(textBox3.Text);

            if (N > K)
            {
                MessageBox.Show("Key's symbol position couldn't be longer than key", "Debil");
                return;
            }
            for (int i = N; i <= str1.Length;)
            {
                if (i == N)
                {
                    textBox10.Text = Convert.ToString(str1[i - 1]);
                    i += K;
                }
                textBox10.Text += Convert.ToString(str1[i - 1]);
                i += K;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private string Decode(string input, string keyword)
        {
            int B = cmp.Length;

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(cmp, symbol) + B - Array.IndexOf(cmp, keyword[keyword_index])) % B;

                result += cmp[p];

                keyword_index++;

                if ((keyword_index % keyword.Length) == 0 )
                {
                    keyword_index = 0;
                }
            }

            return result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox11.Text = Decode(textBox1.Text, textBox12.Text);
        }
    }
}

