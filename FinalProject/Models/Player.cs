using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Models
{
    public class Player : ImageSprite
    {
        public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
        }

        private void Fire()
        {
            ProjectileData projectile = new ProjectileData()
            {
                Position = Position,
                Rotation = Rotation,
                Lifespan = 2,
                Speed = 600,
            };

            ProjectileManager.AddProjectile(projectile);
        }

        public void Update()
        {
            if (InputManager.Direction != Vector2.Zero)
            {
                var direction = Vector2.Normalize(InputManager.Direction);
                Position += direction * Speed * Shared.TotalSeconds;
            }

            var toMouse = InputManager.MousePosition - Position;
            Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

            if (InputManager.MouseClicked)
            {
                Fire();
            }
        }
    }
}
