using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System;

namespace pr1
{
    public partial class Form1 : Form
    {
        String eventSymbol=" ";
         double FirstOperand = 0;
         double SecondOperand = 0;
           Boolean negative=false;


        void Calculate(string Symbol)
        {
            if (textBox1.Text.IndexOf(Symbol) != textBox1.Text.Length - 1 && textBox1.Text.IndexOf(",") != textBox1.Text.Length - 1)
            {
               if (textBox1.Text[0]=='-' )
                {
                    textBox1.Text = textBox1.Text.Substring(1);
                    if( negative == false) {
                        negative = true;
                    }
                    if(FirstOperand>0 && negative== true)
                    {
                        FirstOperand *= -1;
                    }
                    
                }
                SecondOperand = Double.Parse(textBox1.Text.Substring(textBox1.Text.IndexOf(eventSymbol) + 1));
                switch (eventSymbol)
                {
                    case "+":
                        textBox1.Text = (FirstOperand + SecondOperand).ToString();
                        FirstOperand = Double.Parse(textBox1.Text);
                        break;
                    case "-":
                        textBox1.Text = (FirstOperand - SecondOperand).ToString();
                        FirstOperand = Double.Parse(textBox1.Text);
                        break;
                    case "*":
                        textBox1.Text = (FirstOperand * SecondOperand).ToString();
                        FirstOperand = Double.Parse(textBox1.Text);
                        break;
                    case "/":
                        textBox1.Text = (FirstOperand / SecondOperand).ToString();
                        FirstOperand = Double.Parse(textBox1.Text);
                        break;
                }
                if (Symbol != "=")
                {
                    textBox1.Text += Symbol;
                }
                eventSymbol = Symbol;
                if (Double.Parse(textBox1.Text) >= 0)
                {
                    negative = false;
                }
                else
                {
                    negative = true;
                }
               
            }
        }

        void AddOperand(String opr)
        {
           

            if (textBox1.Text != String.Empty)
            {
                
                
                    if (Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]))
                    {
                        FirstOperand = Double.Parse(textBox1.Text);
                    }
                    else
                    {
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                        FirstOperand = Double.Parse(textBox1.Text);
                    }
                    eventSymbol = opr;
                    textBox1.Text += eventSymbol;
                if (negative == true && eventSymbol=="-")
                {
                    textBox1.Text = "-" + textBox1.Text;
                }

            }
        }

        private bool AutoRun(bool autorun)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (autorun)
            {
                rkApp.SetValue("Calculation", Application.ExecutablePath.ToString());
            }
            if (!autorun)
            {
                rkApp.DeleteValue("Calculation", false);
            }
            if (rkApp.GetValue("Calculation") == null)
                return false;
            else
                return true;
        }




        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text+= "1";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty) { textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1); }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            FirstOperand = 0;
            SecondOperand = 0;
            negative = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text.Contains("+") || textBox1.Text.Contains(eventSymbol) && Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]))
            {
                Calculate("+");
            }
            else
            {
                AddOperand("+");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("/") || textBox1.Text.Contains(eventSymbol) && Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]))
            {
                Calculate("/");
            }
            else
            {
                AddOperand("/");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("*") || textBox1.Text.Contains(eventSymbol) && Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]))
            {
                Calculate("*");
            }
            else
            {
                AddOperand("*");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=String.Empty && textBox1.Text[0] == '-')
            {
                textBox1.Text = textBox1.Text.Substring(1);
            }
            
            if (textBox1.Text.Contains("-") || textBox1.Text.Contains(eventSymbol) && Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]))
            {
                Calculate("-");
            }
            else
            {
                AddOperand("-");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if( textBox1.Text.Contains(eventSymbol) && Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]))
            {
                Calculate("=");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (negative == true || textBox1.Text[0] == '-')
                {
                    negative = false;
                    textBox1.Text = textBox1.Text.Substring(textBox1.Text.IndexOf("-") + 1);

                }
                else
                {
                    negative = true;
                    textBox1.Text = "-" + textBox1.Text;

                }
            }
            
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty) {
                textBox1.Text += "0,";
            }
                if (!textBox1.Text.Contains(","))
                {
                    textBox1.Text += ",";
                }
                if (textBox1.Text.Contains(eventSymbol) && !textBox1.Text.Substring(textBox1.Text.IndexOf(eventSymbol)).Contains(","))
                {
                    textBox1.Text += ",";
                }
                
            
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьВРеестToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey CalculKey = currentUserKey.CreateSubKey("CalculKey");
            CalculKey.SetValue("first operant", FirstOperand);
            CalculKey.SetValue("second operant", SecondOperand);
            CalculKey.SetValue("event symbol", eventSymbol);
            CalculKey.SetValue("negative", negative);
            CalculKey.SetValue("text box", textBox1.Text);
        }

        private void извлечьИзРеестраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey CalculKey = currentUserKey.CreateSubKey("CalculKey");
            FirstOperand =Double.Parse( CalculKey.GetValue("first operant").ToString());
            SecondOperand = Double.Parse(CalculKey.GetValue("second operant").ToString());
            eventSymbol = CalculKey.GetValue("event symbol").ToString();
            negative = Convert.ToBoolean(CalculKey.GetValue("negative").ToString());
            textBox1.Text= CalculKey.GetValue("text box").ToString();
        }

        private void записатьВАвтозагрузкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoRun(true);
        }

        private void удалитьИзАвтозагрузкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoRun(false);
        }
    }
}
