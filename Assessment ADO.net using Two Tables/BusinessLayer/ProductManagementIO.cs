using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer
{
    public class InvalidInput : Exception
    {
        public void error()
        {
            Console.WriteLine("Choose From Given Options Only\n");
        }
    }

    public class ProductManagementIO
    {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();

        public byte Menu()
        {
            Console.WriteLine("Press 1 to Add Categpry");
            Console.WriteLine("Press 2 to View All Products With Categories");
            Console.WriteLine("Press 3 to Update Category");
            Console.WriteLine("Press 4 to Delete Category");
            Console.WriteLine("Press 5 to Add Product");
            Console.WriteLine("Press 6 to View All Categories");
            Console.WriteLine("Press 7 to Update Product");
            Console.WriteLine("Press 8 to Delete Product");
            Console.WriteLine("Press 0 to Exit");
            Console.WriteLine("Enter Your choice:");
            try
            {
                byte option = Convert.ToByte(Console.ReadLine());
                if (option > 8)
                {
                    throw new InvalidInput();
                }
                return option;
            }
            catch (InvalidInput e)
            {
                e.error();
                return Menu();
            }
            catch (Exception)
            {
                Console.WriteLine("Enter Valid Input\n");
                return Menu();
            }
        }

        public void AddProduct()
        {
            try
            {
                Console.WriteLine("Enter Product Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Product ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Price:");
                int price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Category ID:");
                int category = Convert.ToInt32(Console.ReadLine());
                Product p = new Product(name, id, price, category);
                productService.AddProduct(p);

                Console.WriteLine("".PadLeft(15, '-'));
            }
            catch(DataLinkLayer.ProductIdALreadyPresent e)
            {
                e.Error1();
                Menu();
            }
            catch (DataLinkLayer.CategoryNotFound e)
            {
                e.Error();
                Menu();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Enter A Valid Input\n");
                Menu();
            }

        }


        public void DisplayAllProducts()
        {
            Console.WriteLine();
            productService.DisplayAllProducts();
            Console.WriteLine();
        }

        public void DisplayProductsWithCategories()
        {
            Console.WriteLine();
            categoryService.DisplayAllProductsWithCategory();
            Console.WriteLine();
        }

        public void DeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter Product Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                if (productService.DeleteProduct(id))
                {
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("Product Not Found!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a Valid Input\n");
                Menu();
            }
        }

        public void UpdateProduct()
        {
            Console.WriteLine("Press 1 to update price");
            Console.WriteLine("Press 2 to update product name");
            Console.WriteLine("Enter Your Choice");
            try
            {

                switch (Convert.ToByte(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Enter Product Id:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter New Price:");
                        int price = Convert.ToInt32(Console.ReadLine());
                        productService.UpdateProductPrice(id, price);
                        break;

                    case 2:
                        Console.WriteLine("Enter Product Id:");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter New Name:");
                        string name = Console.ReadLine();
                        productService.UpdateProductName(Id, name);
                        break;

                    default:
                        Console.WriteLine("Enter a Valid Option");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a Valid Input\n");
                Menu();
            }
        }

        public void AddCategory()
        {
            try
            {
                Console.WriteLine("Enter Category ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Category Name:");
                string category = Console.ReadLine();
                Category c = new Category(category,id);
                categoryService.AddCategory(c);
                Console.WriteLine("".PadLeft(15, '-'));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Enter a Valid Input\n");
                Menu();
            }
        }

        public void UpdateCategoryName()
        {
            try
            {
                Console.WriteLine("Enter Category Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter New Name:");
                string name = Console.ReadLine();
                categoryService.UpdateCategoryName(id, name);
            }
            catch(Exception)
            {
                Console.WriteLine("Enter a Valid Input\n");
                Menu();
            }
        }

        public void DeleteCategory()
        {
            try
            {
                Console.WriteLine("Enter Category Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                if (categoryService.DeleteCategory(id))
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Category Not Found!");
                }
            }
            catch(DataLinkLayer.CategoryAlreadyLinked e)
            {
                e.Error();
                Menu();
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a Valid Input\n");
                Menu();
            }
        }
    }
}
