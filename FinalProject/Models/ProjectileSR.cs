using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models.Weapons
{
    public class ProjectileSR : ImageSprite
    {
        public Vector2 Direction { get; set; }
        public float Lifespan { get; private set; }

        public ProjectileSR(Texture2D tex, ProjectileData projData) : base(tex, projData.Position)
        {
            Speed = projData.Speed;
            Rotation = projData.Rotation;
            Direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            Lifespan = projData.Lifespan;
        }

        public void Remove()
        {
            Lifespan = 0;
        }

        public void Update()
        {
            Position += Direction * Speed * Shared.TotalSeconds;
            Lifespan -= Shared.TotalSeconds;
        }
    }
}
