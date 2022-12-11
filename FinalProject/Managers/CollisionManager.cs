using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using MessageBox = System.Windows.Forms.MessageBox;

namespace FinalProject.Managers
{
    public class CollisionManager
    {
        private static SoundEffect hitSound = Shared.Content.Load<SoundEffect>("sounds/character_hit");

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
                        Shared.playerHitPos = player.Position - new Vector2(25,25);
                        player.NumberOfLives--;
                        hitSound.Play();
                        player.IFrames();
                        Shared.playerHit = true;
                        ActionScene.GameOver(player);
                    }
                }
            }
        }
    }
}
