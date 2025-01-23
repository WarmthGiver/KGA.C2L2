using ArmadaInvencible;

using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField]

    private int playerHP;

    private bool isPlayerAlive = true;

    private void Start()
    {
        playerHP = 70;
    }

    public void GetDamage(int damage)
    {
        playerHP -= damage;

        if (isPlayerAlive == true && playerHP <= 0)
        {
            isPlayerAlive = false;

            SceneDirector.Instance.EndScene(false);

            var fx = FXPoolManager.Instance.Generate("Explosion 2");

            fx.transform.position = transform.position;
        }
    }
}