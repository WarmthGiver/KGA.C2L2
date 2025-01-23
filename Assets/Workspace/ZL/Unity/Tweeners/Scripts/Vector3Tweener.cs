using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public sealed class Vector3Tweener : ValueTweener<Vector3, Vector3, VectorOptions>
    {
        public Vector3Tweener(DOGetter<Vector3> getter, DOSetter<Vector3> setter) : base(getter, setter) { }

        protected override TweenerCore<Vector3, Vector3, VectorOptions> Instantiate(DOGetter<Vector3> getter, DOSetter<Vector3> setter, Vector3 endValue, float duration)
        {
            return DOTween.To(getter, setter, endValue, duration);
        }
    }
}