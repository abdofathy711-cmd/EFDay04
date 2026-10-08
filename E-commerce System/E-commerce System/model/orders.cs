using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_System.model
{
    internal class orders
    {
        public int OrdersId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public custmer Cus1 { get; set; }
        public List<orderdetail> orderdetails { get; set; }
    }
}
