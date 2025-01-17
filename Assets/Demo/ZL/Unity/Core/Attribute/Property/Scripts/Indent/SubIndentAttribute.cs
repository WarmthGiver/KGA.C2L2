using System;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    public sealed class SubIndentAttribute : IndentAttribute
    {
        public SubIndentAttribute(int level = 1) : base(level) { }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Current.SubIndentLevel = level;

            return true;
        }

#endif
    }
}