using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame
{
    public class LineRenderer : WorldObject
    {
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
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            // Tính toán hướng từ điểm bắt đầu đến điểm kết thúc
            var direction = EndPoint - Position;

            // Tính chiều dài của đường thẳng
            var length = direction.Length();

            // Tính góc xoay của đường thẳng
            var angle = (float)Math.Atan2(direction.Y, direction.X);

            // Vẽ đường thẳng bằng cách sử dụng Textures.Pixel
            spriteBatch.Draw(
                texture: Textures.Pixel,               // Texture 1x1 màu trắng
                position: Position,                    // Vị trí bắt đầu của đường thẳng
                sourceRectangle: null,                 // Không sử dụng phần cắt (null để vẽ toàn bộ texture)
                color: Color,                          // Màu sắc của đường thẳng
                rotation: angle,                       // Góc xoay của đường thẳng
                origin: Origin,                        // Điểm gốc để xoay (mặc định là cạnh trái giữa)
                scale: new Vector2(length, Thickness), // Kích thước đường thẳng (dài và dày)
                effects: SpriteEffects.None,           // Không áp dụng hiệu ứng lật
                layerDepth: 0f                         // Độ sâu của layer (0f là trên cùng)
            );
        }
    }
}