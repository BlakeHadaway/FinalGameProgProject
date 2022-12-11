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
        private static MouseState _lastMouseState;
        private static KeyboardState _lastKeyboardState;

        private static Vector2 _direction;
        public static Vector2 Direction => _direction;
        public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
        public static bool MouseClicked { get; private set; }
        public static bool MouseRightClicked { get; private set; }
        public static bool MouseLeftDown { get; private set; }
        public static bool SpacePressed { get; private set; }
        public static bool ScrollWheelDown { get; private set; }
        public static bool ScrollWheelUp { get; private set; }

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
