using UnityEngine;

namespace ZL.Unity.Tweeners
{
    public static class AudioListenerTweener
    {
        public static readonly FloatTweener volumeTweener;

        static AudioListenerTweener()
        {
            volumeTweener = new(() => AudioListener.volume, value => AudioListener.volume = value);
        }
    }
}