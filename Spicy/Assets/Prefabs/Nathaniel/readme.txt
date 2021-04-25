---------------------------------------------------
----------Enemy Prefab Documentation-----------
---------------------------------------------------

Unity Version: 2019.4.18f1
Prefab file description: Enemy(ies)
Prefab Role: Inflict damage towards player and add style

---------------------------------------------------
-----------Tomato-Enemy----------------------------
---------------------------------------------------
Animation Art: Completed by Nathaniel Palmer

Role/Movement Pattern: 
-Cascading waterfall style. 
-Not aggressive, simple player touch inflicts damage
-Detects wall and ground. 
-Direct vertical fall when not touching ground
-Random movement direction on spawn


Animations:
-PNG files located in Assets/Art/Nathaniel/Enemies/Tomoto
-There are 3 animations:
----Death, Walking, Idle
-Death triggered by Die() method being called
-Walking triggered by horizontal change
-Idle triggered by vertical change

---------------------------------------------------
-----------Flying-Eyeball-Enemy--------------------
---------------------------------------------------
Animation Art: Created by Matt Makes Games, Inc. from Towerfall

Role/Movement Pattern: 
-Horizontal Patrol 
-Aggressive, when player is within range, Eyeball will shoot eyes
-Detects wall and ground. 
-Faces player direction when player is within the given radius


Animations:
-PNG files located in Assets/Art/Nathaniel/Enemies/Eyeball
-There are 1 animation:
----Flying
-Bullet travels towards player when player within "wire sphere"
-No death animation: gameobject destroyed

---------------------------------------------------
-------------Eyeball-Projectile--------------------
---------------------------------------------------
Animation Art: Created by Matt Makes Games, Inc. from Towerfall

Role/Movement Pattern: 
-Child of Flying-Eyeball
-Is created and directed towards the player


Art:
-PNG files located in Assets/Art/Nathaniel/Enemies/Eyeball

