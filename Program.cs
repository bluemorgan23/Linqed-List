using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqed_list
{
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

            foreach(int num in descendNum)
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
                int closestRoot = (int) Math.Sqrt(num);
                return num == closestRoot * closestRoot;
            }

            IEnumerable<int> sqr = wheresSquaredo
                .TakeWhile(n => !IsPerfectSquare(n));

            foreach(int num in sqr)
            {
                Console.WriteLine(num);
            }

        }
    }
}
