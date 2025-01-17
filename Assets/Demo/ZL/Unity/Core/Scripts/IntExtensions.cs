using UnityEngine;

namespace ZL.Unity
{
    public static partial class IntExtensions
    {
        public static int Repeat(this int instance, int length)
        {
            return Clamp(instance - Mathf.FloorToInt((float)instance / length) * length, 0, length);
        }

        public static int Clamp01(this int instance)
        {
            return Clamp(instance, 0, 1);
        }

        public static int Clamp(this int instance, int min, int max)
        {
            return Mathf.Clamp(instance, min, max);
        }

        public static bool IsOutOfRange(this int instance, int max)
        {
            return IsOutOfRange(instance, 0, max);
        }

        public static bool IsOutOfRange(this int instance, int min, int max)
        {
            return min > instance || instance > max;
        }
    }
}