using UnityEngine;

namespace ArmadaInvencible.J0
{
    public class BulletActive : Bullet
    {
        [SerializeField]

        private TrailRenderer[] trailRenderers = new TrailRenderer[3];

        protected override void OnDisable()
        {
            for (int i = 0; i < 3; i++)
            {
                trailRenderers[i].Clear();
            }
        }

        protected override void BulletMovement()
        {
            bulletRigid.AddForce(transform.up.normalized * speed * Time.timeScale, ForceMode2D.Force);
        }
    }
}