using UnityEngine;

using UnityEngine.Audio;

#if UNITY_EDITOR

using UnityEditor;

#endif

using ZL.Unity.Collections;

using ZL.Unity.IO;

namespace ZL.Unity.Audio
{
    [AddComponentMenu("ZL/Audio/Audio Mixer Manager (Singleton)")]

    [DisallowMultipleComponent]

    public sealed class AudioMixerManager : Singleton<AudioMixerManager>
    {
        [Space]

        [SerializeField, Essential]

        [Button(nameof(LoadAudioMixerParameters), "Load Parameters")]

        private AudioMixer audioMixer = null;

        [SerializeField]

        [Button(nameof(LoadVolumes))]

        [Button(nameof(SaveVolumes))]

        private SerializableDictionary<string, float, FloatPref> parameters;

        private void Reset()
        {
            LoadAudioMixerParameters();
        }

        private void OnValidate()
        {
            foreach (var parameter in parameters)
            {
                parameter.Value = Mathf.Clamp01(parameter.Value);

                if (Application.isPlaying == true)
                {
                    SetVolume(parameter.Key, parameter.Value);
                }
            }
        }

#if UNITY_EDITOR

        public void LoadAudioMixerParameters()
        {
            parameters.Clear();

            if (audioMixer != null)
            {
                foreach (var audioMixerGroup in audioMixer.FindMatchingGroups(string.Empty))
                {
                    var key = audioMixerGroup.name;

                    audioMixer.GetFloat(key, out float value);

                    FloatPref volumePref = new(key, value);

                    volumePref.TryLoadValue();

                    parameters.Add(volumePref);
                }
            }

            EditorUtility.SetDirty(this);
        }

#endif

        private void Start()
        {
            LoadVolumes();
        }

        public void LoadVolumes()
        {
            foreach (var parameter in parameters)
            {
                parameter.TryLoadValue();

                audioMixer.SetVolume(parameter.Key, parameter.Value);
            }
        }

        public void SaveVolumes()
        {
            foreach (var parameter in parameters)
            {
                parameter.SaveValue();
            }
        }

        public float GetVolume(string key)
        {
            return parameters[key];
        }

        public void SetVolume(string key, float value)
        {
            parameters[key] = value;

            audioMixer.SetVolume(key, value);
        }
    }
}