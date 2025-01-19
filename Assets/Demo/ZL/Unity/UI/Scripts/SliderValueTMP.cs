using TMPro;

using UnityEngine;

using UnityEngine.UI;

namespace ZL.Unity.UI
{
    [AddComponentMenu("ZL/UI/Slider Value (TMP)")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(TextMeshProUGUI))]

    public sealed class SliderValueTMP : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private TextMeshProUGUI textMeshPro;

        [Space]

        [SerializeField, Essential]

        private Slider slider = null;

        public void OnValueChanged()
        {
            textMeshPro.text = slider.value.ToString();
        }
    }
}