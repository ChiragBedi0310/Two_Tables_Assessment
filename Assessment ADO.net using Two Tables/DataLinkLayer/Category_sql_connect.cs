using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;

namespace DataLinkLayer
{
    public class CategoryAlreadyLinked : Exception
    {
        public void Error()
        {
            Console.WriteLine("Category you are trying to delete is linked with a Product\nTo delete the Category you need to delete the Product first\n");
        }
    }
    public class Category_sql_connect
    {
        SqlConnection conn;

        public Category_sql_connect()
        {
            conn = new SqlConnection("Server = DEL1-LHP-N82143\\MSSQLSERVER01; Database = Assessment; Integrated Security = SSPI");
        }

        public void ReadData()
        {
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(@"Select pro.ProductId,pro.ProductName,pro.Price,pro.CategoryId,cat.CategoryName 
                            from Product pro join Category cat on pro.CategoryId = cat.CategoryId", conn);

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

        public bool InsertDataIntoCategory(Category c)
        {
            try
            {
                conn.Open();
                string insertString = $"Insert into Category values('{c.CategoryId}','{c.CategoryName}')";

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


        public bool UpdateCategoryName(int id, string name)
        {
            try
            {
                conn.Open();

                string UpdateString = $"update Category set CategoryName = '{name}' where CategoryId = '{id}'";

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

        private bool CategoryRelatedToProduct(int id)
        {
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("Select CategoryId from Product", conn);

                reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if ((int)reader[i] == id)
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

        public bool DeleteData(int id)
        {
            try
            {
                if (CategoryRelatedToProduct(id))
                {
                    throw new CategoryAlreadyLinked();
                }
                conn.Open();

                string DeleteString = $"delete from Category where CategoryId = '{id}'";

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
            catch(CategoryAlreadyLinked e)
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

