using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public static class AudioListenerVolumeTweener
    {
        public static FloatTweener Tweener { get; private set; }

        static AudioListenerVolumeTweener()
        {
            Tweener = new(() => AudioListener.volume, value => AudioListener.volume = value);
        }
    }
}

/*
using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Audio Listener Volume Tweener (Singleton)")]

    [DisallowMultipleComponent]

    public sealed class AudioListenerVolumeTweener : ComponentTweener<FloatTweener, float, float, FloatOptions>
    {
        public static AudioListenerVolumeTweener Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            Tweener = new(() => AudioListener.volume, value => AudioListener.volume = value);
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}
*/