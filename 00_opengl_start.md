# OpenGL Basisoefeningen

- lees:

Deze reeks oefeningen sluit aan op je huidige projectopzet met **OpenTK**, een `MainWindow` met een `MainDefaultShader`, en je `Shape`-hiërarchie (waar `Plane`, `Circle` en `Triangle` van erven). In je project worden de matrices als uniforms doorgegeven met o.a. `shader.SetModelM(...)`, `shader.SetMatrix4("view", ...)`, en `shader.SetMatrix4("projection", ...)`. Je `Plane` rendert via `plane.Renderer()` en bindt automatisch zijn VAO/VBO. (Zie je huidige `MainWindow.cs` voor de basis. )


- clone deze repository
    - https://github.com/progsen/opengl_cs_exercises
    - kijk in de map `GLColorDemo`

    - Build & Run
        > mogenlijk moet je nog even een `dotnet restore` doen! 
---

## Oefening 1.A — Beweeg het vlak **met de view-matrix**
**Doel:** Begrijpen dat verplaatsing van de camera (view) hetzelfde effect heeft als het tegengesteld verplaatsen van de wereld.

- Laat het vierkant over de X-as bewegen door de model-matrix te wijzigen:
    - schuif het vierkant 1 op
    > Hint: Matrix4.CreateTranslation

- lees:
```
    - Translations zijn hoe we het verplaatsen noemen. 
    - Als we in Unity kijken zit er in de transform een position. 
        - deze position wordt uiteindelijk een Translation matrix
    

```

## Oefening 1.B
**Doel:** zelf een matrix maken die het object beweegt

- lees eerst deze text:
  - [00_translation_matrix_opengl.md](00_translation_matrix_opengl.md)

- pas nu je opdracht van 1.A aan:
    1) pak de float[] uit de tekst, zet die bij je translate code in de buurt
    2) gebruik de function hieronder die in Shader.cs staat om je float[] matrix te gebruiken
        - let op dat je je `Matrix4.CreateTranslation` code uitzet (commentaar)
        > public void SetMatrix4(string name, float[] data)
---

## Oefening 2 — Rij van vlakken, zelfde `Plane` hergebruiken
**Doel:** Meerdere instanties tekenen door uitsluitend de **model-matrix** te variëren.

- Teken b.v. 5 vlakken in een rij: i ∈ {−2, −1, 0, 1, 2}.
- Gebruik één en dezelfde `Plane`-instantie.
- Voor elke instantie: `model = Matrix4.CreateTranslation(i * gap, 0, 0)`; vervolgens `shader.SetModelM(model)` en `plane.Renderer()`.
- Kies een mooie `gap` (bijv. 1.2f).

**Checklist**
- Eén `Plane`, meerdere draw-calls met andere model-matrices.

---

## Oefening 3 — Maak een **grid** van vlakken
**Doel:** Geneste lussen en 2D positionering met de model-matrix.

- Teken bijvoorbeeld 3 rijen × 5 kolommen.
- Gebruik twee gaps: `gapX`, `gapY`.
- Bepaal de offset zodat het grid gecentreerd is (bijv. start op negatieve offsets).

**Checklist**
- Dubbele for-lus (y-rijen, x-kolommen).
- Per tegel: `model = T(x,y) * R * S` (rotatie/schaal optioneel).

---

## Oefening 4 — Render **alle drie**: `Plane`, `Circle`, `Triangle`
**Doel:** Meerdere `Shape`-subklassen laden en tekenen.

- Maak velden aan voor `Circle` en `Triangle` en roep `Load(shader)` aan in `OnLoad()`.
- Positioneer ze met verschillende model-matrices (bijv. links = Triangle, midden = Plane, rechts = Circle).
- Zorg dat ze **op dezelfde z** staan om overlap in oefening 5 te kunnen zien.

**Checklist**
- Drie objecten, ieder met eigen `model`.

---

## Oefening 5 — **Tekenvolgorde**: wie ligt bovenop zonder diepte-test?
**Doel:** Begrijpen dat zónder depth test de **laatst getekende** bovenop ligt.

- Laat de diepte-test uit.
- Teken de drie vormen in verschillende volgordes en observeer wie visueel “bovenop” ligt.
- Conclusie: zonder Z-buffer bepaalt **de volgorde van draw-calls** de overlapping.

**Checklist**
- Z-buffer **uit** (geen `GL.Enable(DepthTest)`).
- Bewuste wijziging van de tekenvolgorde.

---

## Oefening 6 — Z‑as verplaatsen, daarna Z‑buffer aanzetten
**Doel:** Painter’s algorithm vs. depth testing begrijpen.

1. **Zonder Z‑buffer:**
   - Geef elke vorm een andere z‑positie (bijv. Triangle z=0, Circle z=−1, Plane z=−2).
   - **Teken expres verkeerd**: render de **verste** als **laatste** zodat deze, ondanks zijn grotere diepte, alles overschildert.
2. **Z‑buffer aan:**
   - Zet `GL.Enable(DepthTest)` aan (eenmalig in `OnLoad()`).
   - Wis elke frame met `GL.Clear(ColorBufferBit | DepthBufferBit)` en (optioneel) `GL.ClearDepth(1.0)`. Laat dezelfde (verkeerde) draw-volgorde staan.
   - Observeer: nu wordt toch de juiste diepte-occlusie toegepast.

**Checklist**
- Eerst fout zichtbaar zónder depth test.
- Daarna **alleen** depth aan + depth clear; **géén** volgorde-aanpassing nodig.

---

### Bonusideeën
- Laat de camera **in- en uitzoomen** met het muiswiel (pas `projection` of `view` aan).
- Maak per vorm een eigen kleur en laat deze lerarenopdracht visueel duidelijker zien.

### Hints
- `StartFrame()` is een logische plek voor `shader.Use()` en het zetten van view/projection.
- Je huidige `MainWindow` gebruikt `LookAt(new Vector3(0,0,10), new Vector3(), Vector3.UnitY)` en een perspectief FOV van 90°. Pas daar opgave 1 toe.
- Vergeet niet dat **CCW** standaard de front face is; bij culling kan volgorde of winding effect hebben.

Veel succes!






---------




- Gebruik een tijdsvariabele (accumuleer `e.Time`) om een vloeiende beweging te krijgen.
- Pas in `SetupViewMatrices()` de **camera-positie** aan (bijv. `x = sin(t) * 2`).
- Gebruik `Matrix4.LookAt(new Vector3(x, 0, 10), Vector3.Zero, Vector3.UnitY)`.

**Checklist**
- Geen wijzigingen aan `model`.
- Alleen de **view** verandert in de tijd.