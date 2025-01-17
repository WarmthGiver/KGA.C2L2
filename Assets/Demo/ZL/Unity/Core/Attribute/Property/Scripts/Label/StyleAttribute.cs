using UnityEngine;

namespace ZL.Unity
{
    public sealed class StyleAttribute : UnitedPropertyAttribute
    {
        private readonly int? fontSize;

        private readonly FontStyle? fontStyle;

        private readonly Color? textColor;

        public StyleAttribute(int r, int g, int b, int a) : this(null, null, new(r, g, b, a)) { }

        public StyleAttribute(FontStyle fontStyle) : this(null, fontStyle, null) { }

        public StyleAttribute(FontStyle fontStyle, int r, int g, int b, int a) : this(null, fontStyle, new(r, g, b, a)) { }

        public StyleAttribute(int fontSize) : this(fontSize, null, null) { }

        public StyleAttribute(int fontSize, int r, int g, int b, int a) : this(fontSize, null, new(r, g, b, a)) { }

        public StyleAttribute(int fontSize, FontStyle fontStyle) : this(fontSize, fontStyle, null) { }

        public StyleAttribute(int fontSize, FontStyle fontStyle, int r, int g, int b, int a) : this(fontSize, fontStyle, new(r, g, b, a)) { }

        private StyleAttribute(int? fontSize, FontStyle? fontStyle, Color? textColor)
        {
            this.fontSize = fontSize;

            this.fontStyle = fontStyle;

            this.textColor = textColor;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.Current.PropertyFontSize = fontSize;

            drawer.Current.PropertyFontStyle = fontStyle;

            drawer.Current.PropertyTextColor = textColor;

            return true;
        }

#endif
    }
}