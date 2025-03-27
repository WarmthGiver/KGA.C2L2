/*
 * 작성자: 이시온
*/

using DG.Tweening;

using UnityEngine;

using ZL.Unity;

using ZL.Unity.Tweeners;

namespace ArmadaInvencible.ZL
{
    [AddComponentMenu("")]

    public sealed class BattleSceneDirector : SceneDirector
    {
        [Space]

        [SerializeField]

        private TransformScaleTweener missionCompleteScreen;

        [SerializeField]

        private TransformScaleTweener youDiedScreen;

        private bool isSceneEnded;

        public override void EndScene(bool isPlayerAlive)
        {
            if (isSceneEnded == true)
            {
                return;
            }

            isSceneEnded = true;

            var screen = isPlayerAlive ? missionCompleteScreen : youDiedScreen;

            screen.SetActive(true);

            screen.Tweener.Tween(new Vector3(2f, 2f, 1f), 2f).
                
                OnComplete(() => LoadScene("Title Scene"));
        }
    }
}