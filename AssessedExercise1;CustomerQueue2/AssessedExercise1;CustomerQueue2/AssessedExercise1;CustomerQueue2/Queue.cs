using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssessedExercise1_CustomerQueue2
{
    internal class Queue
    {
        private readonly int maxSize = 3;


        private Customer[] customerQueueArray;   // example has private int store???

        int head = 0;
        int tail = 0;
        int numCustomers; //numitems

        public Queue()
        {
            customerQueueArray = new Customer[maxSize];
        }
        public Queue(int size) //size
        {
            maxSize = size;
            customerQueueArray = new Customer[maxSize];
        }

        public void Enqueue(Customer customer)
        {
            if (numCustomers == maxSize)
            {
                MessageBox.Show("The Customer Queue is Full! \nPlease Dequeue a Customer Before Enqueing Another.", "The Queue has Reached Capacity (10)"  , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            numCustomers = numCustomers + 1;
            customerQueueArray[tail] = customer;

            tail++;


            if (tail == maxSize)
            {
                tail = 0; //circular wrap around

               
       
            }  
         
            Console.WriteLine("CustomerEnqueued");
        }
        /*
         *                                     DEQUEUE  
         *           
         * Dequeing is when the customer at the head of the queue is removed and that value
         * is returned
         * 
         */
        public Customer Dequeue()
        {
            //retrieve the customer at the head index of customer queue
            Customer headCustomer;

            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return null;


            }


                numCustomers--;

                headCustomer = customerQueueArray[head];

                //once retrieved reduce the number of customers by 1



                /*
                * increment the head value so the array index moves along to the second slot in the queue array that
                * is now the front of the queue as the value in front of this index that was previously the head and
                * now been dequeued
                */

                head++; //head = head + 1
            
            //if checking conditions for wrap around
            if (head == maxSize)
            {
                head = 0;

            }
            //return the head customer that was just dequeued
            return headCustomer;



        }

        /*
         *                                      PEEK
         * peeking is when you return the value of the customer object but it is not dequeued
         * essentially dequeueing without the dequeing part!
         * 
         */
        public Customer Peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return null;
            }
            else {

                Customer headCustomer;
                headCustomer = customerQueueArray[head];
                return headCustomer;

            }


            
        }

        public bool isEmpty()
        {
            return head == tail;
        }

        public bool isFull()
        {

            return head == maxSize;

        }

        public int customerQueueCount()
        {
            
            return numCustomers;

        }

        public Customer FindMaxOwed()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
            }

            Customer customerWithMaxAmount = null;
            float maxAmount = 0;
            for (int i = 0; i < numCustomers; i++)
            {
                int index = i; // Adjust index calculation
                if (customerQueueArray[index].AmountOwed > maxAmount)
                {
                    customerWithMaxAmount = customerQueueArray[index];
                    maxAmount = customerWithMaxAmount.AmountOwed;
                }
            }
            return customerWithMaxAmount;
        }

        public float totalAmountOwedFinder()
        {
            //Passing the label variable allows this method to logically remain as part of the queue class whilst allowing me to update the maximum amount in real time as customers are enqueued.

            float amountOwedByAllCustomers = 0;

            for (int i = 0; i < numCustomers; i++)
            {
                Customer customerAmountCheck = customerQueueArray[i];
                amountOwedByAllCustomers = amountOwedByAllCustomers + customerAmountCheck.AmountOwed;
                
            }

            return amountOwedByAllCustomers;
            



        }

    }
}
