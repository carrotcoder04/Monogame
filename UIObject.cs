using Microsoft.Xna.Framework;

namespace Monogame
{
    public class UIObject : MonoObject
    {
        public int SortingOrder { get; private set; }
        public virtual Vector2 Size { get; set; } = Vector2.One;
        public virtual Vector2 Origin { get; set; } = new Vector2(0.5f, 0.5f);
        public Rectangle Rect
        {
            get
            {
                var topLeft = Position - (Origin * Size);
                return new Rectangle(topLeft.ToPoint(), Size.ToPoint());
            }
        }
        public void SetSortingOrder(int order)
        {
            this.SortingOrder = order;
            MyScene.RequestSort();
        }
    }
}