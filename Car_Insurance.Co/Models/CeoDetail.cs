using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class CeoDetail
    {
        public int Id { get; set; }
        public string? CeoName { get; set; }
        public string? CeoEmail { get; set; }
        public string? CeoPassword { get; set; }
    }
}
