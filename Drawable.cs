using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public abstract class Drawable
    {
        public Vector2 Position { get; set; }
        public Color Color { get; set; } = Color.White;
        public float Rotation { get; set; } = 0f;
        public Vector2 Scale { get; set; } = Vector2.One;
        public Vector2 Origin { get; set; } = Vector2.Zero;
        public float LayerDepth { get; set; } = 0f;
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract Drawable Clone();
        public abstract void SetOrginCenter();
    }
}