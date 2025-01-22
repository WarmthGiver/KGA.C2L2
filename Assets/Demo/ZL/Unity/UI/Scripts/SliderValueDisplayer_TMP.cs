using TMPro;

using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Slider Value Displayer (TMP)")]

    [DisallowMultipleComponent]

    public sealed class SliderValueDisplayer_TMP : MonoBehaviour
    {
        [Space]

        [SerializeField, Essential]

        private Slider slider;

        [SerializeField, Essential]

        private TextMeshProUGUI text;

        public void Refresh()
        {
            text.text = slider.value.ToString();
        }
    }
}