using Car_Insurance.Co.Data;
using Car_Insurance.Co.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace Car_Insurance.Co.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly car_insuranceContext context;
        private readonly IHttpContextAccessor accessor;

        public HomeController(ILogger<HomeController> logger,car_insuranceContext context,IHttpContextAccessor accessor)
        {
            _logger = logger;
            this.context = context;
            this.accessor = accessor;
        }

        public IActionResult Index()
        {
            //sessions
            var username = accessor.HttpContext.Session.GetString("username");
            if(username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult About()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Blog()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Contact()
        {

            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Feedback feedback)
        {
            Feedback feedback1 = new Feedback()
            {
                Name = feedback.Name,
                Email = feedback.Email,
                Subject = feedback.Subject,
                Message =feedback.Message
            };

           context.Feedbacks.Add(feedback);
            context.SaveChanges();
            return RedirectToAction("Contact");


            
        }
        public IActionResult InsuranceForm()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
            }
            else
            {
                return View("Login");
            }
            InsuranceViewModel insuranceForm = new InsuranceViewModel()
            {
                    userDetailTable = new UserDetail(),
                userCarDetail = new UserCarsDetail(),
                insurancePolicyTable = new InsurancePolicy(),
                orderDetail=new OrderDetail(),
                orderStatus = new OrderStatus()
            };

            
            return View(insuranceForm);
        }
        [HttpPost]
        public IActionResult InsuranceForm(InsuranceViewModel insurance,UserDetail user)
        {
            // for login by services
            var Ishow = context.UserDetails.Where(option => option.Useremail == user.Useremail || option.Username == user.Useremail && option.Userpassword == user.Userpassword).FirstOrDefault();
            if (Ishow != null)
            {
                accessor.HttpContext.Session.SetString("username", Ishow.Username);
                accessor.HttpContext.Session.SetString("useremail", Ishow.Useremail);
                accessor.HttpContext.Session.SetString("userpass", Ishow.Userpassword);
                return View();
            }
            else
            {
                ViewBag.failed = "Incorrect User Or Password";
            }
            // tolist with multiple table
            var show = context.UserDetails.Where(option => option.Useremail == insurance.userDetailTable.Useremail && option.Userpassword == insurance.userDetailTable.Userpassword).FirstOrDefault();
            //For password varification
            if (show != null)
            {
                // Adding Cardetail with user
                UserCarsDetail userCars = new UserCarsDetail()
                {
                    Carcolor = insurance.userCarDetail.Carcolor,
                    Carmodel = insurance.userCarDetail.Carmodel,
                    Carname = insurance.userCarDetail.Carname,
                    Carnumber = insurance.userCarDetail.Carnumber,
                    Carrcc = insurance.userCarDetail.Carrcc,
                    Chasisnumber = insurance.userCarDetail.Chasisnumber,
                    City = insurance.userCarDetail.City,
                    Enginenumber = insurance.userCarDetail.Enginenumber,
                    PolicyId = insurance.userCarDetail.PolicyId,
                    Purpose = insurance.userCarDetail.Purpose,
                    Userid = show.Id,


                };

                // For Billing Page
                accessor.HttpContext.Session.SetString("carName", userCars.Carname);
                accessor.HttpContext.Session.SetString("carNumber", userCars.Carnumber);
                //accessor.HttpContext.Session.SetString("chesisNumber", userCars.Chasisnumber);
                accessor.HttpContext.Session.SetString("city", userCars.City);
                accessor.HttpContext.Session.SetString("purpose", userCars.Purpose);
                accessor.HttpContext.Session.SetString("carcolor", userCars.Carcolor);
                accessor.HttpContext.Session.SetString("Carmodel", Convert.ToString(userCars.Carmodel));
                accessor.HttpContext.Session.SetString("carEngine", userCars.Enginenumber);
                accessor.HttpContext.Session.SetString("Carcc", Convert.ToString(userCars.Carrcc));


                // For orderdetail info
                var lastIndexId = context.UserCarsDetails.ToList();



                var lastIndex = lastIndexId.Count; // Index of the last item
                var lastItem = lastIndexId[lastIndex - 1];

                var policynumber = lastItem.PolicyId + 1100;
                var totalpolicy = policynumber;
                accessor.HttpContext.Session.SetString("policyNo", Convert.ToString(totalpolicy));
                OrderDetail orderDetail = new OrderDetail()
                {

                    CarId = lastItem.Id + 1,
                    StatusId = 1,
                    PlaneId = insurance.orderDetail.PlaneId
                };
                
                InsurancePolicy insurancePolicy = new InsurancePolicy()
                {
                    StartDate = insurance.insurancePolicyTable.StartDate,
                };
                // policy date session
                accessor.HttpContext.Session.SetString("policyStart",insurance.insurancePolicyTable.StartDate.ToString());
                insurancePolicy.UserCarsDetails = new List<UserCarsDetail> { userCars };

                accessor.HttpContext.Session.SetString("date", Convert.ToString(insurancePolicy.StartDate));

                context.UserCarsDetails.Add(userCars);
                context.InsurancePolicies.Add(insurancePolicy);
                context.SaveChanges();
                // for Adding orderdetail After save changes
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
                //for plan session
                var plan = context.PlansDetails.FirstOrDefault(option => option.Id == orderDetail.PlaneId);
                accessor.HttpContext.Session.SetString("planname", plan.Planname);
                accessor.HttpContext.Session.SetString("planprice", Convert.ToString(plan.Price));

                return RedirectToAction("BillingInfo");
            }
            else
            {
                ViewBag.failedpass = "Incorrect password";
            }
            return View();
        }
        public IActionResult NewsDetail()
        {

            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult NotFound()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult ServiceDetail()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Services()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Signup()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return RedirectToAction("NotFound");
            }
            return View();
        }
   
        [HttpPost]
        public IActionResult Signup(UserDetail user,string ConfirmPassword)
        {
            // For Validation
            var name = context.UserDetails.Where(option => option.Username == user.Username).FirstOrDefault();
            var email = context.UserDetails.Where(option => option.Useremail == user.Useremail).FirstOrDefault();

            //For signup Errors And Registration
            if(name != null && email != null)
            {
                ViewBag.uniquename = "The name you entered is already exist";
                ViewBag.uniqueemail = "The email you entered is already exist";
            }
            else if(name != null)
            {
                ViewBag.uniquename = "The name you entered is already exist";
            }else if(email != null)
            {
                ViewBag.uniqueemail = "The email you entered is already exist";
            }
            else
            {

            if(ConfirmPassword == user.Userpassword)
            {
                context.UserDetails.Add(user);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.confirmpass = "Password is not match";
            }
            }
            return View();
        }
        // For Login and Session
        public IActionResult Login()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return RedirectToAction("NotFound");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserDetail user)
        {
            //For Login
            var show = context.UserDetails.Where( option => option.Useremail == user.Useremail || option.Username == user.Useremail && option.Userpassword == user.Userpassword).FirstOrDefault();
            if (show != null)
            {
                accessor.HttpContext.Session.SetString("username", show.Username);
                accessor.HttpContext.Session.SetString("useremail", show.Useremail);
                accessor.HttpContext.Session.SetString("userpass", show.Userpassword);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.failed = "Incorrect User Or Password";
            }
           
            return View();
        }
        // For session destroy
        public IActionResult Logout()
        {
            var user = accessor.HttpContext.Session.GetString("username");
            if(user != null)
            {
                accessor.HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }
            return RedirectToAction("NotFound");
        }
        public IActionResult Team()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult TeamDetail()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Tearms()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }
        public IActionResult Privacy()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            return View();
        }

		public IActionResult BillingInfo()
		{
            var cardata = accessor.HttpContext.Session.GetString("carName");
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null && cardata != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            else
            {
                return RedirectToAction("NotFound");
            }
		}
        public IActionResult ThankyouForm()
        {
            var username = accessor.HttpContext.Session.GetString("username");
            if (username != null)
            {
                ViewBag.sessionuser = username;
                return View();
            }
            else
            {
                return RedirectToAction("NotFound");
            }
        }




		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}