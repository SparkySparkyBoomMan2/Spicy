/*
 * README - GhostEnemyNew.prefab
 * 
 * This prefab is used for an enemy in our game, Super Spicy Gun Game.
 * GhostEnemyNew takes advantage of A* pathfinding to chase the player down.
 * Here is a list of methods called in the script attached to the prefab
 * 
 * GhostMasterAI:
 * Die() - Allows the instance of the prefab to be destroyed when hit by a bullet.
 * 
 * OnCollisionEnter2D(Collision2D collision) - This method checks for collision with the
 * player. If the collision recognizes the player, it will make a call to kill the player.
 * 
 * UpdatePath() - This method is called by InvokeRepeating, which updates the path
 * that the ghost will follow every half second.
 * 
 * OnPathComplete() - This method ensures that the ghost will stop moving once it has
 * reached the target assigned to it.
 * 
 * FixedUpdate() - This method handles the inner workings of setting up the path for the
 * ghost to follow. It also includes error checking if there was an error generating the path.
 * This also handles which way that the ghosts will face, based off of the horizontal velocity.
 * 
 * 
 * 
 */
