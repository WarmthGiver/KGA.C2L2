using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Audio Source Tweener")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(AudioSource))]

    public sealed class AudioSourceTweener : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private AudioSource audioSource;

        public FloatTweener Volume { get; private set; }

        private void Awake()
        {
            Volume = new(() => audioSource.volume, value => audioSource.volume = value);
        }
    }
}