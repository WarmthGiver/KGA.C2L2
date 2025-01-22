using ArmadaInvencible;

using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField]

    private int playerHP = 100;

    public void GetDamage(int damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}