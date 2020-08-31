using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.Models.ViewModels
{
    public class OrderDetailsVM
    {
        public OrderHeader OrderHeader { get; set; }

        public IEnumerable<OrderDeatils> OrderDeatils { get; set; }
    }
}
