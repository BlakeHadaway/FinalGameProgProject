using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Animations;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Managers
{
    public class GameManager
    {
        private Player _player;
        private readonly Color red = Color.Red;
        
        // declaring a delegate name ResetGame
        public Delegate ResetGame { get; set; }
        
        /// <summary>
        /// General costructor
        /// </summary>
        /// <param name="RESETWORLD">This delegate is passed in, and used for the reseting of the game</param>
        public GameManager(Delegate RESETWORLD)
        {
            // setting the delegate to the passed in delegate 
            ResetGame = RESETWORLD;

            // setting the player texture and position
            _player = new(Shared.Content.Load<Texture2D>("images/player"), new Vector2(Shared.Boundaries.X / 2, Shared.Boundaries.Y / 2));

            // calling initial methods and addzombietobattlefield method
            ProjectileManager.Initial();
            ZombieManager.Initial();
            ZombieManager.AddZombieToBattleField();
        }

        /// <summary>
        /// This is to initalize the player
        /// </summary>
        /// <param name="player">Passing in the player object</param>
        /// <returns></returns>
        public Player Initialize(Player player)
        {
            // setting the player texture and position for the new game
            player = new(Shared.Content.Load<Texture2D>("images/player"), new Vector2(Shared.Boundaries.X / 2, Shared.Boundaries.Y / 2));

            // returning the player object
            return player; 
        }

        /// <summary>
        /// This method is used to reset the match
        /// </summary>
        public void ResetMatch()
        {
            // setting the delegate to null, this is to set the reset the game
            ResetGame = null;

            // reset the player
            _player = Initialize(_player);
            // Clearing all the zombies and projectiles
            ZombieManager.HordeOfZombies.Clear();
            ProjectileManager.Projectiles.Clear();

            // setting the score and the scrolling index
            Shared.Score = 0;
            Shared.scrollIndex = 0;

            // setting the spawn rate back to the starting value
            Shared.zombieSpawnRate = 0.80f;

            // setting the bools of guns unlocked to be false or locked again
            Player.SMGUnlocked = false;
            Player.SniperUnlocked = false;
            Player.LMGUnlocked = false;

            // setting the player lives, and changing the dead bool back to false
            _player.NumberOfLives = 5;
            _player._dead = false;

        }

        /// <summary>
        /// this is the update method called in the GamePlay Class
        /// </summary>
        public void Update()
        {

            // if the player isn't dead, do the normal updating fuctions
            if (!_player._dead)
            {
                // Calling all the update methods from each of the classes
                InputManager.Update();
                _player.Update();
                ZombieManager.Update(_player);
                ProjectileManager.Update(ZombieManager.HordeOfZombies);
                CollisionManager.Update(_player, ZombieManager.HordeOfZombies);
            }
            else
            {
                // get the keyboard state of the user
                KeyboardState ks = Keyboard.GetState();

                // and check if the player presses R to restart the game
                if (ks.IsKeyDown(Keys.R))
                {
                    // call the delegate method to reset the game
                    ResetMatch();
                }
            }
        }

        /// <summary>
        /// This is the draw method called in the GamePlay class
        /// </summary>
        public void Draw()
        {
            // if the player is invicible
            if (_player.Invincibility == true)
            {
                // change its color to red
                _player.Draw(red);
            }
            else
            {
                // draw the player normally
                _player.Draw(Shared.White);
            }

            // Calling all the draw methods from all the classes
            ProjectileManager.Draw();
            ZombieManager.draw();
            UIManager.Draw(_player);
        }
    }
}
