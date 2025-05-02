using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class RectangleRenderer : WorldObject
    {
        public Vector2 Size { get; set; }
        public Color Color { get; set; } = Color.Red;
        public Vector2 Origin { get; set; } = new Vector2(0.5f, 0.5f);
        public int Thickness { get; set; } = 1;

        public RectangleRenderer(int width, int height)
        {
            Size = new Vector2(width, height);
        }

        public RectangleRenderer(int width, int height, Color color) : this(width, height)
        {
            Color = color;
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            // Tính toán vị trí góc trên bên trái của hình chữ nhật
            var position = Position - (Size * Origin);

            // Tạo Rectangle đại diện cho hình chữ nhật
            var rectangle = new Rectangle((int)position.X, (int)position.Y, (int)Size.X, (int)Size.Y);

            // Vẽ cạnh trên
            spriteBatch.Draw(
                texture: Textures.Pixel,                          // Texture 1x1 màu trắng
                position: new Vector2(rectangle.X, rectangle.Y), // Vị trí cạnh trên
                sourceRectangle: null,                           // Không sử dụng phần cắt
                color: Color,                                    // Màu sắc
                rotation: 0f,                                    // Không xoay
                origin: Vector2.Zero,                            // Điểm gốc (mặc định là góc trên bên trái)
                scale: new Vector2(rectangle.Width, Thickness),  // Kích thước (chiều rộng và độ dày)
                effects: SpriteEffects.None,                     // Không áp dụng hiệu ứng lật
                layerDepth: 0f                                   // Độ sâu của layer
            );

            // Vẽ cạnh dưới
            spriteBatch.Draw(
                texture: Textures.Pixel,
                position: new Vector2(rectangle.X, rectangle.Y + rectangle.Height - Thickness),
                sourceRectangle: null,
                color: Color,
                rotation: 0f,
                origin: Vector2.Zero,
                scale: new Vector2(rectangle.Width, Thickness),
                effects: SpriteEffects.None,
                layerDepth: 0f
            );

            // Vẽ cạnh trái
            spriteBatch.Draw(
                texture: Textures.Pixel,
                position: new Vector2(rectangle.X, rectangle.Y),
                sourceRectangle: null,
                color: Color,
                rotation: 0f,
                origin: Vector2.Zero,
                scale: new Vector2(Thickness, rectangle.Height),
                effects: SpriteEffects.None,
                layerDepth: 0f
            );

            // Vẽ cạnh phải
            spriteBatch.Draw(
                texture: Textures.Pixel,
                position: new Vector2(rectangle.X + rectangle.Width - Thickness, rectangle.Y),
                sourceRectangle: null,
                color: Color,
                rotation: 0f,
                origin: Vector2.Zero,
                scale: new Vector2(Thickness, rectangle.Height),
                effects: SpriteEffects.None,
                layerDepth: 0f
            );
        }
    }
}
