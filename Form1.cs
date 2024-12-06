using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backprop;
namespace NeuralNetowrkBP
{
    public partial class Form1 : Form
    {
        NeuralNet nnn;
        int[,] input =
        {
            {0,0,0,0 },{0,0,0,1 },{0,0,1,0 },{0,0,1,1 },
            {0,1,0,0 },{0,1,0,1 },{0,1,1,0 },{0,1,1,1 },
            {1,0,0,0 },{1,0,0,1 },{1,0,1,0 },{1,0,1,1 },
            {1,1,0,0 },{1,1,0,1 },{1,1,1,0 },{1,1,1,1 },
        };
        int[] output =
        {
            0,0,0,0,
            0,0,0,0,
            0,0,0,0,
            0,0,0,1
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nnn = new NeuralNet(4,10,1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int epoch = 100;
            for(int n = 0; n < epoch; n++)
            {
                for(int i = 0; i < 16; i++)
                {
                    nnn.setInputs(0, input[i, 0]);
                    nnn.setInputs(1, input[i, 1]);
                    nnn.setInputs(2, input[i, 2]);
                    nnn.setInputs(3, input[i, 3]);
                    nnn.setDesiredOutput(0, output[i]);
                    nnn.learn();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nnn.setInputs(0,Convert.ToDouble(textBox1.Text));
            nnn.setInputs(1,Convert.ToDouble(textBox2.Text));
            nnn.setInputs(2,Convert.ToDouble(textBox3.Text));
            nnn.setInputs(3,Convert.ToDouble(textBox4.Text));
            nnn.run();
            textBox5.Text = ""+ nnn.getOuputData(0);
        }
    }
}
