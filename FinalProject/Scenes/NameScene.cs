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
    public class NameScene : GameScene
    {
        
        private static SpriteFont _font;
        private static KeyboardState _lastKeyboardState;

        public NameScene(Game game) : base(game)
        {
            _font = Shared.Content.Load<SpriteFont>("fonts/startFont");
        }

      
        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            var keys = keyboardState.GetPressedKeys();

            if (keys.Length > 0)
            {
                if (_lastKeyboardState.IsKeyUp(Keys.Back) && keyboardState.IsKeyDown(Keys.Back))
                {
                    Shared.playerName = string.Empty;
                }
                else
                {
                    if (Shared.playerName.Length <= 10)
                        if (keys[0].ToString().Length <= 1 && _lastKeyboardState.IsKeyUp(keys[0]) && keyboardState.IsKeyDown(keys[0]))
                        {
                            var keyValue = keys[0].ToString();
                            Shared.playerName += keyValue;
                        }
                }
            }

            _lastKeyboardState = keyboardState;
        }

        public override void Draw(GameTime gameTime)
        {
          
            Shared.SpriteBatch.Begin();
            Shared.SpriteBatch.DrawString(_font, $"Your Name: {Shared.playerName}", Vector2.Zero, Shared.White);
            Shared.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
