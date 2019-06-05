using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqed_list
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class Bank
    {
        public string Name { get; set; }

        public int MillionaireCount { get; set; }
    }

    // Define a bank
    public class BankTwo
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

    // Define a customer
    public class CustomerTwo
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }

        
    }

    public class ReportItem
    {
        public string CustomerName { get; set; }

        public string BankName { get; set; }

        public string GetLastName()
        {
            return this.CustomerName.Split(" ")[1];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = from fruit in fruits
                                          where fruit.StartsWith("L")
                                          select fruit;

            foreach (string fruit in LFruits)
            {
                Console.WriteLine(fruit);
            }

            Console.WriteLine("- - - - - - - - - -");

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            List<string> descend = names.OrderByDescending(name => name.First()).ToList();

            foreach (string name in descend)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("- - - - - - - - - -");

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            List<int> descendNum = numbers.OrderBy(num => num).ToList();

            foreach (int num in descendNum)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("- - - - - - - - - -");

            // Output how many numbers are in this list
            List<int> numbersList = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            Console.WriteLine(numbersList.Count);

            Console.WriteLine("- - - - - - - - - -");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            double sum = purchases.Sum();

            Console.WriteLine(sum);

            Console.WriteLine("- - - - - - - - - -");

            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            bool IsPerfectSquare(int num)
            {
                int closestRoot = (int)Math.Sqrt(num);
                return num == closestRoot * closestRoot;
            }

            IEnumerable<int> sqr = wheresSquaredo
                .TakeWhile(n => !IsPerfectSquare(n));

            foreach (int num in sqr)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("- - - - - - - - - -");

            // Build a collection of customers who are millionaires

            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

            /*
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */


            IEnumerable<Bank> millionaires = (from mills in customers
                                              group mills by mills.Bank into MillList
                                              select new Bank
                                              {
                                                  Name = MillList.Key,
                                                  MillionaireCount = MillList.Where(c => c.Balance >= 1000000).ToList().Count()
                                              });

            foreach (Bank bank in millionaires)
            {
                Console.WriteLine($"{bank.Name} : {bank.MillionaireCount}");
            }

            Console.WriteLine("- - - - - - - - - -");

            /*
                TASK:
                As in the previous exercise, you're going to output the millionaires,
                but you will also display the full name of the bank. You also need
                to sort the millionaires' names, ascending by their LAST name.

                Example output:
                    Tina Fey at Citibank
                    Joe Landy at Wells Fargo
                    Sarah Ng at First Tennessee
                    Les Paul at Wells Fargo
                    Peg Vale at Bank of America
            */


            List<BankTwo> banks = new List<BankTwo>() {
            new BankTwo(){ Name="First Tennessee", Symbol="FTB"},
            new BankTwo(){ Name="Wells Fargo", Symbol="WF"},
            new BankTwo(){ Name="Bank of America", Symbol="BOA"},
            new BankTwo(){ Name="Citibank", Symbol="CITI"},
            };

            // Create some customers and store in a List
            List<CustomerTwo> customersTwo = new List<CustomerTwo>() {
            new CustomerTwo(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new CustomerTwo(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new CustomerTwo(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new CustomerTwo(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new CustomerTwo(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new CustomerTwo(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new CustomerTwo(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new CustomerTwo(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new CustomerTwo(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new CustomerTwo(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

            /*
                You will need to use the `Where()`
                and `Select()` methods to generate
                instances of the following class.

                public class ReportItem
                {
                    public string CustomerName { get; set; }
                    public string BankName { get; set; }
                }
            */
            List<ReportItem> millionaireReport = new List<ReportItem>();

            

            List<CustomerTwo> onlyMillionaires = (customersTwo.Where(c => c.Balance >= 1000000)).ToList();

            var groupJoin = onlyMillionaires.GroupJoin(banks, 
                                                    m => m.Bank,
                                                    bank => bank.Symbol,
                                                    (m, millGroup) => new
                                                    {
                                                        CustomerName = m.Name,
                                                        Bank = millGroup
                                                    });
            foreach(var item in groupJoin.OrderByDescending(c => c.CustomerName.Split(" ")[1].First()))
            {
                
                foreach(BankTwo bank in item.Bank)
                {
                    Console.WriteLine($"{item.CustomerName} with {bank.Name}");
                }
            }

            // onlyMillionaires.ForEach(m => {
            //     ReportItem foo = new ReportItem 
            //     {CustomerName = m.Name, BankName = banks.Single(b => b.Symbol == customersTwo.Single(c => c.Name == m.Name).Bank).Name};
            //     millionaireReport.Add(foo);
            // });
            
        //     millionaireReport.OrderByDescending(c => c.GetLastName().First());

        // foreach (var item in millionaireReport.OrderByDescending(c => c.GetLastName().First()))
        //     {
        //         Console.WriteLine($"{item.CustomerName} at {item.BankName}");
        //     }
        }
    }
}
