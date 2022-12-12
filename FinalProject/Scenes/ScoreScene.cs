/*
 * Outbreak
 * ScoreScene.cs
 * 
 * Revision History:
 *      Blake Hadaway - December 3: Created
 *      Blake Hadaway - December 3: Programed
 *      Blake Hadaway - December 11: Added Comments
 */

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
    /// <summary>
    /// Score scene is to save the users score once they die
    /// inherits from GameScene
    /// </summary>
    public class ScoreScene : GameScene
    {
        private Texture2D tex = Shared.Content.Load<Texture2D>("backgrounds/HighScorePage");

        /// <summary>
        /// general constuctor
        /// </summary>
        /// <param name="game">getting passed a Game Object</param>
        public ScoreScene(Game game) : base(game)
        {
            // setting shared GameInstance to Game1 game object
            Shared.GameInst = (Game1)game;
            
            // setting the shared spritebatch to game1 sprite batch variable using the new shared spritebatch instance
            Shared.SpriteBatch = Shared.GameInst._spriteBatch;
        }

        /// <summary>
        /// overrided draw from GameScene
        /// </summary>
        /// <param name="gameTime">Passed in a gametime object</param>
        public override void Draw(GameTime gameTime)
        {
            // drawing using shared spritebatch
            Shared.SpriteBatch.Begin();
            
            // drawing the background for the score page
            Shared.SpriteBatch.Draw(tex, Vector2.Zero, Color.White);

            // calling the FileIOManager Class to display the highscores
            FileIOManager.ReadTopScoresFromFile();
            Shared.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
