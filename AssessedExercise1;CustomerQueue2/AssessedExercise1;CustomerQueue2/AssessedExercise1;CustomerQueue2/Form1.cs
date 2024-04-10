using AssessedExercise1_CustomerQueue2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Reflection.Emit;
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





        /*                                                                                                ENQUEUE ACTION BUTTON METHOD                                                                     */
        private void enqueueButton_Click(object sender, EventArgs e)
        {


            //Ensures that all text boxes are filled so a customer is not enqueued with data missing.

            if (string.IsNullOrEmpty(textBox1.Text)
                || string.IsNullOrEmpty(textBox2.Text)
                || string.IsNullOrEmpty(textBox3.Text)
                || string.IsNullOrEmpty(textBox4.Text)
                )
            {
                MessageBox.Show("Please Fill in all the Information Boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            //checks that the queue is not full before enquing the customer and their details.
            if (!customerQueue.isFull())
            {

                //this parses the intager entered as the age, checking it is an intager and not a string, as a user could put "twelve" rather than "12".

                //Both the age parsing object allow the text entered in the boxes to be converted into ints and floats so that the data entered can be accurately inserted into the customer object.
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

                //This section also follows the same function as the age intager check.
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


                //String data and parsed ints and floats from text box 2 and 4 are then entered into a new customer object.
                Customer newEnqueuedCustomer = new Customer
                (
                    textBox1.Text,
                    ageParsingObject,
                    textBox3.Text,
                    amountOwedParsingObject
                );

                //the arguments of this data are then passed onto the enqueue method in the queue class.
                customerQueue.Enqueue(newEnqueuedCustomer);

                //clears the text boxes so that new data can be entered again
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                //this tells the user that the data has been entred into the queue 
                label11.Text = ("Customer Enqueued Successfully");

                int amountofcustomers = customerQueue.customerQueueCount();

                label8.Text = amountofcustomers.ToString();


                totalAmountOwedUpdater();



            } else
            {
                MessageBox.Show("The Customer Queue is Full", "The Queue has Reached Capacity (10)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        



        /*                                                                                                DEQUEUE ACTION BUTTON METHOD                                                                     */

        private void button3_MouseHover(object sender, MouseEventArgs e)
        {
            MessageBox.Show("test");
        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (!customerQueue.isEmpty())
            {

                Customer dequeuecustomer = customerQueue.Dequeue();


                
                label10.Text = (dequeuecustomer.GetInformation());

                Console.WriteLine("Customer Dequeued");
                
                totalAmountOwedUpdater();
                

                int amountofCustomers = customerQueue.customerQueueCount();
                label8.Text = amountofCustomers.ToString();

            }
            else
            {
                MessageBox.Show("The Queue is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }





        }

        /*                                                                                             TOTAL AMOUNT REAL-TIME UPDATER                                                                                  */
        private void totalAmountOwedUpdater()
        {
            

            float customerMaxOwed = customerQueue.totalAmountOwedFinder();
            
            label13.Text = customerMaxOwed.ToString();


        }

                                            /*                                                         MAX AMOUNT BUTTON METHOD                                                                                       */

        private void button4_Click(object sender, EventArgs e)
        {
            Customer maxAmountCust = customerQueue.FindMaxOwed();

            if (maxAmountCust != null)
            {
                MessageBox.Show($"Customer witht the maximum amount owed: \n\n {maxAmountCust.GetInformation()}",
                                "Customer with the maximum amount owed", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            {
                MessageBox.Show("No Customers are in the Queue So a Maximum Amount Owed Cannot be Retrieved","Maximum Amount Owed Retrieval Error: The Queue is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }


                                              /*                                                        PEEK BUTTON METHOD                                                                                          */
       
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            

            if (!customerQueue.isEmpty())
            {
                Customer peekedCustomer = customerQueue.Peek();

                label14.Text = (peekedCustomer.GetInformation());

            }
            else
            {

                MessageBox.Show("There Are No Customers in the Queue. Please Enqueue a Customer and try again","Peek Error: The Queue is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }


        }

    }
    }



