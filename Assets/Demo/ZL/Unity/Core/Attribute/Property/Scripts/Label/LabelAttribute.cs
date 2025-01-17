namespace ZL.Unity
{
    public sealed class LabelAttribute : UnitedPropertyAttribute
    {
        private readonly string text;

        private readonly string tooltip;

        public LabelAttribute(string text, string tooltip = null)
        {
            this.text = text;

            this.tooltip = tooltip;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Current.PropertyText = text;

            if (tooltip != null)
            {
                drawer.Current.PropertyTooltip = tooltip;
            }

            return true;
        }

#endif
    }
}