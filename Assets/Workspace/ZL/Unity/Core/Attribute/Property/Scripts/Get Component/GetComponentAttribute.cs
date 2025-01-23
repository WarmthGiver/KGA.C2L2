using UnityEngine;

namespace ZL.Unity
{
    public class GetComponentAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.IsFieldTypeIn(typeof(Component)) == false)
            {
                drawer.DrawHelpBox(MessageType.Error, $"{NameTag} Field type is invalid.");

                return false;
            }

            GetComponent(drawer);

            return true;
        }

        protected virtual void GetComponent(Drawer drawer)
        {
            drawer.TargetComponent.TryGetComponent(drawer.fieldInfo.FieldType, out var component);

            drawer.Property.objectReferenceValue = component;
        }

#endif
    }
}