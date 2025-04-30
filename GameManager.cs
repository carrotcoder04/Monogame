using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Monogame
{
    public class GameManager : Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }
        public Scene Scene { get; private set; }
        public static GameManager Instance { get; private set; }
        public void SetScene(Scene scene)
        {
            this.Scene = scene;
        }
        public GameManager()
        {
            Debug.WriteLine("Game Manager Initialize");
            Instance = this;
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Resource.SetContent(Content);
        }
        protected override void Initialize()
        {
            base.Initialize();
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void Update(GameTime gameTime)
        {
            Scene.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            Scene.Draw(SpriteBatch);
            base.Draw(gameTime);
        }
    }
}
