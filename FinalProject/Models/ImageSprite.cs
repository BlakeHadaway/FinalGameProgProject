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
    /// <summary>
    /// This is a class to be inherited by most of the other model classes, will have a few basic properties
    /// </summary>
    public class ImageSprite
    {
        public Texture2D texture;
        
        protected readonly Vector2 origin;
        public Vector2 Position { get; set; }
        public int Speed { get; set; }
        
        //used later for player movement
        public float Rotation { get; set; }

        public ImageSprite(Texture2D tex, Vector2 pos)
        {
            // setting the texure, position, speed, and origin
            this.texture = tex;
            Position = pos;
            Speed = 300;
            origin = new(tex.Width / 2, tex.Height / 2);
        }

        /// <summary>
        /// this is the draw method to draw the spritebatch
        /// it is virtual so that child classes can use it as well
        /// </summary>
        /// <param name="color">Had to put this color param to make the character red when hit</param>
        public virtual void Draw(Color color)
        {
            Shared.SpriteBatch.Draw(texture, Position, null, color, Rotation, origin, 1, SpriteEffects.None, 1);
        }
    }
}
