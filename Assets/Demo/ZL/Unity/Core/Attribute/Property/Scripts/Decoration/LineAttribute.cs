using System;

using UnityEngine;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]

    public class LineAttribute : UnitedPropertyAttribute
    {
        private readonly float height;

        public readonly Color? color;

        public LineAttribute(int r, int g, int b, int a) : this(1f, new Color(r, g, b, a)) { }

        public LineAttribute(float height = 1f) : this(height, null) { }

        public LineAttribute(float height, int r, int g, int b, int a) : this(height, new Color(r, g, b, a)) { }

        protected LineAttribute(float height, Color? color)
        {
            this.height = height;

            this.color = color;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawLine(height, color);

            return true;
        }

#endif
    }
}