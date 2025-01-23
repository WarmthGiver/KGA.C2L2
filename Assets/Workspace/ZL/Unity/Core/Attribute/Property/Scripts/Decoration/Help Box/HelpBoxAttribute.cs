using System;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]

    public class HelpBoxAttribute : UnitedPropertyAttribute
    {
        private readonly MessageType type;

        private readonly IconSize iconSize;

        private readonly string message;

        public HelpBoxAttribute(string message) : this(MessageType.None, IconSize.None, message) { }

        public HelpBoxAttribute(IconSize iconSize, string message) : this(MessageType.None, iconSize, message) { }

        public HelpBoxAttribute(MessageType type, string message) : this(type, IconSize.Small, message) { }

        public HelpBoxAttribute(MessageType type, IconSize iconSize, string message) : base()
        {
            this.type = type;

            this.iconSize = iconSize;

            this.message = message;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawHelpBox(type, iconSize, message);

            return true;
        }

#endif
    }
}