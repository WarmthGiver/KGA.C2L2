namespace ZL.Unity
{
    public sealed class TagFieldAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.IsPropertyTypeIn(SerializedPropertyType.String) == true)
            {
                drawer.DrawHelpBox(MessageType.Error, $"{NameTag} Property type is mismatch.");

                return false;
            }

            drawer.PropertyFieldType = SerializedPropertyFieldType.Tag;

            return true;
        }

#endif
    }
}