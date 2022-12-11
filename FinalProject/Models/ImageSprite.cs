using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Models
{
    public class ImageSprite
    {
        public Texture2D texture;
        protected readonly Vector2 origin;
        public Vector2 Position { get; set; }
        public int Speed { get; set; }
        public float Rotation { get; set; }

        public ImageSprite(Texture2D tex, Vector2 pos)
        {
            this.texture = tex;
            Position = pos;
            Speed = 300;
            origin = new(tex.Width / 2, tex.Height / 2);
        }

        public virtual void Draw(Color color)
        {
            Shared.SpriteBatch.Draw(texture, Position, null, color, Rotation, origin, 1, SpriteEffects.None, 1);
        }
    }
}
