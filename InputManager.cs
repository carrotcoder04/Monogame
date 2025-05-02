using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Monogame
{
    public static class InputManager
    {
        private static KeyboardState _currentKeyboardState;
        private static KeyboardState _previousKeyboardState;
        private static MouseState _currentMouseState;
        private static MouseState _previousMouseState;

        public static void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();

            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
        }

        public static bool IsKeyPressed(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key) && !_previousKeyboardState.IsKeyDown(key);
        }

        public static bool IsMouseLeftPressed()
        {
            return _currentMouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool IsMouseLeftReleased()
        {
            return _currentMouseState.LeftButton == ButtonState.Released &&
                   _previousMouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool IsMouseLeftClicked()
        {
            return _currentMouseState.LeftButton == ButtonState.Pressed &&
                   _previousMouseState.LeftButton == ButtonState.Released;
        }

        public static Vector2 GetMousePosition()
        {
            return new Vector2(_currentMouseState.X, _currentMouseState.Y);
        }
    }
}