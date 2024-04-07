using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace AssessedExercise1_CustomerQueue2
{
    internal class Queue
    {
        private readonly int maxSize = 10;

        private Customer[] customerQueueArray; //store


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
            numCustomers = numCustomers + 1;        //still + 1 customer but 5 obj attributes in the tail
            customerQueueArray[tail] = customer;

            tail++; //tail = tail + shorthand

            if (tail == maxSize)
            {
                tail = 0;

                throw new Exception("queue is full");
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
            
            headCustomer = customerQueueArray[head];

            //once retrieved reduce the number of customers by 1
            
            numCustomers--;
            
            /*
            * increment the head value so the array index moves along to the second slot in the queue array that
            * is now the front of the queue as the value in front of this index that was previously the head and
            * now been dequeued
            */

            head++;

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
            Customer headCustomer;
            headCustomer = customerQueueArray[head];
            return headCustomer;
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


    }
}
