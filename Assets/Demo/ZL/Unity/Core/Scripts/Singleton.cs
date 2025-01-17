using UnityEngine;

namespace ZL.Unity
{
    public abstract class Singleton<T> : MonoBehaviour
        
        where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        protected void Awake()
        {
            if (Instance == null)
            {
                Instance = (T)this;

                DontDestroyOnLoad(gameObject);

                OnAwake();

                return;
            }

            Destroy(gameObject);
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