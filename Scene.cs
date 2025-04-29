using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class Scene
    {
        public static Scene Instance { get; private set; }
        private Game _game;
        private List<MonoObject> _objects = new List<MonoObject>();
        private List<UIObject> _uiObjects = new List<UIObject>();
        private Queue<MonoObject> _addQueue = new Queue<MonoObject>();
        private Queue<MonoObject> _destroyQueue = new Queue<MonoObject>();
        public Camera2D Camera { get; private set; }
        public Scene(Game game, Camera2D camera = null)
        {
            _game = game;
            if (camera == null)
            {
                Camera = new Camera2D(game.GraphicsDevice.Viewport);
            }
            else
            {
                Camera = camera;
            }
            Add(Camera);
            Instance = this;
            Initialize();
        }
        protected virtual void Initialize()
        {

        }
        private void Prepair()
        {
            while (_addQueue.Count > 0)
            {
                var obj = _addQueue.Dequeue();
                if (obj is UIObject uiObject)
                {
                    _uiObjects.Add(uiObject);
                }
                else
                {
                    _objects.Add(obj);
                }
                obj.Initialize();
            }
            while (_destroyQueue.Count > 0)
            {
                var obj = _destroyQueue.Dequeue();
                obj.OnDestroy();
                if (obj is UIObject uiObject)
                {
                    _uiObjects.Remove(uiObject);
                }
                else
                {
                    _objects.Remove(obj);
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            Prepair();
            foreach (var obj in _objects)
            {
                if (obj.IsActive)
                {
                    obj.Update(gameTime);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: Camera.GetViewMatrix());
            foreach (var obj in _objects)
            {
                if (obj.IsActive)
                {
                    obj.Draw(spriteBatch);
                }
            }
            spriteBatch.End();
            spriteBatch.Begin(transformMatrix: Matrix.Identity);
            foreach (var obj in _uiObjects)
            {
                if (obj.IsActive)
                {
                    obj.Draw(spriteBatch);
                }
            }
            spriteBatch.End();
        }
        public void Destroy(MonoObject obj)
        {
            _destroyQueue.Enqueue(obj);
        }
        public void Add(MonoObject obj)
        {
            _addQueue.Enqueue(obj);
        }
        public T FindObject<T>() where T : MonoObject
        {
            foreach (var obj in _objects)
            {
                if (obj is T tObj)
                {
                    return tObj;
                }
            }
            foreach (var obj in _uiObjects)
            {
                if (obj is T tObj)
                {
                    return tObj;
                }
            }
            return null;
        }
    }
}