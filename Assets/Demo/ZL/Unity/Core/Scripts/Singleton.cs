using UnityEngine;

namespace ZL.Unity
{
    public abstract class Singleton<T> : MonoBehaviour
        
        where T : Singleton<T>
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