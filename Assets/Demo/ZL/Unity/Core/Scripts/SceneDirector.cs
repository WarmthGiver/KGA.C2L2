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
            sceneFader.TweenFaded(true, fadeDuration).Current.SetEase(Ease.Linear);

            AudioListenerTweener.Volume.Tween(1f, fadeDuration);

            yield return WaitFor.Seconds(fadeDuration);
        }

        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void Quit()
        {
            FixedApplication.Quit();
        }
    }
}