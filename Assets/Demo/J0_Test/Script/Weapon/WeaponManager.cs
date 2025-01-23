using System.Collections;

using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField]

    private Transform[] slots = new Transform[5];

    [SerializeField]

    // EquipWeapon 함수 확인용
    private Weapon[] weapons = new Weapon[5];

    private float equipTime;

    private void Start()
    {
        equipTime = 10f;

        StartCoroutine(EquipWeapon(weapons));
    }

    private IEnumerator EquipWeapon(Weapon[] weapon)
    {
        for (int i = 0; i < 5; i++)
        {
            // Debug.Log($"{i + 1}번째 생성");

            Instantiate(weapon[i], slots[i], false);
            
            yield return new WaitForSeconds(equipTime);
        }
    }
}