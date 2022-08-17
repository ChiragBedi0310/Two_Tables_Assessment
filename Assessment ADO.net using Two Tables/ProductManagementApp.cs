using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace PresentationLayer
{
    class ProductManagementApp
    {
        static void Main(string[] args)
        {
            ProductManagementIO PMI = new ProductManagementIO();
            bool flag = true;
            while (flag)
            {
                switch (PMI.Menu())
                {
                    case 1:
                        PMI.AddCategory();
                        break;

                    case 6:
                        PMI.DisplayAllProducts();
                        break;

                    case 7:
                        PMI.UpdateProduct();
                        break;

                    case 8:
                        PMI.DeleteProduct();
                        break;

                    case 5:
                        PMI.AddProduct();
                        break;

                    case 2:
                        PMI.DisplayProductsWithCategories();
                        break;

                    case 3:
                        PMI.UpdateCategoryName();
                        break;

                    case 4:
                        PMI.DeleteCategory();
                        break;

                    case 0:
                        flag = false;
                        break;
                }
            }
        }
    }
}
