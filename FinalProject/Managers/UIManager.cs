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
using Color = Microsoft.Xna.Framework.Color;

namespace FinalProject.Managers
{
    public class UIManager
    {
        private static SpriteFont font = Shared.Content.Load<SpriteFont>("fonts/actionFont");

        public static void Draw(Player player)
        {
            Color color = player.Weapon.Reloading ? Color.Red : Color.Black;

            Shared.SpriteBatch.DrawString(font, $"{player.Weapon.Ammo} / {player.Weapon.maxAmmo}", Vector2.Zero, color);

            Shared.SpriteBatch.DrawString(font, $"Score: {Shared.Score}", new Vector2(0, 845), Color.Black);

            Shared.SpriteBatch.DrawString(font, $"Lives left: {player.NumberOfLives}", new Vector2(1250, 0), Color.Black);
        }
    }
}
