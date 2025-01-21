using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Rect Transform Tweener")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(RectTransform))]

    public sealed class RectTransformTweener : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private RectTransform rectTransform;

        public Vector2Tweener AnchorPositionTweener { get; private set; }

        private void Awake()
        {
            AnchorPositionTweener = new(() => rectTransform.anchoredPosition, value => rectTransform.anchoredPosition = value);
        }
    }
}