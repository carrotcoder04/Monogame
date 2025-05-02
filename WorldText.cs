using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class WorldText : WorldObject
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
        public float SortingOrder
        {
            get => _drawableText.LayerDepth;
            set => _drawableText.LayerDepth = value;
        }
        public Vector2 Origin { get; set; } = new Vector2(0.5f, 0.5f);

        public Vector2 Size => Font.MeasureString(Text) * Scale;

        public WorldText(string fontAsset, string text = "WorldText")
        {
            _drawableText = new DrawableText(Resource.Load<SpriteFont>(fontAsset), text)
            {
                Color = Color.Black
            };
        }

        public WorldText(SpriteFont font, string text = "WorldText")
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
