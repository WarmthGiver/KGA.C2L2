namespace ZL.Unity
{
    public class IndentAttribute : UnitedPropertyAttribute
    {
        protected readonly int level;

        public IndentAttribute(int level = 1)
        {
            this.level = level;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Current.IndentLevel = level;

            return true;
        }

#endif
    }
}