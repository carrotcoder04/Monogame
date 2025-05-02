using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class DrawableText : Drawable
    {
        public string Text { get; set; }
        public SpriteFont Font { get; set; }

        public DrawableText(SpriteFont font, string text)
        {
            Font = font;
            Text = text;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                spriteFont: Font,
                text: Text,
                position: Position,
                color: Color,
                rotation: Rotation,
                origin: Origin,
                scale: Scale,
                effects: SpriteEffects.None,
                layerDepth: LayerDepth
            );
        }

        public override Drawable Clone()
        {
            return new DrawableText(Font, Text)
            {
                Position = Position,
                Color = Color,
                Rotation = Rotation,
                Origin = Origin,
                Scale = Scale,
                LayerDepth = LayerDepth
            };
        }

        public override void SetOrginCenter()
        {
            Origin = Font.MeasureString(Text) * Scale / 2f;
        }
    }
}