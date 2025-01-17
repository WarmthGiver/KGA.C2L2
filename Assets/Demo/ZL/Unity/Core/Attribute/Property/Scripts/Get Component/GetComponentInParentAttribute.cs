namespace ZL.Unity
{
    public sealed class GetComponentInParentAttribute : GetComponentAttribute
    {
#if UNITY_EDITOR

        protected override void GetComponent(Drawer drawer)
        {
            drawer.TargetComponent.TryGetComponentInParent(drawer.fieldInfo.FieldType, out var component);

            drawer.Property.objectReferenceValue = component;
        }

#endif
    }
}