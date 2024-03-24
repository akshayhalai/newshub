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
            
            
           
            return View(admin);
            
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Register user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return RedirectToAction("userShow","Admin");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                Register Users = db.Users.Find(id);
                return View(Users);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Register users, int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {

                db.Users.Update(users);
                db.SaveChanges();
                return RedirectToAction("userShow","Admin");
            }
        }

      
        public IActionResult Delete()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var student = db.Users.Find(id);
                db.Users.Remove(student);
                db.SaveChanges();
                return RedirectToAction("userShow", "Admin");
            }
        }

    }

}

