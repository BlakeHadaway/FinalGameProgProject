/*
 * InputManager.cs
 * Outbreak game
 * Revision History
 *      Blake Power, 2022.11.30: Created
 *      Blake Power, 2022.11.30: Added code
 *      Blake Power, 2022.12.11: Comments added
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Managers
{
    public class InputManager
    {
        // laststates for getting previous inputs 
        private static MouseState _lastMouseState;
        private static KeyboardState _lastKeyboardState;

        // direction
        private static Vector2 _direction;

        // setting a new direction to equal the other direction
        public static Vector2 Direction => _direction;

        // Mouse position being set by a GetState 
        public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();

        // bool for mouseclicked
        public static bool MouseClicked { get; private set; }

        // bool for right mouse clicked
        public static bool MouseRightClicked { get; private set; }

        // bool for mouse left down
        public static bool MouseLeftDown { get; private set; }

        // bool for spacepressed 
        public static bool SpacePressed { get; private set; }

        // bool for scrollwheel down
        public static bool ScrollWheelDown { get; private set; }

        // bool for scrollwheel up
        public static bool ScrollWheelUp { get; private set; }

        /// <summary>
        /// Keyboardstate = getstate and mousestate = getstate. 
        /// _direction = zero and then when a movement key is pressed it will move in the
        /// according direction. When any of the inputs are used they will set the button state 
        /// to pressed when pressed and released when released and then set the previous state for keyboard and mouse.
        /// </summary>
        public static void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            _direction = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.W))
                _direction.Y--;

            if (keyboardState.IsKeyDown(Keys.S))
                _direction.Y++;

            if (keyboardState.IsKeyDown(Keys.A))
                _direction.X--;

            if (keyboardState.IsKeyDown(Keys.D))
                _direction.X++;


            MouseLeftDown = mouseState.LeftButton == ButtonState.Pressed;
            MouseClicked = MouseLeftDown && (_lastMouseState.LeftButton == ButtonState.Released);
            MouseRightClicked = mouseState.RightButton == ButtonState.Pressed
                                && (_lastMouseState.RightButton == ButtonState.Released);

            ScrollWheelUp = mouseState.ScrollWheelValue > _lastMouseState.ScrollWheelValue;
            ScrollWheelDown = mouseState.ScrollWheelValue < _lastMouseState.ScrollWheelValue;

            _lastKeyboardState = keyboardState;
            _lastMouseState = Mouse.GetState();
        }
    }
}
