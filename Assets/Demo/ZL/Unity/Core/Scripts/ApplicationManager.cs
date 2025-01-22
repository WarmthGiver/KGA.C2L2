using UnityEngine;

using ZL.Unity.IO;

namespace ZL.Unity
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public class ApplicationManager : MonoBehaviour
    {
        public static ApplicationManager Instance { get; private set; }

        [Space]

        [SerializeField]

        private bool runInBackground = false;

        [SerializeField]

        private bool cursorVisible = true;

        [Space]

        [SerializeField]

        private Texture2D cursorTexture = null;

        [SerializeField]

        private Vector2 cursorHotspot = Vector2.zero;

        [SerializeField]

        private CursorMode cursorMode = CursorMode.Auto;

        [Space]

        [SerializeField]

        [Button(nameof(LoadTargetFrameRate), "Load")]

        [Button(nameof(SaveTargetFrameRate), "Save")]

        private IntPref targetFrameRate = new("Target Frame Rate", 60);

        private void OnValidate()
        {
            Application.runInBackground = runInBackground;

            Cursor.visible = cursorVisible;
        }

        private void Awake()
        {
            Instance = this;

            DontDestroyOnLoad(Instance);

            Application.runInBackground = runInBackground;

            Cursor.visible = cursorVisible;

            if (cursorTexture != null)
            {
                Cursor.SetCursor(cursorTexture, cursorHotspot, cursorMode);
            }

            targetFrameRate.TryLoad();

            Application.targetFrameRate = targetFrameRate.Value;
        }

        public void LoadTargetFrameRate()
        {
            targetFrameRate.TryLoad();

            Application.targetFrameRate = targetFrameRate.Value;
        }

        public void SaveTargetFrameRate()
        {
            targetFrameRate.SaveValue();
        }

        public int GetTargetFrameRate()
        {
            return targetFrameRate.Value;
        }

        public void SetTargetFrameRate(int value)
        {
            targetFrameRate.Value = value;

            Application.targetFrameRate = value;
        }
    }
}