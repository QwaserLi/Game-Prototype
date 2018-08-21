# WorkForce

The game loop is done through the update function, triggers and colliders. The Level gameobject constantly checks for when the play health is 0 or if the player has reached the goal and will
display the corrent endgame screen depending on the state. Most of the movement logic is done within the update function of the script attached the gameobject.
Most of the rest of the logic is done through the triggers and colliders, where they will either set booleans which changes the action the update function uses or call 
functions directly to do whatever is desired.

The level structure is made so that all the entities(Player,AI etc) will interact with each other based on their script. The AI will avoid certain objects in the level, based on the 
NavMesh, so as long as the NavMesh is baked with the specific objects in mind then, the AI should follow their path(as long as a node on the path isn't in a dead zone) moving around the environment 
and chase the player when they see them. The player should just collide with all entities that have a collider and rigidbody on them, objects with the tag "Wall" stops the player so
they can't walk through walls. Certain objects within the level are power ups that can be collected by the player and will disappear upon collection.


Small script to fade the screen and transition to a different scene:
https://assetstore.unity.com/packages/tools/particles-effects/simple-fade-scene-transition-system-81753 

Robot asset used for AI and player:
https://assetstore.unity.com/packages/3d/characters/robots/space-robot-kyle-4696 
