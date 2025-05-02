using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class UIText : UIObject
    {
        private DrawableText _drawableText;
        
        public SpriteFont Font
        {
            get => _drawableText.Font;
            set => _drawableText.Font = value;
        }

        public Color Color
        {
            get => _drawableText.Color;
            set => _drawableText.Color = value;
        }

        public string Text
        {
            get => _drawableText.Text;
            set => _drawableText.Text = value;
        }

        public float Rotation
        {
            get => _drawableText.Rotation;
            set => _drawableText.Rotation = value;
        }

        public Vector2 Scale
        {
            get => _drawableText.Scale;
            set => _drawableText.Scale = value;
        }
        public override Vector2 Size => Font.MeasureString(Text) * Scale;

        public UIText(string fontAsset, string text = "UIText")
        {
            _drawableText = new DrawableText(Resource.Load<SpriteFont>(fontAsset), text)
            {
                Color = Color.Black
            };
        }
        public UIText(SpriteFont font, string text = "UIText")
        {
            _drawableText = new DrawableText(font, text)
            {
                Color = Color.Black
            };
        }
        public void SetFont(string fontAsset)
        {
            Font = Resource.Load<SpriteFont>(fontAsset);
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            _drawableText.Position = Position;
            _drawableText.Origin = Origin * Size;
            _drawableText.LayerDepth = SortingOrder;
            _drawableText.Draw(spriteBatch);
        }
        public DrawableText GetCloneDrawableText()
        {
            return (DrawableText)_drawableText.Clone();
        }
    }
}
