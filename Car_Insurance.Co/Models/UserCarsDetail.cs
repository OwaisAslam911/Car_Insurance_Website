using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class UserCarsDetail
    {
        public UserCarsDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string? Carname { get; set; }
        public int? Carmodel { get; set; }
        public string? Carnumber { get; set; }
        public string? Carcolor { get; set; }
        public string? Enginenumber { get; set; }
        public string? Chasisnumber { get; set; }
        public long? Carrcc { get; set; }
        public int? Userid { get; set; }
        public string? City { get; set; }
        public string? Purpose { get; set; }
        public int? PolicyId { get; set; }

        public virtual InsurancePolicy? Policy { get; set; }
        public virtual UserDetail? User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
