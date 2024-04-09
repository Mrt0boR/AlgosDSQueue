using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessedExercise1_CustomerQueue2
{
    class Customer
    {

        private string name;
        private int age;
        private string address;
        private float amountOwed;
        

        public Customer(string name, int age, string address, float amountOwed)
        {
            this.name = name;
            this.age = age;
            this.address = address;
            this.amountOwed = amountOwed;
        }

        //getters and setters
        public string Name
        {
           get { return name; }
           set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }

        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public float AmountOwed
        {
            get { return amountOwed; }
            set { amountOwed = value; }

        }
        //get all information

        public string GetInformation()
        {


            return "Name: " + name + 
                   ", Age: " + age + 
                   ", Address: " + address + 
                   ", Amount Owed: " + amountOwed;


        }
    }
}
