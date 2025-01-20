using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public static class AudioListenerTweener
    {
        public static FloatTweener VolumeTweener { get; private set; }

        static AudioListenerTweener()
        {
            VolumeTweener = new(() => AudioListener.volume, value => AudioListener.volume = value);
        }
    }
}