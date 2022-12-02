using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace FinalProject.Managers
{
    public class CollisionManager
    {
        private readonly SoundEffect hitSound;

        public static void Update(Player player, List<Zombie> zombieHorde)
        {
            Rectangle playerRect = player.getBounds();

            foreach (Zombie zombie in zombieHorde)
            {
                Rectangle zombieRect = new Rectangle((int)zombie.Position.X, (int)zombie.Position.Y, zombie.texture.Width, zombie.texture.Height);

                if (player.Invincibility)
                {
                    return;
                }
                else
                {
                    if (playerRect.Intersects(zombieRect))
                    {
                        Shared.Score = 0;
                        player.NumberOfLives--;
                        player.IFrames();
                    }
                }
            }
        }

        public void GameOver(Player player)
        {

        }
    }
}
