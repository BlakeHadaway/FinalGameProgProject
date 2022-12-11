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
    public sealed class ProjectileData
    {
        // position of the bullet 
        public Vector2 Position { get; set; }

        // rotation of the bullet 
        public float Rotation { get; set; }

        // Lifespan of the bullet 
        public float Lifespan { get; set; }

        // Speed of the bullet 
        public int Speed { get; set; }
    }
}
