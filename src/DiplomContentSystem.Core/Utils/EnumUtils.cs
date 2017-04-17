using System.Linq;

namespace DiplomContentSystem.Core
{
    public static class EnumUtils
    {
        public static bool Is<T>(this T t, T val) where T : class, IEnumEntity
        {
            if (t == null && val == null)
            {
                return true;
            }
            if (t == null || val == null)
            {
                return false;
            }
            return t.Id == val.Id;
        }

        public static bool In<T>(this T t, params T[] values) where T : class, IEnumEntity
        {
            return values.Any(val => t.Is(val));
        }
    }
}
