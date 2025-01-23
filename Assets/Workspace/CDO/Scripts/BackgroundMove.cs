using UnityEngine;

namespace ArmadaInvencible.CDO
{
    public class BackgroundMove : MonoBehaviour
    {
        private void Update()
        {
            var dss = transform.position;

            dss.x += 0.0005f;

            if (transform.position.x >= 29)
            {
                dss.x = -29f;
            }

            transform.position = dss;
        }
    }
}