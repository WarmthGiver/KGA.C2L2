using UnityEngine;

using ZL.Unity.Collections;

using ZL.Unity.ObjectPooling;

namespace ArmadaInvencible
{
    public abstract class PoolManager<TPoolManager, T> : MonoBehaviour

        where TPoolManager : PoolManager<TPoolManager, T>

        where T : Component
    {
        public static TPoolManager Instance { get; private set; }

        [Space]

        [SerializeField]

        private SerializableDictionary<string, GameObjectPool<T>> pools;

        public void Awake()
        {
            Instance = (TPoolManager)this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public virtual T Generate(string key)
        {
            return pools[key].Generate();
        }
    }
}