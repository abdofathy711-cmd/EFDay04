using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_System.model
{
    internal class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<product> Products { get; set; }
    }
}
