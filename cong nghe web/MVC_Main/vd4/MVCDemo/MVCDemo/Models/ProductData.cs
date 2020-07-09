using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class ProductData
    {
        public static List<Product> GetProduct(int count)
        {
            List<Product> lst = new List<Product>();
            for(int i = 0; i < count; i++)
            {
                Product product = new Product();
                product.ID = i;
                product.Name="San pham "+i;
                product.Description = "Mo ta " + i;
                lst.Add(product);
            }
            return lst;
        }
    }
}