using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Rotation Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformRotationTweener : ComponentTweener<QuaternionTweener, Quaternion, Vector3, QuaternionOptions>
    {
        private void Awake()
        {
            ValueTweener = new(() => transform.rotation, value => transform.rotation = value);
        }
    }
}