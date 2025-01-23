using UnityEngine;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Menu Manager")]

    [DisallowMultipleComponent]

    public class UIMenuManager : MonoBehaviour
    {
        [Space]

        [SerializeField, Essential]

        protected UIMenu mainMenu;

        public UIMenu Current { get; set; } = null;

        public virtual void EnableMainMenu()
        {
            mainMenu.Enable();
        }

        public virtual void DisableCurrent()
        {
            Current.Disable();
        }
    }
}