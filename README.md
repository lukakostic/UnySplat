# UnySplat
Splatoon-like painting in unity on any-shape mesh colliders, with some edge handling.

Left click - raycast paint (center of screen)
Right click - throw tomato (paint blob)

It just boils down to:
1. Make a good UV map (no overlapping  faces)
2. Raycast and get raycasthit.textureCoords
3. Extract x and y components and use SetPixel to paint
4. Add some paint randomization and spread, and some other stuff to make it look nicer


![splatoon](https://user-images.githubusercontent.com/41348897/43697933-b0da8f92-9947-11e8-922f-66328f1fd49f.png)
