# 🍴 RestaurantTips

RestaurantTips er en ASP.NET Core MVC-applikasjon hvor brukeren kan anbefale en restaurant, gi restauranten en vurdering og velge restaurantens plassering på et interaktivt kart.

Applikasjonen demonstrerer MVC-arkitektur, GET- og POST-forespørsler, skjemabehandling, dynamisk innhold, interaktive kart og containerbasert kjøring med Docker.

## Funksjonalitet

Brukeren kan:

- Skrive inn navnet på en restaurant
- Velge type mat
- Gi restauranten en vurdering fra 1 til 5
- Skrive en kommentar
- Velge restaurantens plassering på et interaktivt kart
- Sende inn anbefalingen
- Se informasjonen på en egen resultatside
- Se valgt posisjon på kartet på resultatsiden

## Teknologier

Prosjektet bruker:

- ASP.NET Core MVC
- C#
- Razor Views
- HTML
- CSS
- Bootstrap
- JavaScript
- Leaflet
- OpenStreetMap
- Docker
- Git og GitHub

## Systemarkitektur

Applikasjonen bruker MVC (Model-View-Controller).

### Model / ViewModel

`RestaurantViewModel` inneholder data om restaurantanbefalingen:

- Restaurantnavn
- Type mat
- Vurdering
- Kommentar
- Latitude
- Longitude

ViewModel-en brukes til å transportere data mellom View og Controller.

### Controller

`RestaurantController` håndterer forespørsler fra brukeren.

GET-metoden viser skjemaet:

```csharp
[HttpGet]
public IActionResult Index()
{
    return View(new RestaurantViewModel());
}