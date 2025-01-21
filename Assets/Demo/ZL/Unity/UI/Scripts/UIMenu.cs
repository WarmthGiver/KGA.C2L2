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

        public virtual void Enable()
        {
            if (manager.Current != null)
            {
                manager.Current.Disable();
            }

            manager.Current = this;

            fader.TweenFaded(false, 0.1f);
        }

        public virtual void Disable()
        {
            manager.Current = null;

            fader.TweenFaded(true, 0.1f);
        }
    }
}