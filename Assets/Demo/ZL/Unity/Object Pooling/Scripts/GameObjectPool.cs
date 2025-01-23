using System;

using UnityEngine;

namespace ZL.Unity.ObjectPooling
{
    [Serializable]

    public class GameObjectPool<T> : ObjectPool<T>

        where T : Component
    {
        [SerializeField]

        protected T original;

        public T Original => original;

        [SerializeField, ReadOnlyInPlayMode]

        private Transform parent;
        

        public Transform Parent => parent;

        public void PreGenerate(int count)
        {
            while (count-- > 0)
            {
                Clone().SetActive(false);
            }
        }

        public override T Clone()
        {
            return Pooler.Clone(this);
        }
    }
}