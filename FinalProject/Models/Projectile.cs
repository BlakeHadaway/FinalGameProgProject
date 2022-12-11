using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Models
{
    public class Projectile : ImageSprite
    {
        // Direction vector
        public Vector2 Direction { get; set; }

        // Lifespan float for the time of life the bullet has 
        public float Lifespan { get; private set; }

        /// <summary>
        /// setting all things about the projectile using the projectiledata 
        /// </summary>
        /// <param name="tex">Texture</param>
        /// <param name="projData">The projectile data</param>
        public Projectile(Texture2D tex, ProjectileData projData) : base(tex, projData.Position)
        {
            Speed = projData.Speed;
            Rotation = projData.Rotation;
            Direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            Lifespan = projData.Lifespan;
        }

        /// <summary>
        /// Remove bullet
        /// </summary>
        public void Remove()
        {
            Lifespan = 0;
        }

        /// <summary>
        /// Updating the bullet so it can go forward 
        /// </summary>
        public void Update()
        {
            Position += Direction * Speed * Shared.TotalSeconds;
            Lifespan -= Shared.TotalSeconds;
        }
    }
}
