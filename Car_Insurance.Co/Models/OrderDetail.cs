using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public int? PlaneId { get; set; }
        public int? StatusId { get; set; }
        public int? ClaimId { get; set; }

        public virtual UserCarsDetail? Car { get; set; }
        public virtual ClaimInsurance? Claim { get; set; }
        public virtual PlansDetail? Plane { get; set; }
        public virtual OrderStatus? Status { get; set; }
    }
}
