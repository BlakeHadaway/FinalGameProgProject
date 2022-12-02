using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace FinalProject
{
    public class ActionScene : GameScene
    {
        private GameManager _gameManager = new GameManager();
        private Game1 g;

        public ActionScene(Game game) : base(game)
        {
            g = (Game1)game;
        }

        public override void Draw(GameTime gameTime)
        {
            g._spriteBatch.Begin();
            g._spriteBatch.Draw(g._background, Vector2.Zero, Color.White);
            _gameManager.Draw();
            g._spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            _gameManager.Update();
            base.Update(gameTime);
        }

    }
}
