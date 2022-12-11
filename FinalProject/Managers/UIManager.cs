using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Models.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using Color = Microsoft.Xna.Framework.Color;

namespace FinalProject.Managers
{
    /// <summary>
    /// This is the UI class, this will generate and draw the UI elements for the user to see
    /// </summary>
    public class UIManager
    {
        // declare varibles to be used
        private static SpriteFont font = Shared.Content.Load<SpriteFont>("fonts/actionFont");
        private static string tempString;
        private static Vector2 stringDimentions;

        /// <summary>
        /// This method is to check the point unlock and display to the user what
        /// there next gun unlock is and how many points they need
        /// </summary>
        public static void PointUnlockCheck()
        {
            if (!Player.SMGUnlocked)
            {
                tempString = $"Unlock the Smg at 30 points";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 900), Color.Black);
            }
            else if (!Player.SniperUnlocked)
            {
                tempString = $"Unlock the Sniper at 100 points";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 900), Color.Black);
            }
            else if (!Player.LMGUnlocked)
            {
                tempString = $"Unlock the Lmg at 250 points";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 900), Color.Black);
            }
            else if (Shared.Score >= 280)
            {
                tempString = $"Last Weapon Aquired : Survive As Long As Possible!";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 900), Color.Black);
            }

            
        }

        /// <summary>
        /// This method is to alert the player when a new gun is unlocked
        /// </summary>
        public static void AlertGunUnlock()
        {
            if (Shared.Score >= 30 && Shared.Score <= 60)
            {
                if (Shared.Score%2 == 0)
                {
                    tempString = $"New Unlock: Smg!";
                    stringDimentions = font.MeasureString(tempString);
                    Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - stringDimentions.Y), Color.Blue);
                }
                else
                {
                    tempString = $"New Unlock: Smg!";
                    stringDimentions = font.MeasureString(tempString);
                    Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - stringDimentions.Y), Color.Orange);
                }
            }
            else if (Shared.Score >= 100 && Shared.Score <= 130)
            {
                if (Shared.Score % 2 == 0)
                {
                    tempString = $"New Unlock: Sniper!";
                    stringDimentions = font.MeasureString(tempString);
                    Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - stringDimentions.Y), Color.Blue);
                }
                else
                {
                    tempString = $"New Unlock: Sniper!";
                    stringDimentions = font.MeasureString(tempString);
                    Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - stringDimentions.Y), Color.Orange);
                }
            }
            else if (Shared.Score >= 250 && Shared.Score <= 280)
            {
                if (Shared.Score % 2 == 0)
                {
                    tempString = $"New Unlock: Lmg!";
                    stringDimentions = font.MeasureString(tempString);
                    Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - stringDimentions.Y), Color.Blue);
                }
                else
                {
                    tempString = $"New Unlock: Lmg!";
                    stringDimentions = font.MeasureString(tempString);
                    Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - stringDimentions.Y), Color.Orange);
                }
            }
        }

        /// <summary>
        /// this method changes the spawn rate of the zombies, and displays that
        /// more zombies are incoming
        /// </summary>
        public static void ZombieSpawnRateChange()
        {
            if (Shared.Score >= 50 && Shared.Score <= 60)
            {
                tempString = $"More Zombies Incoming!";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 50 - stringDimentions.Y), Color.Red);
                Shared.zombieSpawnRate = 0.60f;
            }
            else if (Shared.Score >= 110 && Shared.Score <= 120)
            {
                tempString = $"Even More Zombies Incoming!";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 50 - stringDimentions.Y), Color.Red);
                Shared.zombieSpawnRate = 0.45f;
            }
            else if (Shared.Score >= 180 && Shared.Score <= 195)
            {
                tempString = $"A Huge Horde of Zombies Incoming!";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 50 - stringDimentions.Y), Color.Red);
                Shared.zombieSpawnRate = 0.30f;
            }
            else if (Shared.Score >= 320 && Shared.Score <= 350)
            {
                tempString = $"The Final Wave of Zombies Incoming! Survive!";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y - 50 - stringDimentions.Y), Color.Red);
                Shared.zombieSpawnRate = 0.20f;
            }
        }

        /// <summary>
        /// This method is for if the player dies, to show the user their end score and 
        /// if they would like to restart the game
        /// </summary>
        /// <param name="player">passing in a player object</param>
        public static void Death(Player player)
        {
            if (player._dead)
            {
                tempString = $"You Died! Your total score was: {Shared.Score}\nTo restart the game, press R.";
                stringDimentions = font.MeasureString(tempString);
                Shared.SpriteBatch.DrawString(font, tempString, new Vector2(Shared.Boundaries.X / 2 - stringDimentions.X / 2, Shared.Boundaries.Y / 2 - 40), Color.Red);
            }
        }

        /// <summary>
        /// This method draws all the UI elements
        /// </summary>
        /// <param name="player">Pass in the player object</param>
        public static void DrawUIElements(Player player)
        {
            // setting the color of the ammo count based on if the player is reloading or not
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

        /// <summary>
        /// This method is to display what weapon the player has currently equiped
        /// </summary>
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

        /// <summary>
        /// This is the draw method that will be called in the GameManager
        /// </summary>
        /// <param name="player"> Passing in the player object</param>
        public static void Draw(Player player)
        {
            // Calling all the methods above 
            DrawUIElements(player);

            PointUnlockCheck();

            AlertGunUnlock();

            ZombieSpawnRateChange();

            WeaponEquiped();

            Death(player);

        }
    }
}
