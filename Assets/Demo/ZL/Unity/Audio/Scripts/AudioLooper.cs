using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Looper (Singleton)")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(AudioSource))]

    public sealed class AudioLooper : Singleton<AudioLooper>
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private AudioSource audioSource;

        [Space]

        [SerializeField]

        private bool playOnAwake = true;

        [SerializeField]

        private BGMPlayMode playMode = BGMPlayMode.RepeatOne;

        public BGMPlayMode PlayMode { set => PlayMode = value; }

        [Space]

        [SerializeField, ToggledField(nameof(isPlayModeShuffle), true)]

        [Button(nameof(Play))]

        [Button(nameof(Pause))]

        [Button(nameof(Resume))]

        private int playlistIndex = 0;

        [SerializeField]

        private Wrapper<AudioClip[]> playlist;

        private bool isLooping = false;

#if UNITY_EDITOR

        [HideInInspector]

        public bool isPlayModeShuffle;

#endif

        private void OnValidate()
        {
            isPlayModeShuffle = playMode == BGMPlayMode.Shuffle;
        }

        protected override void OnAwake()
        {
            if (playOnAwake == true)
            {
                PlayLoop();
            }
        }

        private void Update()
        {
            if (isLooping == true && audioSource.isPlaying == false)
            {
                Play();
            }
        }

        public void PlayLoop(int index)
        {
            playlistIndex = index;

            PlayLoop();
        }

        public void PlayLoop()
        {
            isLooping = true;
        }

        public void Pause()
        {
            isLooping = false;

            audioSource.Pause();
        }

        public void Resume()
        {
            isLooping = true;

            audioSource.Play();
        }

        public void Play()
        {
            switch (playMode)
            {
                case BGMPlayMode.RepeatAll:

                    ++playlistIndex;

                    if (playlistIndex > playlist.value.Length - 1)
                    {
                        playlistIndex = 0;
                    }

                    break;

                case BGMPlayMode.Reverse:

                    --playlistIndex;

                    if (playlistIndex < 0)
                    {
                        playlistIndex = playlist.value.Length - 1;
                    }

                    break;

                case BGMPlayMode.Shuffle:

                    while (true)
                    {
                        int index = Random.Range(0, playlist.value.Length);

                        if (playlistIndex != index)
                        {
                            playlistIndex = index;

                            break;
                        }
                    }

                    break;
            }

            audioSource.clip = playlist.value[playlistIndex];

            audioSource.Play();
        }

        public enum BGMPlayMode
        {
            RepeatOne,

            RepeatAll,

            Reverse,

            Shuffle,
        }
    }
}