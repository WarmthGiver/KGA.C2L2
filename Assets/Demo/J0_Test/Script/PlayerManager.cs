using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int playerDamage;

    void Start()
    {
        playerDamage = 40;
    }

    public void GetDamage(int damage)
    {
        playerDamage -= damage;

        if (playerDamage <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
