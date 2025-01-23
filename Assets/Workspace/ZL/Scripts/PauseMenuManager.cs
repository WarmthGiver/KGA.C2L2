/*
 * 작성자: 이시온
*/

using UnityEngine;

using ZL.Unity.UI;

namespace ArmadaInvencible.ZL
{
    [AddComponentMenu("")]

    public sealed class PauseMenuManager : UIMenuManager
    {
        private bool isPaused = false;

        private void Update()
        {
            if (isPaused == false && Input.GetKeyDown(KeyCode.Escape) == true)
            {
                EnableMainMenu();
            }
        }

        public override void EnableMainMenu()
        {
            isPaused = true;

            SceneDirector.Instance.Pause();

            base.EnableMainMenu();
        }

        public override void DisableCurrent()
        {
            isPaused = false;

            SceneDirector.Instance.Resume();

            base.DisableCurrent();
        }
    }
}