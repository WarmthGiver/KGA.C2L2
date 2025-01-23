using System;

using UnityEngine;

namespace ZL.Unity
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]

    public sealed class TextAttribute : UnitedPropertyAttribute
    {
        private readonly int? fontSize;

        private static readonly FontStyle defaultFontStyle = FontStyle.Italic;

        private readonly FontStyle fontStyle;

        private static readonly Color defaultColor = new(0.5f, 0.5f, 0.5f, 1f);

        private readonly Color color;

        private readonly string text;

        public TextAttribute(string text) : this(null, defaultFontStyle, defaultColor, text) { }

        public TextAttribute(byte r, byte g, byte b, byte a, string text) : this(null, defaultFontStyle, new Color32(r, g, b, a), text) { }

        public TextAttribute(float r, float g, float b, float a, string text) : this(null, defaultFontStyle, new Color(r, g, b, a), text) { }

        public TextAttribute(FontStyle fontStyle, string text) : this(null, fontStyle, defaultColor, text) { }

        public TextAttribute(FontStyle fontStyle, byte r, byte g, byte b, byte a, string text) : this(null, fontStyle, new Color32(r, g, b, a), text) { }

        public TextAttribute(FontStyle fontStyle, float r, float g, float b, float a, string text) : this(null, fontStyle, new Color(r, g, b, a), text) { }

        public TextAttribute(int fontSize, string text) : this(fontSize, defaultFontStyle, defaultColor, text) { }

        public TextAttribute(int fontSize, byte r, byte g, byte b, byte a, string text) : this(fontSize, defaultFontStyle, new Color32(r, g, b, a), text) { }

        public TextAttribute(int fontSize, float r, float g, float b, float a, string text) : this(fontSize, defaultFontStyle, new Color(r, g, b, a), text) { }

        public TextAttribute(int fontSize, FontStyle fontStyle, string text) : this(fontSize, fontStyle, defaultColor, text) { }

        public TextAttribute(int fontSize, FontStyle fontStyle, byte r, byte g, byte b, byte a, string text) : this(fontSize, fontStyle, new Color32(r, g, b, a), text) { }

        public TextAttribute(int fontSize, FontStyle fontStyle, float r, float g, float b, float a, string text) : this(fontSize, fontStyle, new Color(r, g, b, a), text) { }

        private TextAttribute(int? fontSize, FontStyle fontStyle, Color color, string text)
        {
            this.fontSize = fontSize;

            this.fontStyle = fontStyle;

            this.color = color;

            this.text = text;
        }

#if UNITY_EDITOR

        public override bool Draw(Drawer drawer)
        {
            drawer.DrawText(fontSize, fontStyle, color, text);

            return true;
        }

#endif
    }
}