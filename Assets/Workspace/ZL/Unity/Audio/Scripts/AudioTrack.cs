using UnityEngine;

using ZL.Unity.Collections;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Track (Singleton)")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(AudioSource))]

    public sealed class AudioTrack : Immortal<AudioTrack>
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private AudioSource audioSource;

        [Space]

        [SerializeField, Label("Name")]

        private string trackName = string.Empty;

        [Space]

        [SerializeField]

        private bool playOnAwake = true;

        [SerializeField]

        private AudioTrackPlayMode playMode = AudioTrackPlayMode.RepeatOne;

        public AudioTrackPlayMode PlayMode { set => playMode = value; }

        [Space]

        [SerializeField, ToggledField("isPlayModeShuffle", true)]

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

        private void OnValidate()
        {
            isPlayModeShuffle = playMode == AudioTrackPlayMode.Shuffle;
        }

#endif

        protected override void Awake()
        {
            if (Instance != null && Instance.trackName != trackName)
            {
                Destroy(Instance.gameObject);

                Instance = null;
            }

            base.Awake();
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
                case AudioTrackPlayMode.RepeatAll:

                    ++playlistIndex;

                    if (playlistIndex > playlist.value.Length - 1)
                    {
                        playlistIndex = 0;
                    }

                    break;

                case AudioTrackPlayMode.Reverse:

                    --playlistIndex;

                    if (playlistIndex < 0)
                    {
                        playlistIndex = playlist.value.Length - 1;
                    }

                    break;

                case AudioTrackPlayMode.Shuffle:

                    playlistIndex = Random.Range(0, playlist.value.Length);

                    break;
            }

            audioSource.clip = playlist.value[playlistIndex];

            audioSource.Play();
        }

        public enum AudioTrackPlayMode
        {
            RepeatOne,

            RepeatAll,

            Reverse,

            Shuffle,
        }
    }
}