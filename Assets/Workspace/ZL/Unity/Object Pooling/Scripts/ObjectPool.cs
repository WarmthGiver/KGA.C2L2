using System.Collections.Generic;

using ZL.Unity.Collections;

namespace ZL.Unity.ObjectPooling
{
    public abstract class ObjectPool<T>

        where T : class
    {
        private readonly LinkedList<T> stock = new();

        public virtual T Generate()
        {
            if (stock.Count == 0)
            {
                return Clone();
            }

            return stock.PopLast();
        }

        public abstract T Clone();

        public virtual void Collect(T value)
        {
            stock.AddLast(value);
        }

        public void Remove(T value)
        {
            stock.Remove(value);
        }
    }
}