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
        public Vector2 Direction { get; set; }
        public float Lifespan { get; private set; }

        public Projectile(Texture2D tex, ProjectileData projData) : base(tex, projData.Position)
        {
            Speed = projData.Speed;
            Rotation = projData.Rotation;
            Direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            Lifespan = projData.Lifespan;
        }

        public void Update()
        {
            Position += Direction * Speed * Shared.TotalSeconds;
            Lifespan -= Shared.TotalSeconds;
        }

        

    }
}
