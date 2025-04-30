using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame
{
    public class Scene
    {
        public static Scene Instance { get; private set; }
        private GameManager Game => GameManager.Instance;
        private WorldManager _worldManager;
        private UIManager _uiManager;
        private Queue<MonoObject> _addQueue = new Queue<MonoObject>();
        private Queue<MonoObject> _destroyQueue = new Queue<MonoObject>();
        public Camera2D Camera { get; private set; }
        public Scene(Camera2D camera = null)
        {
            if (camera == null)
            {
                Camera = new Camera2D(Game.GraphicsDevice.Viewport);
            }
            else
            {
                Camera = camera;
            }
            Add(Camera);
            _worldManager = new WorldManager(this);
            _uiManager = new UIManager(this);
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
                if(_uiManager.IsObjectOfType(obj))
                {
                    _uiManager.Add((UIObject)obj);
                }
                else
                {
                    _worldManager.Add((WorldObject)obj);
                }
            }
            while (_destroyQueue.Count > 0)
            {
                var obj = _destroyQueue.Dequeue();
                if (_uiManager.IsObjectOfType(obj))
                {
                    _uiManager.Remove((UIObject)obj);
                }
                else
                {
                    _worldManager.Remove((WorldObject)obj);
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            Prepair();
            _worldManager.Update(gameTime);
            _uiManager.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            _worldManager.Draw(spriteBatch);
            _uiManager.Draw(spriteBatch);
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
            if (_worldManager.IsObjectOfType<T>()) return _worldManager.FindObjectOfType<T>();
            else
            {
                return _uiManager.FindObjectOfType<T>();
            }
        }
        internal void RequestSort()
        {
            _uiManager.IsSortRequest = true;
        }
    }
}