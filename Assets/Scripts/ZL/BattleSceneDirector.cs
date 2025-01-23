using DG.Tweening;

using UnityEngine;

using ZL.Unity.Tweeners;

namespace ZL.Unity.ArmadaInvencible
{
    [AddComponentMenu("")]

    public sealed class BattleSceneDirector : SceneDirector
    {
        [Space]

        [SerializeField]

        private TransformScaleTweener missionCompleteScreen;

        [SerializeField]

        private TransformScaleTweener youDiedScreen;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                EndScene(true);
            }

            if (Input.GetKeyUp(KeyCode.X))
            {
                EndScene(false);
            }
        }

        public void EndScene(bool isPlayerAlive)
        {
            var screen = isPlayerAlive ? missionCompleteScreen : youDiedScreen;

            screen.SetActive(true);

            screen.Tweener.Tween(new Vector3(2f, 2f, 1f), 2f).
                
                OnComplete(() => LoadScene("Title Scene"));
        }
    }
}