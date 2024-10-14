using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class InsurancePolicy
    {
        public InsurancePolicy()
        {
            UserCarsDetails = new HashSet<UserCarsDetail>();
        }

        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<UserCarsDetail> UserCarsDetails { get; set; }
    }
}
