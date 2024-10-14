using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class ClaimInsurance
    {
        public ClaimInsurance()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public int? ClaimStatus { get; set; }
        public string? Planname { get; set; }
        public long? Insurancemonths { get; set; }

        public virtual ClaimStatus? ClaimStatusNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
