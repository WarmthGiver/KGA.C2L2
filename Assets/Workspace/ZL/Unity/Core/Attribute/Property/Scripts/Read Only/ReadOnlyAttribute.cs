namespace ZL.Unity
{
    public sealed class ReadOnlyAttribute : UnitedPropertyAttribute
    {
#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Current.IsEnabled = false;

            return true;
        }

#endif
    }
}