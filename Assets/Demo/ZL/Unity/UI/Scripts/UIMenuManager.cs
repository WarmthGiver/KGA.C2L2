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

        private UIMenu current;

        private void Awake()
        {
            current = mainMenu;
        }

        private void OnDisable()
        {
            current.Fader.IsFaded = true;

            current = mainMenu;

            current.Fader.IsFaded = false;
        }

        public UIMenu SetCurrent(UIMenu target)
        {
            var prev = current;

            current = target;

            return prev;
        }
    }
}