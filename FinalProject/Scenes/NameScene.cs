using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DirectWrite;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject.Scenes
{
    /// <summary>
    /// Name scene is to get the users name, if the user doesn't provide a name
    /// they will be assigned the name anonymous
    /// </summary>
    public class NameScene : GameScene
    {
        // font to display
        private static SpriteFont _font;
        // getting the last keyboard state to check if the key has gone down and up
        private static KeyboardState _lastKeyboardState;

        /// <summary>
        /// general constuctor
        /// </summary>
        /// <param name="game">Taking a Game Object</param>
        public NameScene(Game game) : base(game)
        {
            // setting the font
            _font = Shared.Content.Load<SpriteFont>("fonts/startFont");
        }

        /// <summary>
        /// update fuction to be called in Game1
        /// </summary>
        public void Update()
        {
            // setting up a keyboard state, has to be declared in here, or wouldn't work
            // that is because it constantly need to be updated
            KeyboardState keyboardState = Keyboard.GetState();

            // creating a var to be an enum of keys, and getting the pressed keys
            var keys = keyboardState.GetPressedKeys();

            // to make sure it is a usable key
            if (keys.Length > 0)
            {
                // checking if the backspace key is pressed
                if (_lastKeyboardState.IsKeyUp(Keys.Back) && keyboardState.IsKeyDown(Keys.Back))
                {
                    // this will delete the whole name, so they can retype it
                    Shared.playerName = string.Empty;
                }
                else
                {
                    // checking if the name is less than 10 letters, just for simplitiy
                    if (Shared.playerName.Length <= 10)

                        // if the key pressed toString length is less than or equal to 1, which meaning is a letter
                        // and that key is also pressed down and has come back up
                        if (keys[0].ToString().Length <= 1 && _lastKeyboardState.IsKeyUp(keys[0]) && keyboardState.IsKeyDown(keys[0]))
                        {
                            // then we can add it to the keyvalue variable
                            var keyValue = keys[0].ToString();

                            // then add it to the actual players name
                            Shared.playerName += keyValue;
                        }
                }
            }

            // getting the last keyboard state, so we know when the key has gone up and down
            _lastKeyboardState = keyboardState;
        }

        /// <summary>
        /// Overrided draw from GameScene
        /// </summary>
        /// <param name="gameTime">Gets a GameTime object passed in</param>
        public override void Draw(GameTime gameTime)
        {
            // drawing using shared spritebatch
            Shared.SpriteBatch.Begin();

            // drawing the string for the user to enter there name
            Shared.SpriteBatch.DrawString(_font, $"Your Name: {Shared.playerName}", Vector2.Zero, Shared.White);
            Shared.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
