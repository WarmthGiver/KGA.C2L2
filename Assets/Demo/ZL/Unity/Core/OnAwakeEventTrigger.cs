using UnityEngine;

using UnityEngine.Events;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/On Awake Event Trigger")]

    [DisallowMultipleComponent]

    public sealed class OnAwakeEventTrigger : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private UnityEvent onAwakeEvent;

        private void Awake()
        {
            Debug.Log(1);

            onAwakeEvent.Invoke();
        }
    }
}