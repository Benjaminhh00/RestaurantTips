using Microsoft.AspNetCore.Mvc;
using RestaurantTips.Models;

namespace RestaurantTips.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: /Restaurant
        // Viser skjemaet til brukeren.
        [HttpGet]
        public IActionResult Index()
        {
            return View(new RestaurantViewModel());
        }

        // POST: /Restaurant
        // Mottar informasjonen brukeren har skrevet inn.
        [HttpPost]
        public IActionResult Index(RestaurantViewModel model)
        {
            // Kontrollerer valideringsreglene i RestaurantViewModel.
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Hvis alt er gyldig, sendes dataene videre
            // til resultatsiden.
            return View("Result", model);
        }
    }
}