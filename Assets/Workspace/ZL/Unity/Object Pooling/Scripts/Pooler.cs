using System;

using UnityEngine;

namespace ZL.Unity.ObjectPooling
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class Pooler : MonoBehaviour
    {
        public static T Clone<T>(GameObjectPool<T> pool)

            where T : Component
        {
            T clone = Instantiate(pool.Original, pool.Parent);

            var pooler = clone.AddComponent<Pooler>();

            pooler.ActionOnDisable = () => pool.Collect(clone);

            pooler.ActionOnDestroy = () => pool.Remove(clone);

            return clone;
        }

        private Action ActionOnDisable = null;

        private void OnDisable()
        {
            ActionOnDisable();
        }

        private Action ActionOnDestroy = null;

        private void OnDestroy()
        {
            ActionOnDestroy();
        }
    }
}