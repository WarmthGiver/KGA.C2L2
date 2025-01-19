using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Position Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformPositionTweener : ComponentTweener<Vector3Tweener, Vector3, Vector3, VectorOptions>
    {
        private void Awake()
        {
            ValueTweener = new(() => transform.position, value => transform.position = value);
        }
    }
}