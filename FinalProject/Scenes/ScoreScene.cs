using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FinalProject.Managers;

namespace FinalProject.Scenes
{
    public class ScoreScene : GameScene
    {
        private Game1 g;
        private Texture2D tex = Shared.Content.Load<Texture2D>("backgrounds/HighScorePage");

        public ScoreScene(Game game) : base(game)
        {
            this.g = (Game1)game;
            Shared.SpriteBatch = g._spriteBatch;
        }

        public override void Draw(GameTime gameTime)
        {
            Shared.SpriteBatch.Begin();
            Shared.SpriteBatch.Draw(tex, Vector2.Zero, Color.White);
            FileIOManager.ReadTopScoresFromFile();
            Shared.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
