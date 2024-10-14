using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int StatusId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
