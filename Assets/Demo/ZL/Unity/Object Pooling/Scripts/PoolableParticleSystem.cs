using UnityEngine;

namespace ZL.Unity.ObjectPooling
{
    [AddComponentMenu("ZL/Object Pooling/Particle System (Poolable)")]

    [RequireComponent(typeof(ParticleSystem))]

    public sealed class PoolableParticleSystem : PoolablePlayable<ParticleSystem>
    {
        public override bool IsPlaying => @base.isPlaying;
    }
}