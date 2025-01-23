using ArmadaInvencible;

using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField]

    private int playerHP;

    private void Start()
    {
        playerHP = 70;
    }

    public void GetDamage(int damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            Debug.Log("GameOver");
        }
    }
    private void Update()
    {
        Debug.Log(playerHP);
    }
}