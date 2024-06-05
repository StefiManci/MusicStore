using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MusicStore.Models;
using MusicStore.Models.ViewModels;
using MusicStore.Models.Repository;
namespace MusicStore.Controllers
{
    public class CartController : Controller
    {
        private IAlbumRepository repository;
        private Cart cart;
        public CartController(IAlbumRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(string Title, string returnUrl)
        {
            Album album = repository.Albums
                   .FirstOrDefault(p => p.Title == Title);
            if (album != null)
            {
                cart.AddItem(album);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(string Title, string returnUrl)
        {
            Album music = repository.Albums
                .FirstOrDefault(p => p.Title == Title);
            if (music != null)
            {
                cart.RemoveLine(music);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}