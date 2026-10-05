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


```

POST-metoden mottar data fra skjemaet:

```csharp
[HttpPost]
public IActionResult Index(RestaurantViewModel model)
{
    if (!ModelState.IsValid)
    {
        return View(model);
    }

    return View("Result", model);
}
```

### Views

Applikasjonen har to sentrale Views:

- `Index.cshtml` viser skjemaet og kartet.
- `Result.cshtml` viser restaurantanbefalingen og valgt posisjon.

Dataflyten i applikasjonen er:

`Nettleser → GET → RestaurantController → Index View`

Brukeren fyller deretter ut skjemaet og velger en posisjon på kartet.

`Nettleser → POST → RestaurantController → RestaurantViewModel → Result View`

## Kart

Kartfunksjonen er laget med Leaflet og kartdata fra OpenStreetMap.

Når brukeren klikker på kartet, henter JavaScript latitude og longitude for punktet. Koordinatene lagres i skjulte felt i skjemaet og sendes til serveren sammen med resten av restaurantdataene.

På resultatsiden brukes koordinatene til å opprette et nytt kart med en markør på stedet brukeren valgte.

## Responsivt design

Applikasjonen bruker Bootstrap som følger med ASP.NET Core MVC-prosjektet.

Bootstrap og responsive komponenter gjør at innholdet tilpasser seg forskjellige skjermstørrelser.

## Drift med Docker

Applikasjonen kan bygges og kjøres i Docker.

Bygg Docker-imaget:

```bash
docker build -t restauranttips .
```

Start containeren:

```bash
docker run --rm -p 8080:8080 restauranttips
```

Applikasjonen kan deretter åpnes på:

`http://localhost:8080/Restaurant`

## Testing

Applikasjonen er testet manuelt under utviklingen.

### Testscenarioer og resultater

| Test | Forventet resultat | Resultat |
|---|---|---|
| Åpne `/Restaurant` | Skjema og kart vises | Bestått |
| Skrive inn restaurantnavn | Navnet registreres | Bestått |
| Velge mattype | Valgt mattype registreres | Bestått |
| Velge vurdering | Vurdering mellom 1 og 5 registreres | Bestått |
| Skrive kommentar | Kommentaren registreres | Bestått |
| Klikke på kartet | Markør og koordinater vises | Bestått |
| Sende skjemaet | POST-forespørselen behandles | Bestått |
| Vise resultatsiden | Restaurantdata vises | Bestått |
| Vise kartdata | Latitude og longitude vises | Bestått |
| Resultatkart | Valgt posisjon vises med markør | Bestått |
| Bygge med `dotnet build` | Prosjektet bygger uten feil | Bestått |
| Kjøre med Docker | Applikasjonen kjører på port 8080 | Bestått |

## Feilsøking under utvikling

Under utviklingen oppstod det et problem med latitude og longitude.

JavaScript sendte koordinater med punktum som desimalskilletegn, for eksempel `58.15`. ASP.NET forsøkte å tolke verdiene etter norsk tallformat. Dette førte til valideringsfeil for latitude og longitude.

Problemet ble løst ved å behandle koordinatene som tekstverdier i ViewModel-en. Koordinatene kan dermed sendes mellom sidene og konverteres til tall i JavaScript når kartet på resultatsiden opprettes.


## Bruk av AI

AI ble brukt som et støtteverktøy under deler av utviklingen av prosjektet.

AI ble hovedsakelig brukt til:

- Ideutvikling og planlegging av applikasjonen
- Forklaring av MVC-strukturen
- Veiledning ved implementering av kart med Leaflet
- Hjelp til feilsøking under utviklingen
- Forslag til strukturering av dokumentasjonen

Koden og funksjonaliteten ble testet underveis, og nødvendige endringer ble gjort basert på testresultatene.

### Eksempler på prompts

Noen eksempler på prompts som ble brukt:

- "Hvilke alternativer har jeg for et ASP.NET Core MVC-prosjekt?"
- "Hvordan kan jeg bruke Leaflet-kart i en ASP.NET Core MVC-applikasjon?"
- "Hvordan kan data fra et skjema sendes med POST og vises på en resultatside?"
- "Hvorfor får jeg valideringsfeil på latitude og longitude?"

AI ble brukt som hjelp til forklaringer, forslag og feilsøking, mens applikasjonen ble bygget og testet gjennom utviklingsprosessen.

## Hvordan kjøre prosjektet uten Docker

Prosjektet krever .NET SDK.

Kjør følgende kommando fra prosjektmappen:

```bash
dotnet run
```

Åpne adressen som vises i terminalen og gå til:

`/Restaurant`

## Prosjektstruktur

```text
RestaurantTips/
├── Controllers/
│   └── RestaurantController.cs
├── Models/
│   └── RestaurantViewModel.cs
├── Views/
│   └── Restaurant/
│       ├── Index.cshtml
│       └── Result.cshtml
├── wwwroot/
├── Dockerfile
├── Program.cs
├── README.md
└── RestaurantTips.csproj
```