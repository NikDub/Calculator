using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Calculator
{

    enum CalcAction
    {
        None,
        Plus,
        Minus,
        Multiplication,
        Division,
    }
    public partial class Form1 : Form
    {
        double operant, memory = 0;
        CalcAction action;

        public Form1()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e) //add 0 
        {
            if (textBox1.Text == "0")
                return;
            textBox1.Text = textBox1.Text + 0;
        }

        private void button18_Click(object sender, EventArgs e) //add , 
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "0,";
                return;
            }

            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text = textBox1.Text + ",";
            }
        }

        private void button13_Click(object sender, EventArgs e) //add 1 
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 1;
        }

        private void button14_Click(object sender, EventArgs e) //add 2 
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 2;
        }

        private void button15_Click(object sender, EventArgs e) //add 3 
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 3;
        }

        private void button9_Click(object sender, EventArgs e) //add 4 
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 4;
        }

        private void button10_Click(object sender, EventArgs e) //add 5 
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 5;
        }

        private void button11_Click(object sender, EventArgs e) //add 6 
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 6;
        }

        private void button5_Click(object sender, EventArgs e) //add 7 
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 7;
        }

        private void button6_Click(object sender, EventArgs e) //add 8 
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 8;
        }

        private void button7_Click(object sender, EventArgs e) //add 9 
        {
            if (textBox1.Text == "0")
                textBox1.Text = "";
            textBox1.Text = textBox1.Text + 9;
        }

        private void calculate()
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = label1.Text;
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                return;
            }
            switch (action)
            {
                case CalcAction.Plus:
                    textBox1.Text = Plus(operant, double.Parse(textBox1.Text));
                    break;
                case CalcAction.Minus:
                    textBox1.Text = Minus(operant, double.Parse(textBox1.Text));
                    break;
                case CalcAction.Multiplication:
                    textBox1.Text = Multipl(operant, double.Parse(textBox1.Text));
                    break;
                case CalcAction.Division:
                    textBox1.Text = Division(operant, double.Parse(textBox1.Text));
                    break;
                default:
                    break;
            }
        }

        private string ChangeAction(String str, CalcAction actionNew)
        {
            action = actionNew;
            str = str.Remove(str.Length - 1, 1);

            switch (actionNew)
            {
                case CalcAction.Plus:
                    return str + "+";
                case CalcAction.Minus:
                    return str + "-";
                case CalcAction.Multiplication:
                    return str + "*";
                case CalcAction.Division:
                    return str + "/";
            }

            return "";
        }

        public string FactorialS(double n)
        {
            if (n < 1)
                return "Недопустимый ввод";

            return Factorial(n).ToString();

        }

        public double Factorial(double n)
        {
            if (n <= 1) return 1;

            return n * Factorial(n - 1);
        }

        public string Plus(double a, double b)
        {
            return (a + b).ToString();
        }

        public string Minus(double a, double b)
        {
            return (a - b).ToString();
        }

        public string Multipl(double a, double b)
        {
            return (a * b).ToString();
        }

        public string Division(double a, double b)
        {
            if (b == 0)
                return "Деление на 0 недопустимо";
            return (a / b).ToString();
        }

        private void button1_Click(object sender, EventArgs e) // action +/- 
        {
            if (textBox1.Text == "")
                return;

            double temp;
            try
            {
                temp = double.Parse(textBox1.Text);
                if(temp.Equals(double.NaN))
                {
                    textBox1.Text = "0";
                    return;
                }
            }
            catch (Exception)
            {
                textBox1.Text = "0";
                return;
            }

            if (temp > 0)
            {
                textBox1.Text = "-" + textBox1.Text;
            }
            else if (temp != 0)
            {
                textBox1.Text = textBox1.Text.Remove(0, 1);
            }
            else
                return;

        }

        private void button4_Click(object sender, EventArgs e) // action + 
        {
            if (action == CalcAction.None)
            {
                if (textBox1.Text == "")
                    return;
               
                try
                {
                    operant = double.Parse(textBox1.Text);
                    textBox1.Text = "0";
                    if (operant.Equals(double.NaN))
                    {
                        textBox1.Text = "0";
                        return;
                    }
                    action = CalcAction.Plus;
                    label1.Text = operant.ToString() + "+";
                }
                catch (Exception)
                {
                    textBox1.Text = "Не верное значение";
                }
            }
            else
            {
                label1.Text = ChangeAction(label1.Text, CalcAction.Plus);
            }
        }

        private void button8_Click(object sender, EventArgs e) // action - 
        {
            if (action == CalcAction.None)
            {
                if (textBox1.Text == "")
                    return;

                try
                {
                    operant = double.Parse(textBox1.Text);
                    textBox1.Text = "0";
                    if (operant.Equals(double.NaN))
                    {
                        textBox1.Text = "0";
                        return;
                    }
                    action = CalcAction.Minus;
                    label1.Text = operant.ToString() + "-";
                }
                catch (Exception)
                {
                    textBox1.Text = "Не верное значение";
                }
            }
            else
            {
                label1.Text = ChangeAction(label1.Text, CalcAction.Minus);
            }
        }

        private void button12_Click(object sender, EventArgs e) // action * 
        {
            if (action == CalcAction.None)
            {
                if (textBox1.Text == "")
                    return;

                try 
                { 
                    operant = double.Parse(textBox1.Text);
                    textBox1.Text = "0";
                    if (operant.Equals(double.NaN))
                    {
                        textBox1.Text = "0";
                        return;
                    }
                    action = CalcAction.Multiplication;
                    label1.Text = operant.ToString() + "*";
                } 
                catch (Exception)
                {
                    textBox1.Text = "Не верное значение";
                }
            }
            else
            {
                label1.Text = ChangeAction(label1.Text, CalcAction.Multiplication);
            }
        }

        private void button16_Click(object sender, EventArgs e) // action / 
        {
            if (action == CalcAction.None)
            {
                if (textBox1.Text == "")
                    return;
                try
                {
                    operant = double.Parse(textBox1.Text);
                    textBox1.Text = "0";
                    if (operant.Equals(double.NaN))
                    {
                        textBox1.Text = "0";
                        return;
                    }
                    action = CalcAction.Division;
                    label1.Text = operant.ToString() + "/";
                }
                catch (Exception)
                {
                    textBox1.Text = "Не верное значение";
                }
            }
            else
            {
                label1.Text = ChangeAction(label1.Text, CalcAction.Division);
            }
        }

        private void button19_Click(object sender, EventArgs e) // action = 
        {
            calculate();
            action = CalcAction.None;
            label1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e) // action C 
        {
            textBox1.Text = "0";
            label1.Text = "";
            action = CalcAction.None;
        }

        private void buttonCE_Click(object sender, EventArgs e) // action CE 
        {
            textBox1.Text = "0";
        }

        private void buttonDrob_Click(object sender, EventArgs e) // action 1/x 
        {
            if (textBox1.Text != "")
                textBox1.Text = (1 / double.Parse(textBox1.Text)).ToString();
        }

        private void buttonPow_Click(object sender, EventArgs e) // action pow 
        {
            if (textBox1.Text != "")
                textBox1.Text = (Math.Pow(double.Parse(textBox1.Text), 2)).ToString();
        }

        private void buttonSqrt_Click(object sender, EventArgs e) // action sqrt 
        {
            if (textBox1.Text != "")
                textBox1.Text = (Math.Sqrt(double.Parse(textBox1.Text))).ToString();
        }

        private void buttonPer_Click(object sender, EventArgs e) // action ! 
        {
            if (textBox1.Text != "") 
            {
                double temp = double.Parse(textBox1.Text);
                if (temp.Equals(double.NaN)) 
                { 
                    textBox1.Text = "Недопустимый ввод";
                    return;
                }
                textBox1.Text = FactorialS(temp);
            }
        }

        private void buttonMplus_Click(object sender, EventArgs e) // memory +
        {
            if (textBox1.Text == "")
                return;
            if (textBox1.Text == "Деление на 0 недопустимо")
            {
                textBox1.Text = "0";
                return;
            }


            if (memory == 0)
            {
                buttonMplus.Text = "M+";
                buttonMC.Enabled = buttonMR.Enabled = buttonMminus.Enabled = true;
            }

            memory += double.Parse(textBox1.Text);
            MemoryLable.Text = "Memory: " + memory.ToString();
        }

        private void buttonMminus_Click(object sender, EventArgs e) // memory -
        {
            if (textBox1.Text == "")
                return;

            memory -= double.Parse(textBox1.Text);
            MemoryLable.Text = "Memory: " + memory.ToString();
        }

        private void buttonMR_Click(object sender, EventArgs e) //memory read
        {
            textBox1.Text = memory.ToString();
        }

        private void buttonMC_Click(object sender, EventArgs e) //memory clear
        {
            buttonMC.Enabled = buttonMR.Enabled = buttonMminus.Enabled = false;
            buttonMplus.Text = "MS";
            memory = 0;
            MemoryLable.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) // action ⌫ 
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    button13_Click(null, null);
                    break;
                case Keys.D1:
                    if (e.Shift)
                        buttonPer_Click(null, null);
                    else
                        button13_Click(null, null);
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    if (!e.Shift)
                        button14_Click(null, null);
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    if (!e.Shift)
                        button15_Click(null, null);
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    if (!e.Shift)
                        button9_Click(null, null);
                    break;
                case Keys.NumPad5:
                case Keys.D5:
                    if (!e.Shift)
                        button10_Click(null, null);
                    break;
                case Keys.NumPad6:
                case Keys.D6:
                    if (!e.Shift)
                        button11_Click(null, null);
                    break;
                case Keys.NumPad7:
                case Keys.D7:
                    if (!e.Shift)
                        button5_Click(null, null);
                    break;
                case Keys.NumPad8:
                    if (!e.Shift)
                        button6_Click(null, null);
                    break;
                case Keys.D8:
                    if (e.Shift)
                        button12_Click(null, null);
                    else
                        button6_Click(null, null);
                    break;
                case Keys.NumPad9:
                case Keys.D9:
                    if (!e.Shift)
                        button7_Click(null, null);
                    break;
                case Keys.NumPad0:
                case Keys.D0:
                    if (!e.Shift)
                        button17_Click(null, null);
                    break;
                case Keys.Decimal:
                    button18_Click(null, null);
                    break;
                case Keys.Oemplus:
                    if (e.Shift)
                        button4_Click(null, null);
                    else
                        button19_Click(null, null);
                    break;
                case Keys.Add:
                    if (!e.Shift)
                        button4_Click(null, null);
                    break;
                case Keys.OemMinus:
                case Keys.Subtract:
                    if (!e.Shift)
                        button8_Click(null, null);
                    break;
                case Keys.Multiply:
                    if (!e.Shift)
                        button12_Click(null, null);
                    break;
                case Keys.Oem5:
                case Keys.Divide:
                    if (!e.Shift)
                        button16_Click(null, null);
                    break;
                case Keys.Enter:
                    if (!e.Shift)
                        button19_Click(null, null);
                    break;
                case Keys.Back:
                    if (!e.Shift)
                        button2_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}
