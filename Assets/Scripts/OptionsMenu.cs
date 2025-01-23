/*
 * 작성자: 이시온
*/

using UnityEngine;

using ZL.Unity;

using ZL.Unity.Audio;

using ZL.Unity.UI;

namespace ArmadaInvencible
{
    [AddComponentMenu("")]

    public sealed class OptionsMenu : UIMenu
    {
        [Space]

        [SerializeField, Essential]

        private AudioMixerVolumeSlider masterVolumeSlider;

        [SerializeField, Essential]

        private AudioMixerVolumeSlider bgmVolumeSlider;

        [SerializeField, Essential]

        private AudioMixerVolumeSlider sfxVolumeSlider;

        public override void Enable()
        {
            Load();

            base.Enable();
        }

        public override void Disable()
        {
            AudioMixerManager.Instance.LoadVolumes();

            base.Disable();
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