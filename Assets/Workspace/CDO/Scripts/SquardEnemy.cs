/* 
 * �ۼ���: �ֵ���
 * ���� ��¥: 25/01/14
 * ���� �� �߰� ����: ������ �������� �ı��Ǹ� ���������
 */

using UnityEngine;

namespace ArmadaInvencible.CDO
{
    public class SquardEnemy : MonoBehaviour
    {
        //enemy������
        [SerializeField]
        
        private GameObject prefab1;

        [SerializeField]
        
        private GameObject prefab2;

        [SerializeField]
        
        private GameObject prefab3;

        private void Update()
        {
            //������ �� �ı��Ǹ� ������Ʈ �ı�
            if (prefab1 == null && prefab2 == null && prefab3 == null)
            {
                Destroy(gameObject);
            }
        }
    }
}