using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Animations;
using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace FinalProject
{
    public class ActionScene : GameScene
    {
        private GameManager _gameManager = new GameManager();
        private Game1 g;
        private Texture2D tex = Shared.Content.Load<Texture2D>("images/BloodSplatter");
        private Texture2D background = Shared.Content.Load<Texture2D>("backgrounds/GreenBackground");

        public ActionScene(Game game) : base(game)
        {
            g = (Game1)game;
        }

        public override void Update(GameTime gameTime)
        {
            if (Shared.zombHit)
            {
                BloodSplat bloodSplat = new BloodSplat(g, Shared.SpriteBatch, tex, Shared.KillZombiePos, 2);
                this.Components.Add(bloodSplat);
                bloodSplat.restart();
                Shared.zombHit = false;
            }
            _gameManager.Update();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            g._spriteBatch.Begin();
            g._spriteBatch.Draw(background, Vector2.Zero, Color.White);
            _gameManager.Draw();
            g._spriteBatch.End();
            
            base.Draw(gameTime);
        }

    }
}
