using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    internal class UIManager : ObjectManager<UIObject>
    {
        private UIObject _activeObject;
        public UIManager(Scene scene) : base(scene)
        {
        }
        protected internal override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var mousePosition = InputManager.GetMousePosition();
            foreach (var obj in _objects)
            {
                if (obj.Rect.Contains(mousePosition))
                {
                    if (!obj.IsHovered)
                    {
                        obj.IsHovered = true;
                        obj.OnHover();
                    }
                    if (InputManager.IsMouseLeftPressed())
                    {
                        _activeObject = obj; 
                        obj.OnMouseDown();
                    }
                    if (InputManager.IsMouseLeftClicked())
                    {
                        obj.OnClick();
                    }
                }
                else
                {
                    if (obj.IsHovered)
                    {
                        obj.IsHovered = false;
                        obj.OnHoverExit();
                    }
                }
            }
            if (InputManager.IsMouseLeftReleased() && _activeObject != null)
            {
                _activeObject.OnMouseUp();
                _activeObject = null;
            }
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: Matrix.Identity);
            base.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}