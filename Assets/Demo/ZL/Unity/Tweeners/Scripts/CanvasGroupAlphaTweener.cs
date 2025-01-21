using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Canvas Group Alpha Tweener")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(CanvasGroup))]

    public sealed class CanvasGroupAlphaTweener : ComponentTweener<FloatTweener, float, float, FloatOptions>
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private CanvasGroup canvasGroup;

        private void Awake()
        {
            ValueTweener = new(() => canvasGroup.alpha, value => canvasGroup.alpha = value);
        }
    }
}