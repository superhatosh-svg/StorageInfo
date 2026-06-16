using System;
using System.Collections.Generic;

namespace GeminiBirge
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
                Pr("Просмотр товаров - ls");
                Pr("Добавить товар - add");
                Pr("Списать товар - rm");
                Pr("Поиск - find");
                Pr("Очистить консоль - clear");
                Pr("Выход - exit");
                
                string comd = Console.ReadLine()!;
                if (comd == "exit") { break; }
                switch (comd)
                {
                    case "add":
                        Pr("Введите название товара: ");
                        string nameofb = Console.ReadLine()!;
                        Console.WriteLine("Введите количество товара: ");
                        decimal priceofb;
                        int countofb;

                        while (!int.TryParse(Console.ReadLine(), out countofb) || countofb < 0)
                        {
                            Pr("Некорректный ввод!");
                        }

                        Pr("Введите цену товара: ");
                        while (!decimal.TryParse(Console.ReadLine(), out priceofb) || priceofb < 0)
                        {
                            Pr("Некорректный ввод!");
                        }

                        if (Log.ContainsKey(nameofb))
                        {
                            Log[nameofb] += countofb;
                            PriceLog[nameofb] = countofb;
                        }
                        else
                        {
                            Log.Add(nameofb, countofb); PriceLog[nameofb] = priceofb;
                            Pr("Успешно добавлено!");
                        }
                        break;

                    case "rm":
                        Pr("Введите имя предмета на складе: ");
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
                                Pr($"Найден товар : Товар: {namefind} | Количество товара на складе: {Log[namefind]} | Цена товара: {PriceLog[namefind]}");
                            }
                            else
                            {
                                Pr("Такого товара не существует!");
                            }
                            break;
                            
                        
                        }
                    case "ls":

                        if (Log.Count == 0)
                        {
                            Pr("Склад пуст!");
                        }
                        else
                        {
                            Pr("Список товаров на складе: ");
                            foreach (var item in Log)
                            {
                                string nameb = item.Key;
                                int countb = item.Value;
                                decimal priceb = PriceLog[nameb];
                                Pr($"Название товара: {nameb} | Количество товара: {countb} | Цена товара: {priceb} ");
                            }
                        }
                        break;

                    default:
                        Pr("Неизвестная команда!");
                        break;
                }
            }
        }
    }
}