using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Canvas Group Manager")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroupFader))]

    public sealed class CanvasGroupManager : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private CanvasGroupFader fader;

        [Space]

        [SerializeField, Essential]

        private ManagedCanvasGroup home;

        private ManagedCanvasGroup current;

        private void Awake()
        {
            current = home;
        }

        private void OnDisable()
        {
            current.Fader.IsFaded = true;

            current = home;

            current.Fader.IsFaded = false;
        }

        public ManagedCanvasGroup SetCurrent(ManagedCanvasGroup target)
        {
            var prev = current;

            current = target;

            return prev;
        }
    }
}