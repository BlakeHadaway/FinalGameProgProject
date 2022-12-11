using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using Color = Microsoft.Xna.Framework.Color;

namespace FinalProject.Managers
{
    public class UIManager
    {
        private static SpriteFont font = Shared.Content.Load<SpriteFont>("fonts/actionFont");
        private static string tempString;
        private static Vector2 stringDimentions;

        public static void PointUnlockCheck()
        {
            if (!Player.SMGUnlocked)
            {
                tempString = $"Unlock the Smg at 15 points";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 900), Color.Black);
            }
            else if (!Player.SniperUnlocked)
            {
                tempString = $"Unlock the Sniper at 50 points";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 900), Color.Black);
            }
            else if (!Player.LMGUnlocked)
            {
                tempString = $"Unlock the Lmg at 125 points";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 900), Color.Black);
            }
        }

        public static void Death(Player player)
        {
            if (player._dead)
            {
                tempString = $"You Died! Your total score was: {Shared.Score}\nTo restart the game, press R.";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y / 2 - 40), Color.Red);
            }
        }

        public static void DrawUIElements(Player player)
        {
            Color color = player.Weapon.Reloading ? Color.Red : Color.Black;

            tempString = $"{player.Weapon.Ammo} / {player.Weapon.maxAmmo}";
            Shared.SpriteBatch.DrawString(font, tempString, Vector2.Zero, color);

            tempString = $"Score: {Shared.Score}";
            stringDimentions = font.MeasureString(tempString);
            Shared.SpriteBatch.DrawString(font, tempString, new Vector2(0, Shared.Boundaries.Y - stringDimentions.Y), Color.Black);

            tempString = $"Lives left: {player.NumberOfLives}";
            stringDimentions = font.MeasureString(tempString);
            Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X - stringDimentions.X, 0), Color.Black);
        }

        public static void WeaponEquiped()
        {
            if (Shared.scrollIndex == 0)
            {
                tempString = $"Current Weapon: Pistol";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X - stringDimentions.X, Shared.Boundaries.Y - stringDimentions.Y), Color.Black);
            }
            else if (Shared.scrollIndex == 1)
            {
                tempString = $"Current Weapon: Smg";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X - stringDimentions.X, Shared.Boundaries.Y - stringDimentions.Y), Color.Black);
            }
            if (Shared.scrollIndex == 2)
            {
                tempString = $"Current Weapon: Sniper";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X - stringDimentions.X, Shared.Boundaries.Y - stringDimentions.Y), Color.Black);
            }
            if (Shared.scrollIndex == 3)
            {
                tempString = $"Current Weapon: Lmg";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X - stringDimentions.X, Shared.Boundaries.Y - stringDimentions.Y), Color.Black);
            }
        }

        public static void Draw(Player player)
        {
            DrawUIElements(player);

            PointUnlockCheck();

            WeaponEquiped();

            Death(player);

        }
    }
}
