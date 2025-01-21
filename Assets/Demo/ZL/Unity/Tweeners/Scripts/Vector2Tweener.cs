using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public sealed class Vector2Tweener : ValueTweener<Vector2, Vector2, VectorOptions>
    {
        public Vector2Tweener(DOGetter<Vector2> getter, DOSetter<Vector2> setter) : base(getter, setter) { }

        protected override TweenerCore<Vector2, Vector2, VectorOptions> Instantiate(DOGetter<Vector2> getter, DOSetter<Vector2> setter, Vector2 endValue, float duration)
        {
            return DOTween.To(getter, setter, endValue, duration);
        }
    }
}