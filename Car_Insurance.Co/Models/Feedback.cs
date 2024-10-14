using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class Feedback
    {
        public int MessageId { get; set; }
        public string? Message { get; set; } 
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
    }
}
