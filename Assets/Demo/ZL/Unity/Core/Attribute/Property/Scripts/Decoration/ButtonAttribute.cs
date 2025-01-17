using System;

using Unity.VisualScripting;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    public sealed class ButtonAttribute : UnitedPropertyAttribute
    {
        private readonly float height;

        private readonly string methodName;

        private readonly string text;

        public ButtonAttribute(string methodName, string text = null) : this(singleLineHeight, methodName, text) { }

        public ButtonAttribute(float height, string methodName, string text = null) : base()
        {
            this.height = height;

            this.methodName = methodName;

            text ??= methodName.SplitWords(' ');

            this.text = text;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawButton(height, methodName, text);

            return true;
        }

#endif
    }
}