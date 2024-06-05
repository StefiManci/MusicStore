using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Controllers
{
    public class AdminController : Controller
    {
        public string Index()
        {
            return "This will be the Admin section";
        }
    }
}