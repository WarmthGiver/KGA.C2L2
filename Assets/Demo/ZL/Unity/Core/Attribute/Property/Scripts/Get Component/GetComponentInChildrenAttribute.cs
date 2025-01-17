namespace ZL.Unity
{
    public sealed class GetComponentInChildrenAttribute : GetComponentAttribute
    {
#if UNITY_EDITOR

        protected override void GetComponent(Drawer drawer)
        {
            drawer.TargetComponent.TryGetComponentInChildren(drawer.fieldInfo.FieldType, out var component);

            drawer.Property.objectReferenceValue = component;
        }

#endif
    }
}