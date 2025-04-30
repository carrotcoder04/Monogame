using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Monogame;
public class Sprite
{
    public Texture2D Texture { get; set; }
    public Rectangle SourceRect { get; set; }
    public Vector2 Origin { get; set; } = new Vector2(0.5f, 0.5f);
    public Sprite(Texture2D texture, Rectangle sourceRect)
    {
        Texture = texture;
        SourceRect = sourceRect;
    }
}
