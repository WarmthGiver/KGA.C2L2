using DG.Tweening;

using DG.Tweening.Core;

using DG.Tweening.Plugins.Options;

using System;

using System.Collections.Generic;
using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [Serializable]

    public sealed class KeyFrames<T>
    {
        [Space]

        [SerializeField]

        private int index = 0;

        public int Index
        {
            get => index;

            set => index = value.Repeat(keyFrames.Count);
        }

        [Space]

        [SerializeField]

        private List<T> keyFrames;

        public KeyFrames()
        {
            keyFrames = new();
        }

        public KeyFrames(int capacity)
        {
            keyFrames = new(capacity);
        }

        public KeyFrames(params T[] values)
        {
            keyFrames = new(values);
        }

        public T Current()
        {
            return keyFrames[index];
        }

        public T Current(int index)
        {
            Index = index;

            return keyFrames[Index];
        }

        public T Next()
        {
            return keyFrames[++Index];
        }

        public T Prev()
        {
            return keyFrames[--Index];
        }
    }

    public abstract class KeyFrameTweener<TComponentTweener, TValueTweener, T1, T2, TPlugOptions> : MonoBehaviour

        where TComponentTweener : ComponentTweener<TValueTweener, T1, T2, TPlugOptions>

        where TValueTweener : ValueTweener<T1, T2, TPlugOptions>

        where TPlugOptions : struct, IPlugOptions
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        protected TComponentTweener componentTweener;

        [Space]

        [SerializeField]

        protected float duration = 0f;

        [Space]

        [SerializeField]

        protected KeyFrames<T2> keyFrames;

        [Space]

        [SerializeField]

        private Ease ease;

        private void OnValidate()
        {
            SetKeyFrame(keyFrames.Index);
        }

        public abstract void SetKeyFrame(int index);

        public void TweenKeyFrameNext()
        {
            ++keyFrames.Index;

            TweenKeyFrame();
        }

        public void TweenKeyFramePrev()
        {
            --keyFrames.Index;

            TweenKeyFrame();
        }

        public void TweenKeyFrame(int index)
        {
            keyFrames.Index = index;

            TweenKeyFrame();
        }

        protected virtual TweenerCore<T1, T2, TPlugOptions> TweenKeyFrame()
        {
            return componentTweener.ValueTweener.Tween(keyFrames.Current(), duration).SetEase(ease);
        }
    }
}