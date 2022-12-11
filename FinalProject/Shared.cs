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
    public static class Shared
    {
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

        public static Vector2 stage;

        public static void Update(GameTime gameTime)
        {
            TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
