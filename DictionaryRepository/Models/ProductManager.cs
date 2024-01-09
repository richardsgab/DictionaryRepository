using DictionaryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryRepository.Models
{
    public class ProductManager : IRepository
    {

        public Dictionary<int, Product> SelectAll()
        {
            return Data.ProductList;
        }

        public void Delete(int id)
        {
            Data.ProductList.Remove(id);
        }

        public bool Find(int id)
        {
            if (Data.ProductList.TryGetValue(id, out Product value))
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public void Insert(Product product)
        {
            Data.ProductList.Add(product.Id, product);
        }

        public Product SelectSingle(int id)
        {
            Product product = Data.ProductList[id];
            return product;
        }
        public Dictionary<int, Product> GetAlByCategory(string category)
        {
            var result = SelectAll();
            var list = new Dictionary<int, Product>();
            foreach (var item in result)
            {
                if(item.Value.Category == category)
                {
                    list.Add(item.Key, item.Value);
                }
            }
            return list;
        }


        public void Update(Product product)
        {
            Product updateProduct = Data.ProductList[product.Id];
            updateProduct.Name = product.Name;
            updateProduct.Price = product.Price;
            updateProduct.Category = product.Category;
        }

        Dictionary<int, Product> IRepository.SelectAll()
        {
            return Data.ProductList;
        }
    }
}
