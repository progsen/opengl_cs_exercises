
## Oefening 4 — Render **alle drie**: `Plane`, `Circle`, `Triangle`
**Doel:** Meerdere `Shape`-subklassen laden en tekenen.


- lees:
```
    - er is code voor nog 2 andere vormen: circle & triangle
    - deze werken net als de Plane
    - Maar om deze te laten tekenen moeten de data 'geactiveerd' worden om van object te switchen
    - dit gebeurt in render (in shape.cs), met de Bind 
```


## Start

- maak een kopie van de GLColorDemo solution
    > we doen dit zodat we de oude code niet hoeven te verwijderen

## verschillende vormen
- Maak velden aan voor `Circle` en `Triangle` en roep `Load(shader)` aan in `OnLoad()`.
- Positioneer ze met verschillende model-matrices:
    - links = Triangle
    - midden = Plane
    - rechts = Circle

- laat de Z nog even hetzelfde.
