using System;
using System.Collections.Generic;

namespace StorageInfoENG
{
    internal class Program
    {
        private static void Pr(string text)
        {
            Console.WriteLine(text);
        }

        private static void Main(string[] args)
        {
            Dictionary<string, int> Log = new Dictionary<string, int>();
            Dictionary<string, decimal> PriceLog = new Dictionary<string, decimal>();
            while (true)
            {
                Pr("---SorageInfo---");
                Pr("View products - ls");
                Pr("Add product - add");
                Pr("Write off goods - rm");
                Pr("Search product - find");
                Pr("Clear console - clear");
                Pr("Exit - exit");
                
                string comd = Console.ReadLine()!;
                if (comd == "exit") { break; }
                switch (comd)
                {
                    case "add":
                        Pr("Name of product: ");
                        string nameofb = Console.ReadLine()!;
                        Console.WriteLine("Enter the quantity of the product: ");
                        decimal priceofb;
                        int countofb;

                        while (!int.TryParse(Console.ReadLine(), out countofb) || countofb < 0)
                        {
                            Pr("Incorrect input!");
                        }

                        Pr("\r\nEnter the price of the product: ");
                        while (!decimal.TryParse(Console.ReadLine(), out priceofb) || priceofb < 0)
                        {
                            Pr("Incorrect input!");
                        }

                        if (Log.ContainsKey(nameofb))
                        {
                            Log[nameofb] += countofb;
                            PriceLog[nameofb] = countofb;
                        }
                        else
                        {
                            Log.Add(nameofb, countofb); PriceLog[nameofb] = priceofb;
                            Pr("Successfully added!");
                        }
                        break;

                    case "rm":
                        Pr("Enter the name of the product in stock: ");
                        nameofb = Console.ReadLine()!;
                        Log.ContainsKey(nameofb);
                        break;

                    case "clear":
                        {
                            Console.Clear();
                            break;
                        }
                    case "find":
                        {
                            string namefind = Console.ReadLine()!;
                            if (Log.ContainsKey(namefind))
                            {
                                Pr($"\r\nProduct found: Product: {namefind} | Count: {Log[namefind]} | Price: {PriceLog[namefind]}");
                            }
                            else
                            {
                                Pr("This product does not exist!");
                            }
                            break;
                            
                        
                        }
                    case "ls":

                        if (Log.Count == 0)
                        {
                            Pr("The warehouse is empty!");
                        }
                        else
                        {
                            Pr("List of products in stock: ");
                            foreach (var item in Log)
                            {
                                string nameb = item.Key;
                                int countb = item.Value;
                                decimal priceb = PriceLog[nameb];
                                Pr($"Product: {nameb} | Count: {countb} | Price: {priceb} ");
                            }
                        }
                        break;

                    default:
                        Pr("Unknown command!");
                        break;
                }
            }
        }
    }
}