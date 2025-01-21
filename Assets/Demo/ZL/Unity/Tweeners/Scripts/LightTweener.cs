using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Light Tweener")]

    [DisallowMultipleComponent]

    [RequireComponent(typeof(Light))]

    public sealed class LightTweener : MonoBehaviour
    {
        [Space]

        [SerializeField, GetComponent, ReadOnly]

        private Light _light;

        public FloatTweener IntensityTweener { get; private set; }

        private void Awake()
        {
            IntensityTweener = new(() => _light.intensity, value => _light.intensity = value);
        }
    }
}