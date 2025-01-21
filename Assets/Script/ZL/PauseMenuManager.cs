using UnityEngine;

using ZL.Unity.UI;

namespace ZL.Unity.ArmadaInvencible
{
    [AddComponentMenu("")]

    public sealed class PauseMenuManager : UIMenuManager
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainMenu.Enable();
            }
        }
    }
}