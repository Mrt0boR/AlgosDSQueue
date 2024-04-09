using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
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

        //Enqueue action
        private void enqueueButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)
                || string.IsNullOrEmpty(textBox2.Text)
                || string.IsNullOrEmpty(textBox3.Text)
                || string.IsNullOrEmpty(textBox4.Text)
                )
            {
                MessageBox.Show("Please Fill in all the Information Boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //convert amount owed String inputted in the textbox to the appropriate float obj specified in the Customer class
            if (!customerQueue.isFull())
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

                customerQueue.Enqueue(newEnqueuedCustomer);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                label11.Text = ("Customer Enqueued Successfully");
                
                int amountofcustomers = customerQueue.customerQueueCount();

                label8.Text = amountofcustomers.ToString();
                
                
                totalAmountOwedUpdater();
                
                
                
            }
        }




        //Show number of Customers Button action
       


        //Dequeue Button Action

        private void button3_MouseHover(object sender, MouseEventArgs e)
        {
            MessageBox.Show("test");
        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (!customerQueue.isEmpty())
            {

                Customer dequeuecustomer = customerQueue.Dequeue();


                //need to use my peek method
                label10.Text = (
                        " Customer Name: " + dequeuecustomer.Name + "" +
                        " Customer Age: " + dequeuecustomer.Age + "" +
                        " Customer Address: " + dequeuecustomer.Address + "" +
                        " Customer Amount Owed: " + dequeuecustomer.AmountOwed + ""
                );

                Console.WriteLine("Customer Dequeued");
                totalAmountOwedUpdater();
                maximumValueFinder();

                int amountofCustomers = customerQueue.customerQueueCount();
                label8.Text=amountofCustomers.ToString();  

            } else
            {
                MessageBox.Show("The Queue is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


          
                
            
        }

        //Method to constantly update the total amount owed by all the customers in the Queue


        // add a way to remove the value of a customer who is dequed

        //Add to cust queue??
        private void totalAmountOwedUpdater()
        {
            //assign a float that begins at 0 as it would be when the queue is empty

            float amountOwedByAllCustomers = 0;

            for (int i = 0; i < customerQueue.customerQueueCount(); i++)
            {

            
            
                /* 
                 First I tried to iterate through like an array:

                Customer customer = customerQueue[i];

                But i got a CS0021 error. So, I decided to manually sort through the queue in
                this methiod manually dequing and then, adding the amount seen in the peek into a running total
                and then dequing when the queue itself is not empty.
                 
                 
                 */
                

                

                Customer customer = customerQueue.Dequeue();

                /* add to running total the += operator is shorthand for:
                *   amountOwedByAllCustomers = amountOwedByAllCustomers + customer.AmountOwed
                */
                amountOwedByAllCustomers += customer.AmountOwed;

                customerQueue.Enqueue(customer);

            }
        
            label13.Text = amountOwedByAllCustomers.ToString();
            

        }

        //Maximum value
        private float maximumValueFinder() { 
            
            float maxValue = 0;
            Customer customerMostOwed = null;
            private Customer[] indexholder;

            for (int i = 0;i < customerQueue.customerQueueCount(); i++)
            {
                int index = i;
                if (Customer[index])
                {

                    maxValue = customerMostOwed.AmountOwed;


                   

                    
                }

                

                //go thru every customer in the queue -- see what the customer owes,  ie is customer.amountowed < maxValue
                //max value is == customer.AmountOwed.
                
                //need to remember the index value to then display this

            }
            label16.Text = maxValue.ToString();
            return maxValue;


            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Customer peekedCustomer = customerQueue.Peek();

            label14.Text = (
                        " Customer Name: " + peekedCustomer.Name + "" +
                        " Customer Age: " + peekedCustomer.Age + "" +
                        " Customer Address: " + peekedCustomer.Address + "" +
                        " Customer Amount Owed: " + peekedCustomer.AmountOwed + ""
                );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            maximumValueFinder();
        }
    }
}


