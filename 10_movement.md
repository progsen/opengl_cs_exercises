
## Oefening 1
**Doel:** een sprite bewegen

- zorg dat je het keyboard kan uitlezen:
    > dit kan je in MainWindow.cs, die erft van GameWindow en die heeft een KeyboardState field/property waar je bij kan:
    > - KeyboardState.IsKeyDown
- gebruik nu de Translate om je sprite te bewegen,
    - let op dat je je frametime gebruikt

- zorg dat je `up,down,left` en `right` kan bewegen


## Oefening 2
**Doel:** een sprite roteren en 2 matrices kunnen vermenigvuldigen

- lees:
    ```
    onze plane heeft (0,0,0) als middelpunt:
    vertices = new float[]
    {
        0.5f,  0.5f, 0.0f,
        0.5f, -0.5f, 0.0f,
        -0.5f, -0.5f, 0.0f,
        -0.5f,  0.5f, 0.0f,
    };

    als een model niet (0,0,0) als middelpunt heeft wordt roteren iets lastiger. Onthoudt dat voor het geval dat je het nodig hebt!

    ```

- maak naast de translate matrix (voor je movement) ook een rotation matrix:
    - gebruik CreateRotationZ
        > let op deze wil een RADIUS niet een hoek in GRADEN
        > - je hebt MathHelper.DegreesToRadians nodig
    - zet de rotatie op 45 graden

- lees:
    ```

    - een Matrix kan je met een andere Matrix vermenigvuldigen:
    > matrix1 * matrix2
    - MAAR! het maakt uit welke links en rechts van de * staan
    ```

- maak een nieuwe Matrix met als resultaat (= ) de keersom van de translation en de rotation
    - probeer beide volgordes (zorg dat je je sprite beweegt zodat je het verschil kan zien)

## Oefening 3

- zorg dat je je sprite naar je beweeg richting laat kijken
    - dus voor  `up,down,left` en `right`



## Oefening 4

- zorg nu ervoor dat je sprite ook een beetje geschaald is