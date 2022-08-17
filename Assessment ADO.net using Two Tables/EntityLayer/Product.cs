using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Product
    {
        string name;
        int price, id, categoryId;

        public Product(string name, int id, int price, int categoryid)
        {
            this.name = name;
            this.price = price;
            this.id = id;
            this.categoryId = categoryid;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int CategoryID
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
    }
}
