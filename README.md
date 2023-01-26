# AR-RayCast
Augmented Reality Project based on Ray Cast Technology using XR Package of Unity and C#

Using augmented reality and ray cast technologies provided by unity and C#, an android application of android version >=7.0 is built.

Ground plane must first be detected by the application.

With each touch a random 3D object would appear that has its own sound effect and animation.

Upon touching again a new object appears.

No object appears twice in a row.

You can place the object where you want by dragging your touch, so instead of "touch.end" , I used "touch.moved" in my script.

Incase you want to drag and drop the object by moving your touch and not just ending it instantly, make sure first that the whole place you will be moving (dragging and dropping) your object through is already detected by the application by finding the PNG spots on it, if that is not the case, your object will be placed on the last dragged detected coordinates on your mobile screen.

This is a 3D Project.

For better resolution, check out this link , as the below demo is compressed:

https://drive.google.com/file/d/1yfIwJLbZsLW4RuLsI8p3SuWX7719pD9a/view?usp=sharing

https://user-images.githubusercontent.com/112272836/194929786-b86bcb6d-40d3-4c10-aaa9-1cccf746e557.mp4


