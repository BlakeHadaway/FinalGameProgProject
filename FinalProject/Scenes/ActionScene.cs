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
    public class ActionScene : GameScene
    {
        private GamePlay gamePlay = new GamePlay();
        private Texture2D splatterTex = Shared.Content.Load<Texture2D>("images/BloodSplatter");
        private Texture2D bloodTex = Shared.Content.Load<Texture2D>("images/PlayerBlood");
        private Texture2D background = Shared.Content.Load<Texture2D>("backgrounds/GreenBackground");

        public ActionScene(Game game) : base(game)
        {
            Shared.GameInst = (Game1)game;
        }

        public static void GameOver(Player player)
        {
            if (player.NumberOfLives == 0)
            {
                if (Shared.playerName == string.Empty)
                {
                    Shared.playerName = "ANONYMOUS";
                }

                FileIOManager.WriteScoreToFile();
                player._dead = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Shared.zombHit)
            {
                BloodSplat bloodSplat = new BloodSplat(Shared.GameInst, Shared.SpriteBatch, splatterTex, Shared.KillZombiePos, 2);
                this.Components.Add(bloodSplat);
                bloodSplat.restart();
                Shared.zombHit = false;
            }

            if (Shared.playerHit)
            {
                PlayerBlood playerSplat = new PlayerBlood(Shared.GameInst, Shared.SpriteBatch, bloodTex, Shared.playerHitPos, 2);
                this.Components.Add(playerSplat);
                playerSplat.restart();
                Shared.playerHit = false;
            }
            gamePlay.Update();
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            Shared.GameInst._spriteBatch.Begin();
            Shared.GameInst._spriteBatch.Draw(background, Vector2.Zero, Color.White);
            gamePlay.Draw();
            Shared.GameInst._spriteBatch.End();
            
            base.Draw(gameTime);
        }

    }
}
