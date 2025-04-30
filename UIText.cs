
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class UIText : UIObject
    {
        public SpriteFont Font { get; set; }
        public Color Color { get; set; } = Color.Black;
        public string Text { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; } = Vector2.One;
        public override Vector2 Size => Font.MeasureString(Text) * Scale;
        public UIText(string fontAsset, string text = "WorldText")
        {
            this.Text = text;
            SetFont(fontAsset);
        }
        public UIText(SpriteFont font, string text = "WorldText")
        {
            Font = font;
            Text = text;
        }

        public void SetFont(string fontAsset)
        {
            Font = Resource.Load<SpriteFont>(fontAsset);
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                spriteFont: Font,
                text: Text,
                position: Position,
                color: Color,
                rotation: Rotation,
                origin: Origin * Size,
                scale: Scale,
                effects: SpriteEffects.None,
                layerDepth: 0f
            );
        }
    }
}
