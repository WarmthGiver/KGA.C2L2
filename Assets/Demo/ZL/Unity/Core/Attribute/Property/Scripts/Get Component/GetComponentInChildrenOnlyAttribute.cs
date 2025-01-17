namespace ZL.Unity
{
    public sealed class GetComponentInChildrenOnlyAttribute : GetComponentAttribute
    {
#if UNITY_EDITOR

        protected override void GetComponent(Drawer drawer)
        {
            drawer.TargetComponent.TryGetComponentInChildrenOnly(drawer.fieldInfo.FieldType, out var component);

            drawer.Property.objectReferenceValue = component;
        }

#endif
    }
}