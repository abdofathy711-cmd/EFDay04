using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_System.model
{
    internal class product
    {
        public int ProductId { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public int categoryId { get; set; }
        public Category Cat1 { get; set; }
        public List<orderdetail> orderdetails { get; set; }

    }
}
