using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssessedExercise1_CustomerQueue2
{
    public partial class Form1 : Form
    {
        
        Queue customerQueue = new Queue();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //convert amount owed String inputted in the textbox to the appropriate float obj specified in the Customer class
            if (customerQueue.isEmpty() != false)
            {
                int ageParsingObject;
                try
                {
                    ageParsingObject = int.Parse(textBox2.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Only Integers can be entered for a Customer Age");
                    return;
                }

                //convert amount owed String inputted in the textbox to the appropriate float obj specified in the Customer class
                float amountOwedParsingObject;
                try
                {
                    amountOwedParsingObject = float.Parse(textBox4.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please specify the Customer's amount owed in Pounds and Pence");
                    return;
                }

                Customer newEnqueuedCustomer = new Customer
                (
                    textBox1.Text,
                    ageParsingObject,
                    textBox3.Text,
                    amountOwedParsingObject
                );
                
                customerQueue.Enqueue( newEnqueuedCustomer );
            
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
