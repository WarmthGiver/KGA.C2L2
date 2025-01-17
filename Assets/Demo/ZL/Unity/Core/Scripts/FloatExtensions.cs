using System;

namespace ZL.Unity
{
    public static partial class FloatExtensions
    {
        public static float Round(this float instance, int digits)
        {
            return (float)Math.Round(instance, digits);
        }

        public static int RoundRandom(this float instance)
        {
            int integerPart = (int)instance;

            float decimalPart = instance - integerPart;

            if (decimalPart > 0f)
            {
                integerPart += UnityEngine.Random.Range(0f, 1f) < decimalPart ? 1 : 0;
            }

            return integerPart;
        }
    }
}