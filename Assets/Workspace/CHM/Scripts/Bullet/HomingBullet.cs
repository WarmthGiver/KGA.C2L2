/* 작성자 : 최현민
 * 날짜 25 - 1 - 20
 * 유도총알
*/

using UnityEngine;

namespace ArmadaInvencible.CHM
{
    public class HomingBullet : Bulletbase
    {
        //유도 미사일
        private GameObject target;

        //Setup 메서드 재정의
        public override void Setup(string v, GameObject target, int maxCount = 10, int index = 0)
        {
            base.Setup("HomingBullet",target);

            //타겟정보를 받아옴 
            this.target = target;
        }

        public override void Process()
        {
            movementRigidbody2D.MoveTo((target.transform.position - transform.position).normalized);

            transform.rotation = Utils.LookTaget(transform.position, target.transform.position);
        }
    }
}