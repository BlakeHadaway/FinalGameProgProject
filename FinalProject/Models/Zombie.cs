using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Models
{
    /// <summary>
    /// Zombies class to be used for the ZombieManager
    /// inherits from ImageSprite for base properties
    /// </summary>
    public class Zombie : ImageSprite
    {
        // HP variable for the Zombies
        public int HP { get; private set; }

        /// <summary>
        /// General Constructor, setting important values
        /// </summary>
        /// <param name="tex">Texture from ImageSprite</param>
        /// <param name="pos">Position from ImageSpriteClass</param>
        public Zombie(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            //setting the speed of all zombies
            Speed = 115;

            // setting the zombies hp to 1
            HP = 1;
        }

        /// <summary>
        /// A method to deal damage to the zombie hit
        /// </summary>
        /// <param name="damage">This will be how much damage the zombie will take</param>
        public void InflictDamage(int damage)
        {
            // subtracting the zombies HP by the value passed in
            HP -= damage;
        }


        /// <summary>
        /// Update to be called in the ZombieManager
        /// </summary>
        /// <param name="player">Taking a player object to always follow the player</param>
        public void Update(Player player)
        {
            // Vector that is aimed at the player
            var huntPlayer = player.Position - Position;

            // rotates zombie to be facing player at all times
            Rotation = (float)Math.Atan2(huntPlayer.Y, huntPlayer.X);

            // this is so that the zombies, if on top of the player, don't glitch and shake
            if (huntPlayer.Length() > 4)
            {
                // getting the direction of the player to move in
                var direction = Vector2.Normalize(huntPlayer);
                // moves the zombie in the direction of the player
                Position += direction * Speed * Shared.TotalSeconds;
            }
        }
    }
}
