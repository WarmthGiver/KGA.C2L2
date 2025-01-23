using System.Collections;

using UnityEngine;

namespace ArmadaInvencible.J0
{
    public class WeaponManager : MonoBehaviour
    {
        public static WeaponManager Instance { get; private set; }

        [SerializeField]

        private Transform[] slots = new Transform[5];

        [SerializeField]

        // EquipWeapon 함수 확인용
        private Weapon[] weapons = new Weapon[5];

        private float equipTime;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            equipTime = 30f;

            StartCoroutine(EquipWeapon(weapons));
        }

        private IEnumerator EquipWeapon(Weapon[] weapon)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(weapon[i], slots[i], false);

                yield return new WaitForSeconds(equipTime);
            }
        }
    }
}