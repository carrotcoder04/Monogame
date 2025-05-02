using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class DrawableTexture : Drawable
    {
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public DrawableTexture(Texture2D texture)
        {
            Texture = texture;
            SourceRectangle = texture.Bounds;
        }
        public DrawableTexture(Texture2D texture, Rectangle sourceRect)
        {
            Texture = texture;
            SourceRectangle = sourceRect;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: Texture,
                position: Position,
                sourceRectangle: SourceRectangle,
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
            return new DrawableTexture(Texture)
            {
                Texture = Texture,
                SourceRectangle = SourceRectangle,
                Color = Color,
                Rotation = Rotation,
                Origin = Origin,
                Scale = Scale,
                LayerDepth = LayerDepth
            };
        }
        public override void SetOrginCenter()
        {
            Origin = new Vector2(SourceRectangle.Width, SourceRectangle.Height) * Scale / 2f;
        }
    }
}