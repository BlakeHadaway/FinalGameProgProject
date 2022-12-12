/*
 * Outbreak
 * Shared.cs
 * 
 * Revision History:
 *      Blake Hadaway & Blake Power - November 30: Created
 *      Blake Hadaway & Blake Power - November 30: Programed
 *      Blake Hadaway & Blake Power - December 11: Added Comments
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Animations;
using FinalProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    /// <summary>
    /// This static shared class is used to have a bunch of different properies and fields that are to be used
    /// in all of the different classes
    /// </summary>
    public static class Shared
    {
        // declaring properties and variables to be accessed and set throughout the program
        public static float TotalSeconds { get; set; }
        public static Game1 GameInst { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static Point Boundaries { get; set; }
        public static Color White { get; set; } = Color.White;
        public static int TotalScore { get; set; }
        public static int Score { get; set; }
        public static Vector2 KillZombiePos { get; set; }
        public static bool zombHit { get; set; } = false;
        public static Vector2 playerHitPos { get; set; }
        public static bool playerHit { get; set; } = false;
        public static bool isSniperEquipped { get; set; } = false;
        public static string playerName { get; set; } = String.Empty;
        public static float zombieSpawnRate { get; set; } = 0.80f;
        public static int scrollIndex { get; set; } = 0;

        /// <summary>
        /// update method to be called in Game1
        /// </summary>
        /// <param name="gameTime">passing in a gametime object</param>
        public static void Update(GameTime gameTime)
        {
            // setting the Totalseconds to the elapsedgame time in seconds
            TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
