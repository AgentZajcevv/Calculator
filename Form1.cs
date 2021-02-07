using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;
        double secondNumber = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if((Result.Text == "0") || (isOperationPerformed))
            
                Result.Clear();
            
            isOperationPerformed = false;
            Button button = (Button)sender;
            if ( button.Text == ",")
            {
                if (!Result.Text.Contains(","))
                {
                    Result.Text = Result.Text + button.Text;
                }
            }else
            Result.Text = Result.Text + button.Text;
            secondNumber = double.Parse(Result.Text);
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0 && resultValue != double.Parse(Result.Text))
            {
                equal.PerformClick();
                operationPerformed = button.Text;
                labelOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(Result.Text);
                labelOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void clearentry_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
            resultValue = 0;
            labelOperation.Text = "";
        }

        private void equal_click(object sender, EventArgs e)
        {
            
            switch(operationPerformed)
            {
                case "+":
                    if (resultValue != double.Parse(Result.Text))
                    {
                        Result.Text = (resultValue + double.Parse(Result.Text)).ToString();
                    } else Result.Text = (resultValue + secondNumber).ToString();
                        break;
                case "-":
                    if (resultValue != double.Parse(Result.Text))
                    {
                        Result.Text = (resultValue - double.Parse(Result.Text)).ToString();
                    }
                    else Result.Text = (resultValue - secondNumber).ToString();
                    break;

                case "*":
                    if (resultValue != double.Parse(Result.Text))
                    {
                        Result.Text = (resultValue * double.Parse(Result.Text)).ToString();
                    }
                    else Result.Text = (resultValue * secondNumber).ToString();
                    break;
                case "/":
                    if (resultValue != double.Parse(Result.Text))
                    {
                        Result.Text = (resultValue / double.Parse(Result.Text)).ToString();
                    }
                    else Result.Text = (resultValue / secondNumber).ToString();
                    break;
            }
            resultValue = double.Parse(Result.Text);
            labelOperation.Text = "";
        }
    }
}
