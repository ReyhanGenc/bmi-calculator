using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kitle_indeksi
{
    class window : Form
    {
        public window()
        {
            Width=500;
            Height = 400;

            Text = "body mass index";

            elements();
        }

        public void elements()
        {
            calculate = new Button();
            Controls.Add(calculate);
            calculate.Text = "calculate";
            calculate.SetBounds(100, 180 , 100 , 30 );
            calculate.Click +=calculate_click;

            reset = new Button();
            Controls.Add(reset);
            reset.Text = "reset";
            reset.SetBounds(260, 180, 100, 30);
            reset.Click += reset_click;

            message = new Label();
            Controls.Add(message);
            message.Text = "--- Please enter your weight and height ---";
            message.SetBounds(100, 50, 273,20);

            inputName = new Label();
            Controls.Add(inputName);
            inputName.Text = "weight (kg):" + String.Concat(Enumerable.Repeat(" ", 22)) + "height (m):";
            inputName.SetBounds(100, 105, 300, 20);

            weight = new TextBox();
            height = new TextBox();

            Controls.Add(weight);
            Controls.Add(height);

            weight.Text = "0";
            height.Text = "0";

            weight.SetBounds(100, 130, 100, 40);
            height.SetBounds(260, 130, 100, 40);

            output = new Label();
            Controls.Add(output);
            output.Text = "result: ";
            output.SetBounds(100,230,300,100);
        }

        public TextBox weight;
        public TextBox height;
        private Label message;
        private Label inputName;
        private Button calculate;
        private Button reset;
        public Label output;

        public float formula(float w, float h)
        {
            float bmi = w/(h*h);
            return bmi;
        }

        private void calculate_click(object sender, EventArgs e)
        {
            float result = formula(float.Parse(weight.Text), float.Parse(height.Text));
        
            if (result<=18.4)
            {
                output.Text += "Underweight";
            }

            else if (result<=24.9)
            {
                output.Text += "Normal";
            }

            else if (result <= 39.9)
            {
                output.Text += "Overweight";
            }

            else if (result >= 40)
            {
                output.Text += "Obese";
            }

            else
            {
                output.Text = "Please enter value" ;
            }
        }

        private void reset_click(object sender, EventArgs e)
        {
            weight.Text = "0";
            height.Text = "0";
            output.Text = "result: ";
        }
    }
}