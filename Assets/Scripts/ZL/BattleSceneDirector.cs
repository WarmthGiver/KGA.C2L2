using System.Collections;

using UnityEngine;

namespace ZL.Unity.ArmadaInvencible
{
    [AddComponentMenu("")]

    public sealed class BattleSceneDirector : SceneDirector
    {
        protected override IEnumerator Start()
        {
            yield return base.Start();


        }
    }
}