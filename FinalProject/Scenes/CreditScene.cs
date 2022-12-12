/*
 * InputManager.cs
 * Outbreak game
 * Revision History
 *      Blake Power, 2022.11.30: Created
 *      Blake Power, 2022.11.30: Added code
 *      Blake Power, 2022.12.11: Comments added
 */
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
        // background image for the credits scene 
        private Texture2D tex = Shared.Content.Load<Texture2D>("backgrounds/CreditScreen");

        /// <summary>
        /// setting gameinst and the sprite batch to be the gameinst spritebatch.
        /// </summary>
        /// <param name="game"></param>
        public CreditScene(Game game) : base(game)
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
