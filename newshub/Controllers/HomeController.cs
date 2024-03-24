using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newshub.Data;
using newshub.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using newshub.Controllers;
using System.Security.Claims;
using Newtonsoft.Json;
namespace newshub.Controllers
   
{
    public class HomeController : Controller
    {

       
        private readonly ILogger<HomeController> _logger;
        private readonly UserdbContext db;
        public HomeController(UserdbContext db, ILogger<HomeController> logger)
        {
            this.db = db;
            _logger = logger;
        }
        //public IActionResult Index()
        //{
        //    IEnumerable<cardData1> cardData = db.cardData;
        //    return View(cardData);

        //}



        private const string API_KEY = "ec793e9876c8aa92a93d1c509feb8b1f";
        public async Task<IActionResult> Index(string category = "general")
        {
            using (var client = new HttpClient())
            {
                var url = $"https://gnews.io/api/v4/top-headlines?category={category}&lang=en&country=us&apikey={API_KEY}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                return View(data.Articles);
                
            }
        }






        public IActionResult Register()
        {
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register register)
        {
            if(db.Users.Any(x=>x.uname == register.uname))
            {
                ViewBag.Notification = "This account has already existed";
                return View();
            }
            else
            {
                db.Users.Add(register);
                db.SaveChanges();
                return RedirectToAction("Login","Home");
            }

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Register register,Nadmin admin)
        {
                
            var adminLogin = db.Admin.Where(x => x.uemail == admin.uemail && x.upass == admin.upass).Select(x => new { x.Id, x.name }).FirstOrDefault();
                if (adminLogin != null)
            {
                HttpContext.Session.SetString("ID", adminLogin.Id.ToString());
                HttpContext.Session.SetString("name", adminLogin.name.ToString());
                TempData["Message"] = "Welcome, "+ adminLogin.name.ToString();

                return RedirectToAction("Index", "Admin");

            }

            else
            {
                var checkLogin = db.Users.Where(x => x.uemail.Equals(register.uemail) && x.upass.Equals(register.upass)).Select(x => new { x.userID, x.uname }).FirstOrDefault();
                if (checkLogin != null)
                {

                    HttpContext.Session.SetString("userID", checkLogin.userID.ToString());
                    HttpContext.Session.SetString("uname", checkLogin.uname.ToString());

                    TempData["Message"] = "Welcome," + checkLogin.uname.ToString();

                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    
                    ViewBag.Notification = "Enter Wrong Email or Password";
                }
            }
            
            return View();
            
        }

        
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("ID");
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index", "Home");
        }
        //public IActionResult General()
        //{
        //    IEnumerable<cardData1> cardData = db.cardData;
        //    return View(cardData);
        //}
        //public IActionResult Home()
        //{
        //    IEnumerable<cardData1> cardData = db.cardData;
        //    return View(cardData);
        //}
        // public IActionResult Business()
        //{
        //    IEnumerable<cardData1> cardData = db.cardData;
        //    return View(cardData); 
            
        //}
        // public IActionResult Sport()
        //{
        //    IEnumerable<cardData1> cardData = db.cardData;
        //    return View(cardData);
        //}
        // public IActionResult Science()
        //{
        //    IEnumerable<cardData1> cardData = db.cardData;
        //    return View(cardData);
        //}
        //public IActionResult Health()
        //{
        //    IEnumerable<cardData1> cardData = db.cardData;
        //    return View(cardData);
        //}
        //public IActionResult Entertainment()
        //{
        //    IEnumerable<cardData1> cardData = db.cardData;
        //    return View(cardData);
        //}
        //public IActionResult Technology()
        //{
        //    IEnumerable<cardData1> cardData = db.cardData;
        //    return View(cardData);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }

}
