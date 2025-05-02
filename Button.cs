using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame
{
    public class Button : UIObject
    {
        public DrawableTexture Background { get; set; }
        public DrawableText TextDrawable { get; set; }

        public Color HoverColor { get; set; } = Color.Gray;
        public Color ClickColor { get; set; } = Color.DarkGray;

        private Color _originalBackgroundColor;

        public Button(DrawableTexture background, DrawableText textDrawable)
        {
            Background = background;
            TextDrawable = textDrawable;

            _originalBackgroundColor = Background.Color;
        }
        public override Rectangle Rect
        {
            get
            {
                var size = new Vector2(Background.Texture.Width, Background.Texture.Height) * Background.Scale;
                return new Rectangle((Background.Position - (Background.Origin * size)).ToPoint(), size.ToPoint());
            }
        }
        protected internal override void OnHover()
        {
            base.OnHover();
            Background.Color = HoverColor;
            Mouse.SetCursor(MouseCursor.Hand);
        }
        protected internal override void OnHoverExit()
        {
            base.OnHoverExit();
            Background.Color = _originalBackgroundColor;
            Mouse.SetCursor(MouseCursor.Arrow);
        }
        protected internal override void OnMouseDown()
        {
            base.OnMouseDown();
            Background.Color = ClickColor;
        }
        protected internal override void OnMouseUp()
        {
            base.OnMouseUp();
            Background.Color = HoverColor;
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            Background?.Draw(spriteBatch);
            TextDrawable?.Draw(spriteBatch);
        }
    }
}