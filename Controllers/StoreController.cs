using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        public string Index()
        {
            return "This will be the Store section";
        }
    }
}
