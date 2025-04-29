using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Monogame
{
    public class Camera2D : MonoObject
    {
        private Viewport _viewport;
        public float Zoom { get; set; } = 1.0f;
        public float Rotation { get; set; } = 0.0f;
        public Camera2D(Viewport viewport)
        {
            _viewport = viewport;
        }
        public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1.0f) *
                Matrix.CreateTranslation(new Vector3(_viewport.Width * 0.5f, _viewport.Height * 0.5f, 0.0f));
        }
        public Vector2 ScreenToWorldPoint(Vector2 point)
        {
            Matrix viewMatrix = GetViewMatrix();
            Matrix invertedView = Matrix.Invert(viewMatrix);
            Vector2 worldPos = Vector2.Transform(point, invertedView);
            return worldPos;
        }
        protected internal override void OnDestroy()
        {
            throw new System.Exception("Could not destroy camera object.");
        }
    }
}
