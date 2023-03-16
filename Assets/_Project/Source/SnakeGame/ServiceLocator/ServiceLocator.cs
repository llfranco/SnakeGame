namespace SnakeGame
{
    public static class ServiceLocator<T> where T : IService
    {
        private static object _key;
        private static T _service;

        public static T GetService()
        {
            return _service;
        }

        public static void SetKey(object key)
        {
            _key = key;
        }

        public static void SetService(T service, object key = null)
        {
            if (key != _key)
            {
                return;
            }

            _service = service;
        }
    }
}