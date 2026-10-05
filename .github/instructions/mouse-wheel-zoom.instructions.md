---
applyTo: "**/*.{js,cshtml,css}"
description: "Use when: adding or adjusting mouse-wheel zoom, map scroll controls, or browser-level zoom interactions in the restaurant map UI."
---

# Mouse wheel zoom guidance

- Treat wheel zoom as a browser UI concern and keep it out of controllers and server-side logic.
- If the app is using a map library, prefer the library's built-in wheel zoom behavior over custom scroll interception unless the requirement explicitly says otherwise.
- Only call `preventDefault()` when the map interaction truly needs to capture wheel events; otherwise, let the page scroll normally.
- Keep trackpad and touch-pad gestures working as expected, and avoid disabling zoom in ways that surprise users.
- If a view-specific map behavior is needed, implement it in the matching script and keep the code small, readable, and easy to verify.
- Preserve the existing layout, form state, and map selection flow while changing zoom behavior.
