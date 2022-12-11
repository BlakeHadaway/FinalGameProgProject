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
    public class MenuComponent : DrawableGameComponent
    {
        // setting spritebatch and fonts and colors 
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, highlightFont;
        private Color regularColor = Color.Black;
        private Color highlightColor = Color.Red;

        // list of menu items to display on the menu 
        private List<string> menuItems;

        // selected index for what is selected on the menu
        public static int selectedIndex { get; set; }

        // positon for things on the menu 
        public Vector2 position;

        // to have what our old keyboardstate was 
        private KeyboardState oldState;

        /// <summary>
        /// Setting all things like color and fonts 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="regularFont"></param>
        /// <param name="highlightFont"></param>
        /// <param name="menus"></param>
        public MenuComponent(Game game,SpriteBatch spriteBatch,SpriteFont regularFont, SpriteFont highlightFont, string[] menus) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.highlightFont = highlightFont;
            menuItems =  menus.ToList<string>();
            position = new Vector2(30, 30);
        }

        /// <summary>
        /// when moving in the menu the selected index menu item will be highlighted 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;
            spriteBatch.Begin();


            for (int i = 0; i < menuItems.Count; i++)
            {
                if (selectedIndex == i)
                {
                    spriteBatch.DrawString(highlightFont, menuItems[i], tempPos, highlightColor);
                    tempPos.Y += highlightFont.LineSpacing;

                }
                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[i], tempPos, regularColor);
                    tempPos.Y += regularFont.LineSpacing;
                }
            }

            Shared.SpriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Keeping track of the index of the menu item when cycling through the menu items 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.S) && oldState.IsKeyUp(Keys.S))
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count)
                {
                    selectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.W) && oldState.IsKeyUp(Keys.W))
            {
                selectedIndex--;
                if (selectedIndex == -1)
                {
                    selectedIndex = menuItems.Count - 1;
                }
            }
            oldState = ks;

            base.Update(gameTime);
        }
    }
}
