using Microsoft.Xna.Framework.Content;

namespace Monogame
{
    public static class Resource
    {
        private static ContentManager _content;
        internal static void SetContent(ContentManager content)
        {
            _content = content;
        }
        public static T Load<T>(string asset)
        {
            return _content.Load<T>(asset);
        }
        public static void Unload(string asset)
        {
            _content.UnloadAsset(asset);
        }
    }
}
