using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ProjectileDataSR
    {
        // Position of the sniper bullet 
        public Vector2 Position { get; set; }

        // rotation of the sniper bullet
        public float Rotation { get; set; }

        // Lifespan of the sniper bullet 
        public float Lifespan { get; set; }

        // Speed of the sniper bullet 
        public int Speed { get; set; }
    }
}
