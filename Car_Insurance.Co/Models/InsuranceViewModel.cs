namespace Car_Insurance.Co.Models
{
    public class InsuranceViewModel
    {
        public UserDetail userDetailTable { get; set; }
        public UserCarsDetail userCarDetail { get; set; }
        public InsurancePolicy insurancePolicyTable { get; set; }
        public OrderDetail orderDetail { get; set; }
        public OrderStatus orderStatus { get; set; }

    }
}
