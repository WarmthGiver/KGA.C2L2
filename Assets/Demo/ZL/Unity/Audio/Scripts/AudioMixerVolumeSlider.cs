using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.Audio
{
    [DisallowMultipleComponent]

    public sealed class AudioMixerVolumeSlider : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponentInChildren, ReadOnly]

        private Slider slider;

        [Space]

        [SerializeField, ReadOnlyInPlayMode]

        private string key;

        public void Refresh()
        {
            slider.value = AudioMixerManager.Instance.GetVolume(key) * 100f;
        }

        public void SetVolume()
        {
            AudioMixerManager.Instance.SetVolume(key, slider.value * 0.01f);
        }
    }
}