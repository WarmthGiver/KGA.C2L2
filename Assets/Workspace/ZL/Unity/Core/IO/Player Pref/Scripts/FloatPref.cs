using System;

namespace ZL.Unity.IO
{
    [Serializable]

    public sealed class FloatPref : PlayerPref<float>
    {
        public FloatPref(string key, float value) : base(key, value) { }

        public override void LoadValue()
        {
            Value = GetFloat(key);
        }

        public override void SaveValue()
        {
            SetFloat(key, value);
        }
    }
}