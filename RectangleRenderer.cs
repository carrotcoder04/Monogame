using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class RectangleRenderer : WorldObject
    {
        private static Texture2D _pixel;
        public Vector2 Size { get; set; }
        public Color Color { get; set; } = Color.Red;
        public Vector2 Origin { get; set; } = new Vector2(0.5f, 0.5f);
        public int Thickness { get; set; } = 1;
        public RectangleRenderer(int width,int height)
        {
            Size = new Vector2(width,height);
            if(_pixel == null)
            {
                _pixel = new Texture2D(GameManager.GraphicsDevice,1,1);
                _pixel.SetData([Color.White]);
            }
        }
        public RectangleRenderer(int width,int height, Color color) : this(width,height) 
        {
            Color = color;
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            var position = Position - (Size * Origin);
            var rectangle = new Rectangle((int)position.X, (int)position.Y, (int)Size.X, (int)Size.Y);
            spriteBatch.Draw(_pixel, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, Thickness), Color);
            spriteBatch.Draw(_pixel, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height - Thickness, rectangle.Width, Thickness), Color);
            spriteBatch.Draw(_pixel, new Rectangle(rectangle.X, rectangle.Y, Thickness, rectangle.Height), Color);
            spriteBatch.Draw(_pixel, new Rectangle(rectangle.X + rectangle.Width - Thickness, rectangle.Y, Thickness, rectangle.Height), Color);
        }
    }
}
