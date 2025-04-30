using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    internal class UIManager : ObjectManager<UIObject>
    {
        public bool IsSortRequest { get; set; }
        public UIManager(Scene scene) : base(scene)
        {
        }
        protected internal override void Add(UIObject obj)
        {
            base.Add(obj);
            IsSortRequest = true;
        }
        protected internal override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(IsSortRequest)
            {
                _objects.Sort((a,b) => a.SortingOrder.CompareTo(b.SortingOrder));
                IsSortRequest = false;
            }
        }
        protected internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: Matrix.Identity);
            base.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}