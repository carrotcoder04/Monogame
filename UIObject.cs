using System;
using Microsoft.Xna.Framework;

namespace Monogame
{
    public class UIObject : MonoObject
    {
        public bool IsHovered { get; internal set; } = false;
        public float SortingOrder { get; set; }
        public virtual Vector2 Size { get; set; } = Vector2.One;
        public virtual Vector2 Origin { get; set; } = new Vector2(0.5f, 0.5f);
        public virtual Rectangle Rect
        {
            get
            {
                var topLeft = Position - (Origin * Size);
                return new Rectangle(topLeft.ToPoint(), Size.ToPoint());
            }
        }
        public event Action OnClickEvent;
        public event Action OnHoverEvent;
        public event Action OnHoverExitEvent;
        public event Action OnMouseDownEvent;
        public event Action OnMouseUpEvent;
        protected internal virtual void OnHover()
        {
            OnHoverEvent?.Invoke();
        }
        protected internal virtual void OnClick()
        {
            OnClickEvent?.Invoke();
        }
        protected internal virtual void OnHoverExit()
        {
            OnHoverExitEvent?.Invoke();
        }
        protected internal virtual void OnMouseDown()
        {
            OnMouseDownEvent?.Invoke();
        }
        protected internal virtual void OnMouseUp()
        {
            OnMouseUpEvent?.Invoke();
        }
    }
}