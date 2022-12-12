/*
 * ProjectileSR.cs
 * Outbreak game
 * Revision History
 *      Blake Power, 2022.12.1: Created
 *      Blake Power, 2022.12.1: Added code
 *      Blake Power, 2022.12.11: Comments added
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models.Weapons
{
    /// <summary>
    /// Whole sepperate class for the sniper so that its bullets can be put into a different
    /// list to avoid other bullets piercing enemies when switching weapons. 
    /// </summary>
    public class ProjectileSR : ImageSprite
    {
        // get and set direction of the sniper bullet 
        public Vector2 Direction { get; set; }

        // get and set Lifespan of the sniper bullet 
        public float Lifespan { get; private set; }

        /// <summary>
        /// projectilesr is being set up with its speed and rotation, direction and lifespan using the gets
        /// and it gets all these things from projectiledata and is setting the vars from imagesprite.
        /// </summary>
        /// <param name="tex"></param>
        /// <param name="projData"></param>
        public ProjectileSR(Texture2D tex, ProjectileData projData) : base(tex, projData.Position)
        {
            Speed = projData.Speed;
            Rotation = projData.Rotation;
            Direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            Lifespan = projData.Lifespan;
        }

        /// <summary>
        /// Removes bullets 
        /// </summary>
        public void Remove()
        {
            Lifespan = 0;
        }

        /// <summary>
        /// update for updating the bullet so that it can move in its given direction 
        /// </summary>
        public void Update()
        {
            Position += Direction * Speed * Shared.TotalSeconds;
            Lifespan -= Shared.TotalSeconds;
        }
    }
}
