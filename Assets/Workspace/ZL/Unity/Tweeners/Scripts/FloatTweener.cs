using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

namespace ZL.Unity.Tweeners
{
    public sealed class FloatTweener : ValueTweener<float, float, FloatOptions>
    {
        public FloatTweener(DOGetter<float> getter, DOSetter<float> setter) : base(getter, setter) { }

        protected override TweenerCore<float, float, FloatOptions> Instantiate(DOGetter<float> getter, DOSetter<float> setter, float endValue, float duration)
        {
            return DOTween.To(getter, setter, endValue, duration);
        }
    }
}