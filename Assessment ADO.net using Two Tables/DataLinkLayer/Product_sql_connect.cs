using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntityLayer;

namespace DataLinkLayer
{
    public class CategoryNotFound : Exception
    {
        public void Error()
        {
            Console.WriteLine("Category ID not found, First Add the Category\n");
        }
    }
    public class ProductIdALreadyPresent : Exception
    {
        public void Error1()
        {
            Console.WriteLine("Product Id already present, Try Different Id\n");
        }
    }

    public class Product_sql_connect
    {
        SqlConnection conn;

        public Product_sql_connect()
        {
            conn = new SqlConnection("Server = DEL1-LHP-N82143\\MSSQLSERVER01; Database = Assessment; Integrated Security = SSPI");
        }

        public void ReadDataAllProducts()
        {
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(@"Select cat.CategoryId,cat.CategoryName 
                            from Product pro right join Category cat on pro.CategoryId = cat.CategoryId", conn);

                reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine($"{reader.GetName(i)} : {reader[i]}");
                    }
                    Console.WriteLine("".PadLeft(15, '-'));
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private bool CheckProductCategory(Product p)
        {
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("Select CategoryId from Category", conn);

                reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if ((int)reader[i] == p.CategoryID)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        private bool CheckProductId(Product p)
        {
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("Select ProductId from Product", conn);

                reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if ((int)reader[i] == p.ID)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool InsertDataIntoProduct(Product p)
        {
            try
            {
                if (CheckProductId(p))
                {
                    throw new ProductIdALreadyPresent();
                }
                if (CheckProductCategory(p))
                {
                    throw new CategoryNotFound();
                }
                conn.Open();
                string insertString = $"Insert into Product values('{p.ID}','{p.Name}','{p.Price}','{p.CategoryID}')";

                SqlCommand cmd = new SqlCommand(insertString, conn);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(ProductIdALreadyPresent e)
            {
                e.Error1();
                return false;
            }
            catch(CategoryNotFound e)
            {
                e.Error();
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool UpdateProdcutPrice(int id, int price)
        {
            try
            {
                conn.Open();

                string UpdateString = $"update Product set Price = '{price}' where ProductId = '{id}";

                SqlCommand cmd = new SqlCommand(UpdateString, conn);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool UpdateProductName(int id, string name)
        {
            try
            {
                conn.Open();

                string UpdateString = $"update Product set ProductName = '{name}' where ProductId = '{id}'";

                SqlCommand cmd = new SqlCommand(UpdateString, conn);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool DeleteData(int id)
        {
            try
            {
                conn.Open();

                string DeleteString = $"delete from Product where ProductId = '{id}'";

                SqlCommand cmd = new SqlCommand(DeleteString, conn);

                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int GetNumberOfRecords()
        {
            int count = -1;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select count(*) from Category", conn);

                count = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return count;
        }
    }
}

