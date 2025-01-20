using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public static class AudioListenerTweener
    {
        public static FloatTweener Volume { get; private set; }

        static AudioListenerTweener()
        {
            Volume = new(() => AudioListener.volume, value => AudioListener.volume = value);
        }
    }
}