using DG.Tweening;

using System.Collections;

using UnityEngine;

using UnityEngine.SceneManagement;

using ZL.Unity.Tweeners;

using ZL.Unity.UI;

namespace ZL.Unity
{
    [DisallowMultipleComponent]

    public abstract class SceneDirector : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private CanvasGroupFader sceneFader;

        [SerializeField]

        private float fadeDuration = 2f;

        protected virtual IEnumerator Start()
        {
            AudioListenerTweener.VolumeTweener.Tween(1f, fadeDuration).

                SetEase(Ease.Linear);

            sceneFader.TweenFaded(true, fadeDuration).
                
                SetEase(Ease.Linear);

            yield return WaitFor.Seconds(fadeDuration);
        }

        public void LoadScene(string name)
        {
            void LoadScene() => SceneManager.LoadScene(name);

            AudioListenerTweener.VolumeTweener.Tween(0f, fadeDuration).

                SetEase(Ease.Linear);

            sceneFader.TweenFaded(false, fadeDuration).

                SetEase(Ease.Linear).
                
                OnComplete(LoadScene);
        }

        public void Quit()
        {
            FixedApplication.Quit();
        }
    }
}