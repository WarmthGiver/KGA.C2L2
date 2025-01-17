using System.Linq;

using System.Text;

namespace ZL.Unity.ObjectPooling
{
    public static class PooledStringBuilder
    {
        public static string Concat(params char[] values)
        {
            var stringBuilder = ClassPool<StringBuilder>.Generate();

            stringBuilder.Capacity = values.Length;

            foreach (var value in values)
            {
                stringBuilder.Append(value);
            }

            var @string = stringBuilder.ToString();

            ClassPool<StringBuilder>.Collect(stringBuilder.Clear());

            return @string;
        }

        public static string Concat(params string[] values)
        {
            var stringBuilder = ClassPool<StringBuilder>.Generate();

            stringBuilder.Capacity = values.Sum(value => value.Length);

            foreach (var value in values)
            {
                stringBuilder.Append(value);
            }

            var @string = stringBuilder.ToString();

            ClassPool<StringBuilder>.Collect(stringBuilder.Clear());

            return @string;
        }
    }
}