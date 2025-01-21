using DG.Tweening.Plugins.Options;

using UnityEngine;

namespace ZL.Unity.Tweeners
{
    [AddComponentMenu("ZL/Tweeners/Transform Scale Tweener")]

    [DisallowMultipleComponent]

    public sealed class TransformScaleTweener : ComponentTweener<Vector3Tweener, Vector3, Vector3, VectorOptions>
    {
        private void Awake()
        {
            Tweener = new(() => transform.localScale, value => transform.localScale = value);
        }
    }
}