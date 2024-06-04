using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private IAlbumRepository repository;
        public HomeController(IAlbumRepository repo)
        {
            repository = repo;
        }
        //change the methods
        public ViewResult Index(string category) => View(repository.Albums
            .Where(p => p.Genre == category || category == null));

        public ViewResult Details(string detail) => View(repository.Albums
            .Where(p => p.Title == detail));

        public ViewResult Search(string inputvalue) => View("Index", repository.Albums
            .Where(p => p.Title.Contains(inputvalue) || p.Author.Contains(inputvalue))
            );

    }
}
