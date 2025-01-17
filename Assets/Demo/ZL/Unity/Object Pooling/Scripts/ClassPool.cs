namespace ZL.Unity.ObjectPooling
{
    public static class ClassPool<T>

        where T : class, new()
    {
        private static readonly Pool pool = new();

        public static T Generate()
        {
            return pool.Generate();
        }

        public static T Clone()
        {
            return pool.Clone();
        }

        public static void Collect(T value)
        {
            pool.Collect(value);
        }

        private sealed class Pool : ObjectPool<T>
        {
            public override T Clone()
            {
                return new T();
            }
        }
    }
}