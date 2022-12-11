using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using MessageBox = System.Windows.Forms.MessageBox;

namespace FinalProject.Managers
{
    /// <summary>
    /// Manager to detect collision between the player and zombies
    /// </summary>
    public class CollisionManager
    {
        // declaring a sound effect to be used to when the player is hit
        private static SoundEffect hitSound = Shared.Content.Load<SoundEffect>("sounds/character_hit");

        /// <summary>
        /// update method to be called in the gamemanager
        /// </summary>
        /// <param name="player">taking a player object</param>
        /// <param name="zombieHorde">taking a list of zombies</param>
        public static void Update(Player player, List<Zombie> zombieHorde)
        {
            // getting the player rectangle bounds
            Rectangle playerRect = player.getBounds();

            // for each of the zombies in the list
            foreach (Zombie zombie in zombieHorde)
            {
                // getting the zombie rectangle bounds to use for collision
                Rectangle zombieRect = new Rectangle((int)zombie.Position.X, (int)zombie.Position.Y, zombie.texture.Width, zombie.texture.Height);

                // if the player is invicible
                if (player.Invincibility)
                {
                    return;
                }
                else
                {
                    // if the player and zombie rectangles intersect
                    if (playerRect.Intersects(zombieRect))
                    {
                        // getting the players hit position , and subtracting a vector 2 to
                        // try and center it a bit more on the player model for the animation
                        Shared.playerHitPos = player.Position - new Vector2(25,25);

                        // take a life away
                        player.NumberOfLives--;

                        // play the sound
                        hitSound.Play();
                        
                        // set the players IFrames
                        player.IFrames();
                        
                        // make this bool true, to be use elsewhere
                        Shared.playerHit = true;

                        // calling the actionscenes gameover method, and passing the player object
                        ActionScene.GameOver(player);
                    }
                }
            }
        }
    }
}
