using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinanceHub.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        private static string RemoveAccentsAndCedilla(this string value)
        {
            return new string([.. value
             .Normalize(NormalizationForm.FormD)
             .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark && !"´~^¸¨".Contains(ch))]);
        }

        public static string StringNormalization(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            value = value.ToUpper();
            value = value.RemoveAccentsAndCedilla();
            value = value.Trim();

            return value;
        }
    }
}
