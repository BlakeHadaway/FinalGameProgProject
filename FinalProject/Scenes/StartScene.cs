using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public class StartScene : GameScene
    {

        public MenuComponent Menu { get; set; }
        private SpriteBatch spriteBatch;
        string[] menuItems = { "Start Game",
            "Help",
            "HighScore",
            "Credits",
            "Quit" };

        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g._spriteBatch;

            SpriteFont regularFont = game.Content.Load<SpriteFont>("fonts/Myfont");
            //SpriteFont highlightFont = game.Content.Load<SpriteFont>("fonts/HighlightedMenuFont");

            Menu = new MenuComponent(game, spriteBatch, regularFont, regularFont, menuItems);

            this.Components.Add(Menu);
        }
    }
}
