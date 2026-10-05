# RestaurantTips agent guidance

## Project overview
- This repository is a small ASP.NET Core MVC application for collecting restaurant recommendations and showing the selected map location.
- Main application folders:
  - `Controllers/` for request handling
  - `Models/` for view models and data contracts
  - `Views/` for Razor UI
  - `wwwroot/` for static assets like CSS and JavaScript

## Working conventions
- Keep controller logic thin and focused on HTTP work.
- Keep the domain/data shape in model classes and view models.
- Put browser behavior in `wwwroot/js/site.js` and styling in `wwwroot/css/site.css` rather than embedding script inline in Razor views unless the change is truly view-specific.
- Preserve the existing MVC flow, form field names, and model binding names when altering the restaurant form or results pages.
- Prefer simple, explicit changes over broad refactors.

## Build and validation
- Typical local app commands:
  - `dotnet build`
  - `dotnet run`
  - `dotnet watch`
- This repo does not appear to include automated tests yet, so validate changes with a build and a quick app sanity check when appropriate.

## Focus area: map and mouse wheel zoom
- Map behavior is a client-side concern, not a server-side concern.
- If you add or adjust wheel-based zoom, prefer the relevant JavaScript file and keep the logic localized to the map interaction code.
- Avoid breaking page scrolling unexpectedly; only suppress default scroll behavior when the map interaction explicitly requires it.
- Preserve native map usability and accessibility, and do not disable zoom controls or trackpad gestures without a clear requirement.
- Keep changes consistent with the existing Leaflet/OpenStreetMap setup and the MVC structure already used in this app.
