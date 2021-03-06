﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AITDNSix
{
    internal class Program
    {

        /// <summary>
        /// This program discusses fields and properties, their differnces and uses.
        /// </summary>
        /// <author>
        /// Samuel Bancroft (c) 2017
        /// </author>
        /// <code>
        /// Made up of one main file
        /// Program.cs => the main file
        /// </code>

        private static void Main(string[] args)
        {
            // A field is a variable of a class --> See the Customer() class below.
            // A property can define either a get and/ or a set accessor (known as getters and setters) --> See the NewCustomer() class below.
            // fields cannot have validation performed upon them wheras a property can have validation built into it.

            var newCustomer = new Customer("John"); // The Customer() newCustomer is instantiated (created) with the field "John".
            // How do we now recover that field? We cannot because it is held in a private variable accessible only from within the class.
            var custName = "102253335"; // Here we have a variable called custName (which should hold the customers name) but for some reason holds the customers bank a/c no.
            var oopsCustomer = new Customer(custName); // Now the oopsCustomer object has been created with a bank a/c number in place of the customers name because a field has no error checking performed on it.
            // You could of course write another method to error check the input but this creates more complexity and makes debugging harder, so it is better to use a property and build the error checking into that.
            var customer = new NewCustomer(); // Instantiate a new NewCustomer class called newCustomer.
            customer.Name = "John"; // set the field Name to "John".
            Console.WriteLine("Customer name is {0}", customer.Name); // Uses the Name property getter to return the value held.
            // If we try to pass "102253335" as the Name to the customer object (which uses a property to error handle), this happens -
            Console.WriteLine("Try to make customer.Name = 102253335");
            customer.Name = "102253335";
            Console.WriteLine("Customer.Name is now: {0} - this is because the numbers passed were ignored, so nothing changed.", customer.Name);
            // You can use a technique called the object initialiser to simplify this process.
            var customerTwo = new NewCustomer()
            {
                Name = "Peter",
                Age = 22 // each property needs a , between them
                // Any other properties that need setting at declaration time
            };
            Console.WriteLine("CustomerTwo name is {0} and their age is {1}", customerTwo.Name, customerTwo.Age); // Returns Peter and 22 from the getters of the property Name.

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // For clarity sake in this lesson, the classes have been placed within the main class (Program). Were this production code they would be put into seperate class files named as the class so Customer.cs and NewCustomer.cs
        // This is done for ease of reading and amending the code.

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
            private string _name; // field --> to store information all properties need a field, as the property is just a collection of code and not a variable

            public string Name  // property
            {
                get { return _name; } // getter --> returned when NewCustomer.Name is requested using string name = NewCustomer.Name
                set
                {
                    if (!String.IsNullOrEmpty(value) && !value.All(char.IsDigit)) // setter (code validates that the passed variable is not null or empty and will only run if this is true, if not (!) null or empty (value passed) or contains no numbers.
                    {
                        _name = value;  // value is a keyword used in properties to reflect the data passed into the property, in this case a string for the Name value --> runs when NewCustomer.Name = "{some value}" is declared.
                    }
                }
                // If the setter was removed then the property would become read only, as there would be no way to alter the properties value.
                // Although you can expose fields (make them public), common practice (arguably good practice) is to expose properties and hide fields.
            }

            // One last thing to know is that you can create a default property which will create a 'hidden' member (variable belonging to a class) without the need to declare it -
            public int Age { get; set; } // That easy, but now there is no validation, so be careful in its use.
        }
    }
}
