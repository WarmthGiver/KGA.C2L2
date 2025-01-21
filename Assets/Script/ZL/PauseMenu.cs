using UnityEngine;

using ZL.Unity.UI;

namespace ZL.Unity.ArmadaInvencible
{
    [AddComponentMenu("ZL/UI/Pause Menu")]

    public class PausesMenu : UIMenu
    {
        public override void Enable()
        {
            SceneDirector.Instance.Pause();

            base.Enable();
        }

        public void Resume()
        {
            SceneDirector.Instance.Resume();

            Disable();
        }
    }
}