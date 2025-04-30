using Microsoft.Xna.Framework.Graphics;

namespace Monogame {
    internal class WorldManager : ObjectManager<WorldObject>
    {
        public WorldManager(Scene scene) : base(scene)
        {
        }

        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: Scene.Camera.GetViewMatrix());
            base.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}