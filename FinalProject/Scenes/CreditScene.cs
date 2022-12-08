using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Scenes
{
    public class CreditScene : GameScene
    {
        private Game1 g;
        private Texture2D tex;

        public CreditScene(Game game) : base(game)
        {
            this.g = (Game1)game;
            Shared.SpriteBatch = g._spriteBatch;

            //LOAD CONTENT FOR THE  HELP PAGE 
            //******************************************
            //tex = game.Content.Load<Texture2D>("");
        }

        public override void Draw(GameTime gameTime)
        {
            Shared.SpriteBatch.Begin();
            Shared.SpriteBatch.Draw(tex, Vector2.Zero, Color.White);
            Shared.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
