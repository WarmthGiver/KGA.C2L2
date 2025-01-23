using UnityEngine;

namespace ZL.Unity
{
    public sealed class EmptyAttribute : LineAttribute
    {
        public EmptyAttribute(float height = 8f) : base(height, Color.clear) { }
    }
}