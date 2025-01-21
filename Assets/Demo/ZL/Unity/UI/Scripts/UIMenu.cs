using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Menu")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroupFader))]

    public class UIMenu : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponentInParentOnly, ReadOnly]

        private UIMenuManager manager;

        [Space]

        [SerializeField, GetComponent, ReadOnly]

        protected CanvasGroupFader fader;

        public CanvasGroupFader Fader => fader;

        private UIMenu prev = null;

        public virtual void Enable()
        {
            prev = manager.SetCurrent(this);

            if (prev != null)
            {
                prev.fader.TweenFaded(true, 0.1f);
            }

            fader.TweenFaded(false, 0.1f);
        }

        public virtual void Disable()
        {
            if (prev != null)
            {
                manager.SetCurrent(prev);

                prev.fader.TweenFaded(false, 0.1f);
            }

            fader.TweenFaded(true, 0.1f);
        }
    }
}