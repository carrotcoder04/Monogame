using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public static class Textures
    {
        public static Texture2D Pixel { get; private set; }

        internal static void Initialize(GraphicsDevice graphicsDevice)
        {
            if (Pixel == null)
            {
                Pixel = new Texture2D(graphicsDevice, 1, 1);
                Pixel.SetData([Color.White]);
            }
        }
    }
}