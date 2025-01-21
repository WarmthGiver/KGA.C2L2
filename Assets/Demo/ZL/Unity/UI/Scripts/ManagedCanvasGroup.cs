using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Canvas Group (Managed)")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroupFader))]

    public class ManagedCanvasGroup : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        protected CanvasGroupFader fader;

        public CanvasGroupFader Fader => fader;

        [Space]

        [SerializeField]

        private CanvasGroupManager manager;

        private ManagedCanvasGroup prev = null;

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
                prev.Enable();
            }


        }
    }
}