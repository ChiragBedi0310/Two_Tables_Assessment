using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Category
    {
        string categoryname;
        int categoryId;

        public Category()
        {

        }
        public Category(string categoryname, int categoryid)
        {
            this.categoryname = categoryname;
            this.categoryId = categoryid;
        }
        public string CategoryName
        {
            get { return categoryname; }
            set { categoryname = value; }
        }

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
    }
}
