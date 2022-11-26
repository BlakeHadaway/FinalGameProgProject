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
    public class Zombie : ImageSprite
    {
        public int HP { get; private set; }
        public Zombie(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            Speed = 115;
            HP = 1;
        }

        public void InflictDamage(int damage)
        {
            HP -= damage;
        }

        public void Update(Player player)
        {
            // Using these to set rotation of mobs so they are always locked onto player,
            // and spirtes turn with it
            var huntPlayer = player.Position - Position;
            Rotation = (float)Math.Atan2(huntPlayer.Y, huntPlayer.X);

            if(huntPlayer.Length() > 4)
            {
                var direction = Vector2.Normalize(huntPlayer);
                Position += direction * Speed * Shared.TotalSeconds;
            }
        }
    }
}
