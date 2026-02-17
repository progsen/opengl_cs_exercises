
# Translatiematrix in OpenGL  (co-pilot uitleg)

Een korte uitleg over de translatiematrix in OpenGL, met een `float[]` voorbeeld.

## Wat is een translatiematrix?
In OpenGL gebruik je een 4x4 matrix om objecten te verplaatsen (translatie) in 3D‑ruimte.

De matrix voor translatie naar `(x, y, z)` ziet er zo uit:

```
1 0 0 x
0 1 0 y
0 0 1 z
0 0 0 1
```

## Column-major in OpenGL
OpenGL gebruikt column‑major opslag, dus in een `float[]` vul je per kolom.

## Voorbeeld
Translatie van `(2.0, 3.0, -5.0)`:

```java
float[] translationMatrix = {
    1, 0, 0, 0,   // kolom 1
    0, 1, 0, 0,   // kolom 2
    0, 0, 1, 0,   // kolom 3
    2, 3, -5, 1   // kolom 4
};
```
