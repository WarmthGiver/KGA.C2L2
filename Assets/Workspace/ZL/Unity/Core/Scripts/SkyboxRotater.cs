using UnityEngine;

namespace ZL.Unity
{
    [AddComponentMenu("ZL/Skybox Rotater")]

    [DisallowMultipleComponent]

    public sealed class SkyboxRotater : MonoBehaviour
    {
        [Space]

        [SerializeField]

        private Material skybox;

        [SerializeField]

        private float speed = 0f;

        private float rotation;

        private void Awake()
        {
            rotation = skybox.GetFloat("_Rotation");
        }

        private void Update()
        {
            rotation += speed * Time.deltaTime;

            skybox.SetFloat("_Rotation", rotation);
        }

        private void OnApplicationQuit()
        {
            skybox.SetFloat("_Rotation", 0f);
        }
    }
}