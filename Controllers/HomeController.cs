using Microsoft.AspNetCore.Mvc;
using MusicStore.Models.Repository;
using System.Linq;
namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private IAlbumRepository repository;
        public HomeController(IAlbumRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(string category)
        {
            return View(repository.Albums
            .Where(p => p.Genre == category || category == null));
        }
        public ViewResult Details(string detail)
        {
           return View(repository.Albums
            .Where(p => p.Title == detail));
        }
        public ViewResult Search(string inputvalue)
        {
           return View("Index", repository.Albums
            .Where(p => p.Title.Contains(inputvalue) || p.Author.Contains(inputvalue))
            );
        }
    }
}