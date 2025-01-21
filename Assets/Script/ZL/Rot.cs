using System.Collections;

using System.Collections.Generic;

using UnityEngine;

namespace KGA
{
    public sealed class Rot : MonoBehaviour
    {
        private void FixedUpdate()
        {
            transform.Rotate(0, 0, 1f);
        }
    }
}