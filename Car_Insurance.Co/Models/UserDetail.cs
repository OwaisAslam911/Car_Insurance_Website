using System;
using System.Collections.Generic;

namespace Car_Insurance.Co.Models
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            UserCarsDetails = new HashSet<UserCarsDetail>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Useremail { get; set; }
        public string? Userpassword { get; set; }
        public long? Usercontact { get; set; }

        public virtual ICollection<UserCarsDetail> UserCarsDetails { get; set; }
    }
}
