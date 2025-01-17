namespace ZL.Unity
{
    public sealed class GetComponentInParentOnlyAttribute : GetComponentAttribute
    {
#if UNITY_EDITOR

        protected override void GetComponent(Drawer drawer)
        {
            drawer.TargetComponent.TryGetComponentInParentOnly(drawer.fieldInfo.FieldType, out var component);

            drawer.Property.objectReferenceValue = component;
        }

#endif
    }
}