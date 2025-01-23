using System;

namespace ZL.Unity.Collections
{
    [Serializable]

    public sealed class Wrapper<T>
    {
        public T value;

        public Wrapper() { }

        public Wrapper(T value)
        {
            this.value = value;
        }
    }
}