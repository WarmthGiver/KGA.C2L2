using UnityEngine;

namespace ZL.Unity
{
    public sealed class PreviewAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.IsFieldTypeIn(typeof(Object)) == false)
            {
                drawer.DrawHelpBox(MessageType.Error, $"{NameTag} Field type is invalid.");

                return false;
            }

            drawer.DrawPreview();

            return true;
        }

#endif
    }
}