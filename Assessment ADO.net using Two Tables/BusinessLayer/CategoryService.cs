using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLinkLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class CategoryService
    {
        Category_sql_connect category = new Category_sql_connect();
        public void AddCategory(Category c)
        {
            if (category.InsertDataIntoCategory(c))
            {
                Console.WriteLine("Category Details Added Successfully!");
            }
            else
            {
                Console.WriteLine("Failed To Add Category Details");
            }
        }


        public void UpdateCategoryName(int id, string name)
        {
            if (category.GetNumberOfRecords() != 0)
            {
                if (category.UpdateCategoryName(id, name))
                {
                    Console.WriteLine("Category Name Updated Successfully!");
                }
                else
                {
                    Console.WriteLine("\nCategory Not Found");
                }
            }

            else
            {
                Console.WriteLine("\nCategory Not Found");
            }
        }

        public void DisplayAllProductsWithCategory()
        {
            if (category.GetNumberOfRecords() != 0)
            {
                Console.WriteLine("All Products with Categories Are Shown Below:\n");
                category.ReadData();
            }

            else
            {
                Console.WriteLine("No Data Found, First Add Some Products with Categories");
            }
        }
        public bool DeleteCategory(int id)
        {
            if (category.GetNumberOfRecords() > 0)
            {
                if (category.DeleteData(id))
                {
                    Console.WriteLine("Category Details Deleted Successfully!");
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
