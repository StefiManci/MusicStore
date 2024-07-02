using Microsoft.AspNetCore.Mvc;
using MusicStore.Models.Repository;
using System.Linq;
namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        public IAlbumRepository repository;
        public StoreController(IAlbumRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index(string category)
        {
            return View(repository.Albums
              .Where(p => p.Genre == category || category == null));
        }
        public ViewResult Search(string inputvalue)
        {
            return View("Index", repository.Albums
             .Where(p => p.Title.Contains(inputvalue) || p.Author.Contains(inputvalue))
             );
        }
    }
}
