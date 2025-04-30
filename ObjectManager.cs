using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame {
    internal class ObjectManager<T> where T : MonoObject
    {
        protected Scene Scene { get;private set; }
        public ObjectManager(Scene scene) {
            Scene = scene;
        }
        protected List<T> _objects = new List<T>();
        protected internal virtual void Add(T obj) {
            _objects.Add(obj);
            obj.Initialize();
        }
        protected internal virtual void Remove(T obj) {
            _objects.Remove(obj);
            obj.OnDestroy();
        }
        protected internal virtual void Update(GameTime gameTime) {
            foreach (var obj in _objects) {
                if (obj.IsActive) {
                    obj.Update(gameTime);
                }
            }
        }
        protected internal virtual void Draw(SpriteBatch spriteBatch) {
            foreach (var obj in _objects) {
                if (obj.IsActive) {
                    obj.Draw(spriteBatch);
                }
            }
        }
        internal bool IsObjectOfType(MonoObject obj){
            return obj is T;
        }
        internal bool IsObjectOfType<V>() where V : MonoObject {
            return typeof(V).IsSubclassOf(typeof(T)) || typeof(V) == typeof(T);
        }
        internal V FindObjectOfType<V>() where V: MonoObject {
            foreach (var obj in _objects) {
                if (obj is V) {
                    return obj as V;
                }
            }
            return null;
        }
    }
}