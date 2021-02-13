using System;
using System.Linq;
using System.Collections.Generic;
using Shopping_Spree.Models;

namespace Shopping_Spree.Core
{
    public class Engine
    {
        // Functions of the Engine class.
        // Read data from the Console.
        // Process Data. => Manipulate, Save to DB etc.
        // Print data on the consol.

        private readonly ICollection<Person> persons;

        private readonly ICollection<Product> products;

        private const string END_SHOPPING = "END";

        public Engine()
        {
            persons = new List<Person>();
            products = new List<Product>();
        }

        // Place business logic in the Run Method.
        public void Run()
        {
            string[] personInfo = Console.ReadLine()
                .Split(new string[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] productInfo = Console.ReadLine()
                .Split(new string[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            for (int i = 0; i < personInfo.Length; i += 2)
            {
                string name = personInfo[i];
                decimal money = decimal.Parse(personInfo[i + 1]);
                try
                {
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            for (int i = 0; i < productInfo.Length; i += 2)
            {
                string name = productInfo[i];
                decimal prise = decimal.Parse(productInfo[i + 1]);
                try
                {
                    Product product = new Product(name, prise);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

            }

            string input;

            while ((input = Console.ReadLine()) != END_SHOPPING)
            {
                string[] shopingInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = shopingInfo[0];
                string productName = shopingInfo[1];

                Person curentPerson = persons.FirstOrDefault(per => per.Name == name);
                Product currentProduct = products.FirstOrDefault(pro => pro.Name == productName);

                curentPerson.BuyProduct(currentProduct);

            }

            //persons.ForEach(per => Console.WriteLine(per.ToString()));  // => not working with ICollection.

            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
