using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.Animations;
using FinalProject.Managers;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject
{
    /// <summary>
    /// this class is where some of the game logic is, most of the other game instances
    /// are called from the game manager, 
    /// </summary>
    public class ActionScene : GameScene
    {
        // creating a gameplay instance, this is used to reset the game
        private GamePlay gamePlay = new GamePlay();
        private Texture2D splatterTex = Shared.Content.Load<Texture2D>("images/BloodSplatter");
        private Texture2D bloodTex = Shared.Content.Load<Texture2D>("images/PlayerBlood");
        private Texture2D background = Shared.Content.Load<Texture2D>("backgrounds/GreenBackground");

        /// <summary>
        /// General constructor
        /// </summary>
        /// <param name="game">getting passed a Game object</param>
        public ActionScene(Game game) : base(game)
        {
            // setting the shared gameinst to the game1 object
            Shared.GameInst = (Game1)game;
        }

        /// <summary>
        /// This is the game over method, this will trigger when the player has no lives left
        /// </summary>
        /// <param name="player">Passing is a player object to get the players number of lives</param>
        public static void GameOver(Player player)
        {
            // if the play has no lives left
            if (player.NumberOfLives == 0)
            {
                // if the player didnt enter a name
                if (Shared.playerName == string.Empty)
                {
                    // setting the name to anonymous
                    Shared.playerName = "ANONYMOUS";
                }

                // calling the fileIO WriteScoreToFile method, to save the users score
                FileIOManager.WriteScoreToFile();

                // setting the boolean _dead to true, to be used later
                player._dead = true;
            }
        }

        /// <summary>
        /// overrided update from GameScene
        /// </summary>
        /// <param name="gameTime">taking game time object</param>
        public override void Update(GameTime gameTime)
        {
            // if the a zombie is hit
            if (Shared.zombHit)
            {
                // creating a BloodSplat animation object, and setting its values
                BloodSplat bloodSplat = new BloodSplat(Shared.GameInst, Shared.SpriteBatch, splatterTex, Shared.KillZombiePos, 2);

                // adding to the compontents
                Shared.GameInst.Components.Add(bloodSplat);

                // restarting the animation so it plays
                bloodSplat.restart();

                // setting the hit boolean to false
                Shared.zombHit = false;
            }

            // if the player is hit
            if (Shared.playerHit)
            {
                // creating a PlayerBloood animation object, and setting its values
                PlayerBlood playerSplat = new PlayerBlood(Shared.GameInst, Shared.SpriteBatch, bloodTex, Shared.playerHitPos, 2);

                // adding it to the components
                Shared.GameInst.Components.Add(playerSplat);
                
                // restarting the animation so it plays
                playerSplat.restart();

                // setting the hit bool to false
                Shared.playerHit = false;
            }

            // calling the gameplay update method
            gamePlay.Update();

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            // drawing using shared spritebatch
            Shared.GameInst._spriteBatch.Begin();

            // drawing the backgound for this bage
            Shared.GameInst._spriteBatch.Draw(background, Vector2.Zero, Color.White);
            
            // calling the gameplay draw method
            gamePlay.Draw();
            Shared.GameInst._spriteBatch.End();
            
            base.Draw(gameTime);
        }

    }
}
