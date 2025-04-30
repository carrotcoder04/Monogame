using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame
{
    public class LineRenderer : WorldObject
    {
        private static Texture2D _pixel;
        public Vector2 EndPoint { get; set; }
        public Color Color { get; set; } = Color.White;
        public int Thickness { get; set; } = 1;
        public Vector2 Origin { get; set; } = new Vector2(0f, 0.5f);

        public LineRenderer(Vector2 startPoint, Vector2 endPoint, Color color, int thickness = 1)
        {
            Position = startPoint;
            EndPoint = endPoint;
            Color = color;
            Thickness = thickness;

            if (_pixel == null)
            {
                _pixel = new Texture2D(GameManager.GraphicsDevice, 1, 1);
                _pixel.SetData([Color.White]);
            }
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            var direction = EndPoint - Position;
            var length = direction.Length();
            var angle = (float)Math.Atan2(direction.Y, direction.X);
            spriteBatch.Draw(
                _pixel,
                Position,
                null,
                Color,
                angle,
                Origin,
                new Vector2(length, Thickness),
                SpriteEffects.None,
                0f
            );
        }
    }
}