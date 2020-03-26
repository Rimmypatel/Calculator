using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cal_c_rrjs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
       public string no = "";
      
        public static float Evaluate(string expression)
        {

            char[] Arr = expression.ToCharArray(); 
            int number = 0;
            bool result = true;
            Stack<float> a = new Stack<float>(); 
            Stack<char> char_a = new Stack<char>();
            for (int i = 0; i < Arr.Length; ++i)
            {
                if (Arr[i] != ' ')
                {
                    if (Arr[i] >= '0' && Arr[i] <= '9')
                    {
                        StringBuilder s = new StringBuilder(); 
                        while (i < Arr.Length && ((Arr[i]>= '0' && Arr[i] <= '9') || Arr[i] == '.'))
                        s.Append(Arr[i++]);
                        --i;
                        a.Push((float)Convert.ToDouble(s.ToString()));
                        ++number;
                    }
                    else if (Arr[i] == '(') char_a.Push(Arr[i]);
                    else if (Arr[i] == ')')
                    {
                        if (char_a.Contains('('))
                        {
                            while (char_a.Peek() != '(')
                            {
                                --number;
                                if (number >= 1)
                                {

                                    a.Push(arith_op(char_a.Pop(), a.Pop(), a.Pop()));
                                }
                                else
                                {
                                    result = false; 
                                    break;
                                }    
                            }
                            int num2 = (int)char_a.Pop();
                        }
                        else
                        {
                            result = false;
                            break;

                        }
                    }
                    
    

                else if (Arr[i] == '+' || Arr[i] == '-' || Arr[i] == '*' || Arr[i] == '/')
                    {
                        while (char_a.Count > 0 && pior(Arr[i], char_a.Peek()))
                        {
                            --number;
                            if (number >= 1)
                            {

                                a.Push(arith_op(char_a.Pop(), a.Pop(), a.Pop()));
                            }
                            else
                            {
                            result = false; 
                                break;
                            }
                        }
                        char_a.Push(Arr[i]);
                    }
                }
            }
            while (char_a.Count > 0)
            {
                --number;
                if (number >= 1)
                {

                    a.Push(arith_op(char_a.Pop(), a.Pop(), a.Pop()));
                }
                else
                {
                    result = false; break;
                }
            }
            if (number >= 1 && a.Count == 1) 
                return a.Pop();
            if (!result)
            {
                int num2 = (int)MessageBox.Show("Invalid Expression");
                return 0;
            }

            int num3 = (int)MessageBox.Show("Operator not found");
            return 0;
        }

       


public static bool pior(char op1, char op2)
        {
            return op2 != '(' && op2 != ')' && (op1 != '*' && op1 != '/' || op2 != '+' && op2 != '-');
        }

        public static float arith_op(char op, float b, float a)
        {
            int num4;
            switch (op)
            {
                case '*':
                    return a * b;
                case '+':
                    return a + b;
            
                case '-':
                    return a - b;
                case '/':
                    if (b == 0)


                        num4 = (int)MessageBox.Show("Can't divide by zero");

                    return a / b;
                default:
                    return 0;
            }
        }


        private void BUTTON7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void BUTTON8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void BUTTON9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void BUTTON4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void BUTTON5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void BUTTON6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void BUTTON1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void BUTTON2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void BUTTON3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void BUTTON0_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }

        private void BUTTON11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "+";
        }

        private void BUTTON13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "(";
        }

        private void BUTTON14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ")";
        }

        private void BUTTON12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "-";
        }

        private void BUTTON15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "*";
        }

        private void BUTTON16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "/";
        }

        private void buttondel_Click(object sender, EventArgs e)
        {
            no = textBox1.Text; 
            int n = no.Length;
            textBox1.Text = (no.Substring(0, n - 1));
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            lblResult.Text = "Ans";
        }

        private void BUTTON_eqqual_Click(object sender, EventArgs e)
        {
            this.lblResult.Text = cal_c_rrjs.Form1.Evaluate(this.textBox1.Text).ToString();
        }
    }
}
