using DG.Tweening;

using System;

using UnityEngine;

using ZL.Unity.Tweeners;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Canvas Group Fader")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroupAlphaTweener))]

    public sealed class CanvasGroupFader : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private CanvasGroup canvasGroup;

        [SerializeField, GetComponent, ReadOnly]

        private CanvasGroupAlphaTweener alphaTweener;

        [Space]

        [SerializeField]

        private bool isFaded = false;

        public bool IsFaded
        {
            get => isFaded;

            set
            {
                isFaded = value;

                if (isFaded == true)
                {
                    canvasGroup.alpha = 0f;

                    OnFaded();
                }

                else
                {
                    gameObject.SetActive(true);

                    canvasGroup.alpha = 1f;
                }
            }
        }

        public event Action ActionOnFaded = null;

        private void Awake()
        {
            IsFaded = isFaded;
        }

        public FloatTweener TweenFaded(bool value, float duration)
        {
            isFaded = value;

            if (isFaded == true)
            {
                alphaTweener.ValueTweener.Tween(0f, duration).

                    OnComplete(OnFaded);
            }

            else
            {
                gameObject.SetActive(true);

                alphaTweener.ValueTweener.Tween(1f, duration);
            }

            return alphaTweener.ValueTweener;
        }

        private void OnFaded()
        {
            gameObject.SetActive(false);

            ActionOnFaded?.Invoke();

            ActionOnFaded = null;
        }
    }
}