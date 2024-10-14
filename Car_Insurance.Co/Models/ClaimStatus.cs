using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class ClaimStatus
    {
        public ClaimStatus() 
        {
            ClaimInsurances = new HashSet<ClaimInsurance>();
        }

        public int ClaimId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<ClaimInsurance> ClaimInsurances { get; set; }
    }
}
