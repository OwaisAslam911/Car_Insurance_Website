using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class PlansDetail
    {
        public PlansDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string? Planname { get; set; }
        public long? Insurancemonths { get; set; }
        public long? Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
