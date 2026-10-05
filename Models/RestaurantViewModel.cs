using System.ComponentModel.DataAnnotations;

namespace RestaurantTips.Models
{
    public class RestaurantViewModel
    {
        [Required(ErrorMessage = "Du må skrive inn navnet på restauranten.")]
        [Display(Name = "Restaurantnavn")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Du må velge type mat.")]
        [Display(Name = "Type mat")]
        public string FoodType { get; set; } = "";

        [Range(1, 5, ErrorMessage = "Vurderingen må være mellom 1 og 5.")]
        [Display(Name = "Vurdering")]
        public int Rating { get; set; }

        [Display(Name = "Kommentar")]
        public string Comment { get; set; } = "";

        // Disse verdiene skal senere hentes når brukeren
        // klikker på en posisjon på kartet.
        public string Latitude { get; set; } = "";


        public string Longitude { get; set; } = "";
    }
}