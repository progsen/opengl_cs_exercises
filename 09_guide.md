# 1. Houd animatietijd bij
Voor elke animatie moet je twee dingen bijhouden:

- hoeveel tijd het huidige frame al actief is
- welk frame op dit moment afgespeeld wordt

Elke update voeg je de tijd sinds de laatste frame-update toe aan je “frametijd”.
Wanneer deze waarde groter wordt dan de ingestelde tijd per frame, moet je:

1) de tijd weer terugzetten naar 0
2) naar het volgende frame gaan
3) de UV‑coördinaten van dat frame toepassen


# 2. Gebruik een float[][] voor je UV’s
In plaats van berekenen tijdens het afspelen, kun je:

- één tweede‑dimensionale float‑array gebruiken
- elke “rij” (float[]) bevat precies 8 UV‑waarden voor één frame

Structuur:

- uv[0] = UV’s van frame 0
- uv[1] = UV’s van frame 1
- enzovoort

Dit maakt het wisselen van frames heel eenvoudig:
je kijkt gewoon in het uv‑array welke set hoort bij de huidige frame‑index.

# 3. UV’s berekenen (als je ze niet handmatig invult)
Als je spritesheet netjes is opgezet:

- alle frames staan horizontaal naast elkaar
- elk frame heeft dezelfde breedte

Dan kun je de UV‑offset per frame berekenen op basis van:

```
frameIndex × (breedte van één frame in UV‑ruimte)
```
Voorbeeld:

- als één frame 0.5 UV breed is
- dan begint frame 0 op 0.0
- frame 1 op 0.5
- frame 2 op 1.0
- enz.

Met deze formule kun je automatisch je float[][] vullen.

# 4. Naar het volgende frame gaan
Wanneer de timer zegt dat het tijd is voor een nieuw frame:

- verhoog je de frame‑index
- spring je terug naar 0 als je over het laatste frame heen gaat
- haal je de bijbehorende UV‑set uit uv[frame]
- stuur je die UV’s naar je sprite
- ververs je de buffer zodat de nieuwe UV’s zichtbaar zijn


# 5. UV’s toepassen
Per frame pak je de acht UV‑waarden in uv[frame].
Deze staan in de volgorde die jouw sprite‑systeem verwacht, zoals:

- rechter bovenhoek
- rechter onderhoek
- linker onderhoek
- linker bovenhoek

Daarna laat je de sprite zijn vertex/UV‑data opnieuw combineren en opnieuw binden zodat de UV‑wijziging direct zichtbaar wordt.

# Korte samenvatting

- houd bij hoe lang een frame actief is
- als de tijd per frame is overschreden ⇒ volgende frame
- alle UV’s staan klaar in een float[][]
- elke rij bevat 8 UV‑waarden die de hoeken van het frame aangeven
- op basis van de frame‑index haal je de UV’s op en pas je ze toe