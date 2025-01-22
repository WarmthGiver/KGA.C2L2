using UnityEngine;

using ZL.Unity.IO;

namespace ZL.Unity
{
    public sealed class ApplicationManager : MonoBehaviour
    {
        public static ApplicationManager Instance { get; private set; }

        [Space]

        [SerializeField]

        private bool runInBackground = false;

        [Space]

        [SerializeField]

        [Button(nameof(LoadTargetFrameRate), "Load")]

        [Button(nameof(SaveTargetFrameRate), "Save")]

        private IntPref targetFrameRate = new("Target Frame Rate", 60);

        private void OnValidate()
        {
            Application.runInBackground = runInBackground;
        }

        private void Awake()
        {
            Instance = this;

            DontDestroyOnLoad(Instance);

            Application.runInBackground = runInBackground;

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