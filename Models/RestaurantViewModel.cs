using System.ComponentModel.DataAnnotations;

namespace RestaurantTips.Models
{
    // ViewModel-en inneholder informasjonen som brukeren
    // registrerer om restauranten.
    // Dataene brukes både i skjemaet og på resultatsiden.
    public class RestaurantViewModel
    {
        // Restaurantnavn er obligatorisk.
        [Required(ErrorMessage = "Du må skrive inn navnet på restauranten.")]
        [Display(Name = "Restaurantnavn")]
        public string Name { get; set; } = "";

        // Brukeren må velge hvilken type mat restauranten tilbyr.
        [Required(ErrorMessage = "Du må velge type mat.")]
        [Display(Name = "Type mat")]
        public string FoodType { get; set; } = "";

        // Vurderingen skal være mellom 1 og 5.
        [Range(1, 5, ErrorMessage = "Vurderingen må være mellom 1 og 5.")]
        [Display(Name = "Vurdering")]
        public int Rating { get; set; }

        // Kommentar er valgfritt.
        [Display(Name = "Kommentar")]
        public string Comment { get; set; } = "";

        // Koordinatene kommer fra kartet når brukeren
        // klikker på ønsket plassering.
        // De lagres som tekst for å unngå problemer med
        // norsk desimalskilletegn ved innsending av skjemaet.
        public string Latitude { get; set; } = "";
        public string Longitude { get; set; } = "";
    }
}