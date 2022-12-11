using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public class HelpScene : GameScene
    {
        // background image for helpscreen
        private Texture2D tex = Shared.Content.Load<Texture2D>("backgrounds/HelpScreen");

        public HelpScene(Game game) : base(game)
        {
            Shared.GameInst = (Game1)game;
            Shared.SpriteBatch = Shared.GameInst._spriteBatch;
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
