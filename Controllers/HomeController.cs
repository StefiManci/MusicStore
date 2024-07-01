using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using MusicStore.Models.Repository;
using System.Linq;
using System.Threading.Tasks;
namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private IAlbumRepository repository;
        private UserManager<AppUser> userManager;
        public HomeController(IAlbumRepository repo,UserManager<AppUser> usr)
        {
            repository = repo;
            userManager = usr;
        }
        public ViewResult Index(string category)
        {
            return View(repository.Albums
            .Where(p => p.Genre == category || category == null)
            .Where(p=> p.Id<10));
        }
        public ViewResult Details(string detail)
        {
           return View(repository.Albums
            .Where(p => p.Title == detail));
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result = await userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login","Account");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(model);
        }
        public ActionResult Search(string inputvalue)
        {
            var totalAlbums = repository.Albums.ToList();
            var albums = repository.Albums
                .Where(p => p.Title.ToLower().Contains(inputvalue.ToLower()) 
                || p.Author.ToLower().Contains(inputvalue.ToLower()))
                .ToList();

            return View("Index", albums);
        }
    }
}