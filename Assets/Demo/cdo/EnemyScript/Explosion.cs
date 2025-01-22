using UnityEngine;

namespace CHO
{
    public class Explosion : MonoBehaviour
    {
        private float coolTime2;

        private void Update()
        {
            ExplosionTimeDelay();
        }

        private void ExplosionTimeDelay()
        {
            coolTime2 += Time.deltaTime;

            if (coolTime2 > 1f)
            {
                Destroy(gameObject);

                coolTime2 = 0;
            }
        }
    }
}