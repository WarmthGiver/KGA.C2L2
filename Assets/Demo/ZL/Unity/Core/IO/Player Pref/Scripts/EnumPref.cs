using System;

namespace ZL.Unity.IO
{
    [Serializable]

    public sealed class EnumPref<TEnum> : PlayerPref<TEnum>

        where TEnum : Enum
    {
        public EnumPref(string key, TEnum value) : base(key, value) { }

        public override void LoadValue()
        {
            Value = GetInt(key).ToEnum<TEnum>();
        }

        public override void SaveValue()
        {
            SetInt(key, value.ToInt());
        }
    }
}