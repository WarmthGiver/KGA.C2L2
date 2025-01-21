using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public sealed class QuaternionTweener : ValueTweener<Quaternion, Vector3, QuaternionOptions>
    {
        public QuaternionTweener(DOGetter<Quaternion> getter, DOSetter<Quaternion> setter) : base(getter, setter) { }

        protected override TweenerCore<Quaternion, Vector3, QuaternionOptions> Instantiate(DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, Vector3 endValue, float duration)
        {
            return DOTween.To(getter, setter, endValue, duration);
        }
    }
}