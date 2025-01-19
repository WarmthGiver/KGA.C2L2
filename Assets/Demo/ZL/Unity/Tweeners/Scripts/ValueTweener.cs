using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

namespace ZL.Unity.Tweeners
{
    public abstract class ValueTweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        protected readonly DOGetter<T1> getter;

        protected readonly DOSetter<T1> setter;

        private TweenerCore<T1, T2, TPlugOptions> current;

        public ValueTweener(DOGetter<T1> getter, DOSetter<T1> setter)
        {
            this.getter = getter;

            this.setter = setter;
        }

        protected abstract TweenerCore<T1, T2, TPlugOptions> Instantiate(DOGetter<T1> getter, DOSetter<T1> setter, T2 endValue, float duration);

        public TweenerCore<T1, T2, TPlugOptions> Tween(T2 endValue, float duration)//, bool ignoreElapsed = false)
        {
            /*float remain = 0f;

            if (ignoreElapsed == false)
            {
                remain = current.Remain();
            }*/

            current.Kill();

            current = Instantiate(getter, setter, endValue, duration);// - remain);

            current.SetAutoKill(false);

            current.SetRecyclable(true);

            current.Restart();

            return current;
        }
    }
}