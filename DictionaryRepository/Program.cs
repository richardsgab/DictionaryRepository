using DictionaryRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictlist = new ProductManager();
            var list = dictlist.SelectAll();
            Show(list, "All products");

            //Sorted List. el diccionario se convierte en lista para poder Sort
            var sortedlist = list.ToList();
            sortedlist.Sort((pair1,pair2) => pair1.Value.Name.CompareTo(pair2.Value.Name));
            Show(sortedlist.ToDictionary(pair =>pair.Key, pair => pair.Value), "Sorted by Name");

            //Delete record number 2
            dictlist.Delete(2);
            Show(dictlist.SelectAll(), "Eliminate product n 2");

            //Add new record(make a new prodcut and added it
            Product p8 = new Product()
            {
                Id = 8,
                Category = "Computer",
                Name = "Laptop",
                Price = 1000.0m,
            };
            dictlist.Insert(p8);
            Show(dictlist.SelectAll(), "List after the added product");

            //Update record number 4
            Product p4 = new Product()
            {
                Id = 4,
                Category = "ComputerUpdated",
                Name = "LaptopUpdated",
                Price = 1000.0m,
            };
            dictlist.Update(p4);
            Show(dictlist.SelectAll(), "With an updated product");

            //Select single record
            Product p5 = dictlist.SelectSingle(5);
            Console.WriteLine("Product is " + p5.ToString());
        }
        private static void Show(Dictionary<int,Product> dictlist, string parameter) 
        {
            Console.WriteLine(new string('_', 50));
            Console.WriteLine(parameter);
            Console.WriteLine(new string('_', 50));
            foreach (var item in dictlist) 
            {
                Console.WriteLine(item.Key.ToString().PadRight(5) + item.Value.Name.ToString().PadRight(15) + item.Value.Price.ToString().PadRight(20) + item.Value.Category.ToString());
            }
        }
    }
}
