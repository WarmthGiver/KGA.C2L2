using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int playerHP;

    void Start()
    {
        playerHP = 40;
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
