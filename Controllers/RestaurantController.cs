using Microsoft.AspNetCore.Mvc;
using RestaurantTips.Models;

namespace RestaurantTips.Controllers
{
    // Controlleren håndterer sidene for restaurantanbefalinger.
    // Den mottar forespørsler fra nettleseren og bestemmer
    // hvilken View som skal vises.
    public class RestaurantController : Controller
    {
        // GET: /Restaurant
        // Kalles når brukeren åpner restaurantsiden.
        // Oppretter en tom ViewModel og sender den til skjemaet.
        [HttpGet]
        public IActionResult Index()
        {
            return View(new RestaurantViewModel());
        }

        // POST: /Restaurant
        // Kalles når brukeren trykker "Send anbefaling".
        // ASP.NET Core fyller RestaurantViewModel med data
        // som brukeren har skrevet inn i skjemaet.
        [HttpPost]
        public IActionResult Index(RestaurantViewModel model)
        {
            // Hvis valideringen feiler, vises skjemaet på nytt.
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Gyldige data sendes videre til resultatsiden.
            return View("Result", model);
        }
    }
}