using DG.Tweening;

using System.Collections;

using UnityEngine;

using UnityEngine.SceneManagement;

using ZL.Unity.Tweeners;

using ZL.Unity.UI;

namespace ZL.Unity
{
    [DisallowMultipleComponent]

    public class SceneDirector : MonoBehaviour
    {
        public static SceneDirector Instance { get; private set; }

        [Space]

        [SerializeField]

        private CanvasGroupFader sceneFader;

        [SerializeField]

        private float delay = 0.5f;

        [SerializeField]

        private float fadeDuration = 2f;

        private int pauseCall = 0;

        private void Awake()
        {
            Instance = this;
        }

        protected virtual IEnumerator Start()
        {
            yield return WaitFor.Seconds(delay);

            AudioListenerVolumeTweener.Tweener.Tween(1f, fadeDuration).

                SetEase(Ease.Linear);

            sceneFader.TweenFaded(true, fadeDuration).
                
                SetEase(Ease.Linear);

            yield return WaitFor.Seconds(fadeDuration);
        }

        public void LoadScene(string name)
        {
            void Callback()
            {
                Time.timeScale = 1f;

                SceneManager.LoadScene(name);
            }

            AudioListenerVolumeTweener.Tweener.Tween(0f, fadeDuration).

                SetEase(Ease.Linear).
                
                SetUpdate(true);

            sceneFader.TweenFaded(false, fadeDuration).

                SetEase(Ease.Linear).
                
                OnComplete(Callback);
        }

        public void Pause()
        {
            ++pauseCall;

            Time.timeScale = 0f;
        }

        public void Resume()
        {
            if (--pauseCall <= 0)
            {
                pauseCall = 0;

                Time.timeScale = 1f;
            }
        }

        public void Quit()
        {
            FixedApplication.Quit();
        }
    }
}