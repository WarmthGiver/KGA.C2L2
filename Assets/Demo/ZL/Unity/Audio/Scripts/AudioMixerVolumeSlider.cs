using UnityEngine;

namespace ZL.Unity.Audio
{
    using UnityEngine.UI;

    [DisallowMultipleComponent]

    [RequireComponent(typeof(Slider))]

    public sealed class AudioMixerVolumeSlider : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private Slider slider;

        [Space]

        [SerializeField, ReadOnlyInPlayMode]

        private string key;

        private void Start()
        {
            Refresh();
        }

        public void Refresh()
        {
            slider.value = AudioMixerManager.Instance.GetVolume(key);
        }

        public void SetVolume()
        {
            AudioMixerManager.Instance.SetVolume(key, slider.value);
        }
    }
}