using System;
using System.IO;

namespace FixMusic
{
    public static class FileInfoExtensions
    {
        public static bool Compare(this FileSystemInfo instance, FileSystemInfo comparison)
        {
            if (comparison is null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            string left = Path.GetFullPath(instance.FullName);
            string right = Path.GetFullPath(comparison.FullName);

            // Is case-insensitive?
            StringComparison stringComparison = File.Exists(instance.FullName.ToLower()) && File.Exists(instance.FullName.ToUpper())
                ? StringComparison.CurrentCultureIgnoreCase
                : StringComparison.CurrentCulture;

            return string.Compare(left, right, stringComparison) == 0;
        }

        public static string GetExtension(this FileInfo instance) => Path.GetExtension(instance.FullName);
    }
}
