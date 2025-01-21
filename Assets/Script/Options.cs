using UnityEngine;

using ZL.Unity.Audio;

using ZL.Unity.UI;

namespace KGA.C2L2
{
    [AddComponentMenu("")]

    public sealed class Options : ManagedCanvasGroup
    {
        [Space]

        [SerializeField]

        private AudioMixerVolumeSlider masterVolumeSlider;

        [SerializeField]

        private AudioMixerVolumeSlider bgmVolumeSlider;

        [SerializeField]

        private AudioMixerVolumeSlider sfxVolumeSlider;

        public override void Enable()
        {
            Load();

            base.Enable();

            fader.ActionOnFaded += Load;
        }

        public void Load()
        {
            AudioMixerManager.Instance.LoadVolumes();

            masterVolumeSlider.Refresh();

            bgmVolumeSlider.Refresh();

            sfxVolumeSlider.Refresh();
        }

        public void Save()
        {
            AudioMixerManager.Instance.SaveVolumes();
        }
    }
}