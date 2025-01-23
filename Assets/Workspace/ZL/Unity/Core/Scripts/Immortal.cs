using UnityEngine;

namespace ZL.Unity
{
    public abstract class Immortal<T> : MonoBehaviour
        
        where T : Immortal<T>
    {
        public static T Instance { get; protected set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);

                return;
            }

            Instance = (T)this;

            DontDestroyOnLoad(gameObject);

            OnAwake();
        }

        protected virtual void OnAwake() { }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}