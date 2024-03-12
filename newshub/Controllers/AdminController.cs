using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using newshub.Data;
using newshub.Models;


namespace newshub.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserdbContext  db;

        public AdminController(UserdbContext db)
        {
            this.db = db;
        }
        public IActionResult userShow()
        {
            IEnumerable<Register> Users = db.Users;
            return View(Users);
        }
        public IActionResult Index()
        {
            Nadmin admin = new Nadmin();
            //IEnumerable<Nadmin> admin = db.Admin;
            
           
            return View(admin);
            
        }

       
    }
}
