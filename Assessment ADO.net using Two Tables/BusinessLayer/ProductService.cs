using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLinkLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class ProductService
    {
        Product_sql_connect product = new Product_sql_connect();
        public void AddProduct(Product p)
        {
            if (product.InsertDataIntoProduct(p))
            {
                Console.WriteLine("Product Details Added Successfully!");
            }
            else
            {
                Console.WriteLine("Failed To Add Product Details");
            }
        }

        public void UpdateProductPrice(int id, int price)
        {
            if (product.GetNumberOfRecords() != 0)
            {
                if (product.UpdateProdcutPrice(id, price))
                {
                    Console.WriteLine("Product Price Updated Successfully!");
                }
                else
                {
                    Console.WriteLine("\nProduct Not Found");
                }
            }
            else
            {
                Console.WriteLine("\nProduct Not Found");
            }

        }

        public void UpdateProductName(int id, string name)
        {
            if (product.GetNumberOfRecords() != 0)
            {
                if (product.UpdateProductName(id, name))
                {
                    Console.WriteLine("Product Name Updated Successfully!");
                }
                else
                {
                    Console.WriteLine("\nProduct Not Found");
                }
            }

            else
            {
                Console.WriteLine("\nProduct Not Found");
            }
        }

        public void DisplayAllProducts()
        {
            if (product.GetNumberOfRecords() != 0)
            {
                Console.WriteLine("All Categories Are Shown Below:\n");
                product.ReadDataAllProducts();
            }

            else
            {
                Console.WriteLine("No Data Found, First Add Some Products");
            }
        }
        public bool DeleteProduct(int id)
        {
            if (product.GetNumberOfRecords() > 0)
            {
                if (product.DeleteData(id))
                {
                    Console.WriteLine("Product Details Deleted Successfully!");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
