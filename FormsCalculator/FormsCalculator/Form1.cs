using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            ResultBox.ForeColor = Color.Black;
            var res = EvalMathExpression(ResultBox.Text);
            if (res == "∞")
            {
                res = "you can not devide by zero";
                ResultBox.ForeColor = Color.Red;
                MessageBox.Show("You cannot divide by zero");
            }
           
            ResultBox.Text = res;
        }

        // This method evaluates a mathematic expression and returns 
        private string EvalMathExpression(string text)
        {
            var dt = new DataTable();
            try
            {
                var result = dt.Compute(text, "");
                return result.ToString();
            } catch 
            {
                ResultBox.Text = "Invalid expression";
            }

            return "Error";
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            ResultBox.Text = (1.0 / Memory.GetFirst(ResultBox.Text)).ToString();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            double res = Memory.GetFirst(ResultBox.Text);

            ResultBox.Text = Math.Sqrt(res).ToString();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            ResultBox.ForeColor = Color.Black;
            ResultBox.Text = "";
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            ResultBox.Text = ResultBox.Text.Remove(ResultBox.Text.Length - 1);
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            var who = sender as Button;
            ResultBox.Text += who.Text;
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            var str = ResultBox.Text.TrimStart(new Char[] { '0' });
            if (str.Contains("."))
            {
                str.Remove(str.IndexOf("."));
            }
            if (str.Length <= 0) return;
            if (str[0] == '-')
            {
                str = str.Substring(1);
            } else
            {
                str = "-" + str;
            }
            ResultBox.Text = str;
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            var who = sender as Button;
            who.BackColor = Color.LightGray;
            //who.ForeColor = Color.Black;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            var who = sender as Button;
            who.BackColor = Color.Gray;
            //who.ForeColor = Color.White;
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            Memory.Clear(); 
        }

        private void Button24_Click(object sender, EventArgs e)
        {
            ResultBox.Text = "";
            Memory.MemoryStore(ResultBox.Text);
            ResultBox.Text = "";
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            ResultBox.Text = "";
            ResultBox.Text = ResultBox.Text + Memory.MemoryRecall();
        }

        private void Button26_Click(object sender, EventArgs e)
        {
            ResultBox.Text = "";
            Memory.MPlus(ResultBox.Text);
        }
    }
    public static class Memory
    {
        public static double mem1 {get; set; } = 1;

        public static void Clear()
        {
            mem1 = 0;
        }
        public static double MemoryRecall()
        {
            return mem1;
        }

        public static double GetFirst(string txt)
        {
            string res = "";

            for (int i = 0; i < txt.Length; ++i)
            {
                if (!Char.IsNumber(txt[i]) && txt[i] != '-')
                {
                    break;
                }
                res = res + txt[i];
            }
            try
            {
                return double.Parse(res);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        public static void MemoryStore(string txt)
        {
            mem1 = GetFirst(txt);
        }
        public static double MPlus(string txt)
        {
            double first = GetFirst(txt);
            double res = first + mem1;
            mem1 = res;
            return mem1;
        }
    }
}
