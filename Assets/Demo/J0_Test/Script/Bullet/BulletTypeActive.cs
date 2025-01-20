using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTypeActive : Bullet
{
    protected override void BulletMovement()
    {
        bulletRigid.AddForce(transform.up.normalized * speed, ForceMode2D.Force);
    }
}
