using System;

namespace AITDNSix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // A field is a variable of a class --> See the Customer() class below
            // A property can define either a get and/ or a set accessor (known as getters and setters) --> See the NewCustomer() class below

            Customer newCustomer = new Customer("John"); // The Customer() newCustomer is instantiated (created) with the field "John".
            // How do we now recover that field? We cannot because it is held in a private variable accessible only from within the class.
            NewCustomer Customer = new NewCustomer(); // Instantiate a new NewCustomer class called newCustomer
            Customer.Name = "John"; // set the field Name to "John";
            Console.WriteLine("Customer name is {0}", Customer.Name); // Uses the Name property getter to return the value held;

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public class Customer
        {
            private readonly string _name; // The actual field should be private, so inaccessible by any code outside of the class.
  
            public Customer(string name) // Constructor that accepts a name string, so called Customer newCustomer = new Customer("John");
            {
                _name = name; // To change the _name field a public method that excepts a string and then passes it to the field exists, so the original field is never accessible by other code.
            }
        }

        public class NewCustomer
        {
            private string _name; // field

            public string Name  // property
            {
                get { return _name; }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        _name = value;
                    }
                }
            }
        }
    }
}
