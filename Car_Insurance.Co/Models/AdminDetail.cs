using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class AdminDetail
    {
        public int Id { get; set; }
        public string? AdminName { get; set; }
        public string? AdminEmail { get; set; }
        public string? AdminPassword { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
