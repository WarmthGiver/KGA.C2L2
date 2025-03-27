using UnityEngine;

namespace ArmadaInvencible.J0
{
    public class BulletActive : Bullet
    {
        protected override void BulletMovement()
        {
            bulletRigid.AddForce(transform.up.normalized * speed * Time.timeScale, ForceMode2D.Force);
        }
    }
}