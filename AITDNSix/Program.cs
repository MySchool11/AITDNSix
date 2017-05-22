using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace AITDNSix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // A field is a variable of a class --> See the Customer() class below
            // A property can define either a get and/ or a set accessor (known as getters and setters) --> See the NewCustomer() class below
            // fields cannot have validation performed upon them wheras a property can have validation built into it

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

            public Customer()          // This is the default constructor (the one with nothing in the parenthesis with the same name as the class in which it resides)
                : this("Default")      // Because the Overloaded constructer needs a name we can tell the default constructor "if one is not passed to you, just use 'Default'", problem solved
            // Another approach to having two Constructors is to set the default name if one is not passed in the overloaded constructor thusly; public Customer(string Name = "Default") <MUST BE C# v4.0 OR HIGHER>
            {

            }

            public Customer(string name) // Overloaded Constructor that accepts a name string, so called Customer newCustomer = new Customer("John");     
            {
                var customerDetails = new List<string>(); // We always want this to run, even when the default constructor is used. See the default constructor above for details
                _name = name; // To change the _name field a public method that excepts a string and then passes it to the field exists, so the original field is never accessible by other code.
            }
        }

        public class NewCustomer
        {
            private string _name; // field

            public string Name  // property
            {
                get { return _name; } // getter --> returned when NewCustomer.Name is requested using string name = NewCustomer.Name
                set
                {
                    if (!String.IsNullOrEmpty(value)) // setter (code validates that the passed variable is not null or empty and will only run if this is true, if not (!) null or empty (value passed).
                    {
                        _name = value;  // value is a keyword used in properties to reflect the data passed into the property, in this case a string for the Name value --> runs when NewCustomer.Name = "{some value}" is declared.
                    }
                }
            }
        }
    }
}
