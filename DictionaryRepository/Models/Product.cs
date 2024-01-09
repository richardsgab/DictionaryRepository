using System;

namespace DictionaryRepository.Models
{
    public class Product:IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public override string ToString()
        {
            return $" {Name} {Price} - {Category}";
        }

        public int CompareTo(Product other)
        {
            return this.Name.CompareTo(other.Name);//Alphabetic order
        }

        public string GetNameAndprice
        {
            get 
            {
                return Name + Price.ToString();
            }
        }
    }
}
