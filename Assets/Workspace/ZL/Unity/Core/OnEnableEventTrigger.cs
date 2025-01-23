using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/On Enable Event Trigger")]

    [DisallowMultipleComponent]

    public sealed class OnEnableEventTrigger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private UnityEvent onEnableEvent;

        private void OnEnable()
        {
            onEnableEvent.Invoke();
        }
    }
}