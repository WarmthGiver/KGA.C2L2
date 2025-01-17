using System;

using UnityEngine;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Listener Controller")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(AudioListener))]

    public sealed class AudioListenerController : MonoBehaviour
    {
        [Space]

        [SerializeField, Range(0f, 1f)]

        private float volume = 1f;

        private void OnValidate()
        {
            if (Application.isPlaying == true)
            {
                AudioListener.volume = volume;
            }
        }

#if UNITY_EDITOR

        private void Update()
        {
            volume = AudioListener.volume;
        }

#endif

        private void Awake()
        {
            AudioListener.volume = volume;
        }
    }
}