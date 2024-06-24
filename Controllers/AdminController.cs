using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using MusicStore.Models.Repository;
using System.Linq;
namespace MusicStore.Controllers
{   
    [Authorize]
    public class AdminController : Controller
    {
        IAlbumRepository albumRepository;
        public AdminController(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }
        public ViewResult Index()
        {
            return View(albumRepository.Albums);
        }
        public ViewResult Edit(int Id) 
        {
            return View(albumRepository.Albums
                .FirstOrDefault(p => p.Id == Id));
        }
        [HttpPost]
        public IActionResult Edit(Album album) {
            if (ModelState.IsValid)
            {
                albumRepository.SaveAlbum(album);
                TempData["message"] = $"{album.Title} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(album);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Album());
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Album deletedProduct = albumRepository.DeleteProduct(Id);
            return RedirectToAction("Index");
        }
    }
}