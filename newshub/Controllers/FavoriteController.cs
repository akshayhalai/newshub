using Microsoft.AspNetCore.Mvc;

namespace newshub.Controllers
{

    public class FavoriteController : Controller
    {
        private const string SessionKey = "FavoriteArticles";

        [HttpPost]
        public IActionResult AddToFavorites(
            string articleTitle,
            string articleImage,
            string articleDescription,
            string articleUrl,
            string articleChannel
        )

        {
            var userId = HttpContext.Session.GetString("userID");
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "Please login first." });
            }



            var favorites = HttpContext.Session.GetObject<List<string>>(SessionKey) ?? new List<string>();

           
            if (!favorites.Contains(articleTitle))
            {
                favorites.Add(articleTitle);
                favorites.Add(articleImage);
                favorites.Add(articleDescription);
                favorites.Add(articleUrl);
                favorites.Add(articleChannel);

                HttpContext.Session.SetObject(SessionKey, favorites);
            }

            return Json(new { success = true });
        }

        public IActionResult Index()
        {
            var favorites = HttpContext.Session.GetObject<List<string>>(SessionKey) ?? new List<string>();
            return View(favorites);
        }
    }
}

//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using newshub.Models;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using newshub.Data;

//namespace newshub.Controllers
//{
//    [Authorize]
//    public class FavoriteController : Controller
//    {
//        private readonly UserManager<Register> _userManager;
//        private readonly UserdbContext db;

//        public FavoriteController(UserManager<Register> userManager, UserdbContext db)
//        {
//            _userManager = userManager;
//            this.db = db;
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddToFavorites(string articleTitle)
//        {
//            var user = await _userManager.GetUserAsync(User);
//            if (user != null)
//            {
//                // Associate the favorite article with the current user
//                var favorite = new Favorite { UserId = user.userID, ArticleTitle = articleTitle };
//                // Add code to save the favorite to the database
//                db.Favoriteuser.Add(favorite);
//                await db.SaveChangesAsync();
//                return Json(new { success = true });
//            }
//            return Json(new { success = false });
//        }

//        public async Task<IActionResult> Index()
//        {
//            var user = await _userManager.GetUserAsync(User);
//            if (user != null)
//            {
//                // Retrieve favorite articles associated with the current user
//                var favorites = await db.Favoriteuser.Where(f => f.UserId == user.userID).ToListAsync();
//                return View(favorites);
//            }
//            return View(new List<Favorite>());
//        }
//    }
//}
