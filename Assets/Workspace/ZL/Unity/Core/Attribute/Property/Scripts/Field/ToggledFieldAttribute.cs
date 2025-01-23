namespace ZL.Unity
{
    public sealed class ToggledFieldAttribute : UnitedPropertyAttribute
    {
        private readonly string fieldName;

        private readonly bool targetValue;

        public ToggledFieldAttribute(string fieldName, bool targetValue = true) : base()
        {
            this.fieldName = fieldName;

            this.targetValue = targetValue;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            if (drawer.TryFindProperty(fieldName, SerializedPropertyType.Boolean, out var property) == false)
            {
                drawer.DrawHelpBox(MessageType.Error, $"{NameTag} Property type is mismatch.");

                return false;
            }

            drawer.Current.IsToggled = property.boolValue == targetValue;

            return true;
        }

#endif
    }
}