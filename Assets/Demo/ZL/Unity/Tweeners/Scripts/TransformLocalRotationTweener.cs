using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Local Rotation Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformLocalRotationTweener : ComponentTweener<QuaternionTweener, Quaternion, Vector3, QuaternionOptions>
    {
        private void Awake()
        {
            Tweener = new(() => transform.localRotation, value => transform.localRotation = value);
        }
    }
}