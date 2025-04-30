using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class MonoObject
    {
        protected GameManager GameManager => GameManager.Instance;
        protected Scene MyScene => Scene.Instance;
        public string Name { get; set; } = "MonoObject";
        public Vector2 Position { get; set; }
        public bool IsActive { get; set; } = true;
        protected internal virtual void Initialize()
        {
        }
        protected internal virtual void Update(GameTime gameTime)
        {
        }
        protected internal virtual void Draw(SpriteBatch spriteBatch)
        {
        }
        protected internal virtual void OnDestroy()
        {
        }
        public void Destroy()
        {
            MyScene.Destroy(this);
        }
    }
}
