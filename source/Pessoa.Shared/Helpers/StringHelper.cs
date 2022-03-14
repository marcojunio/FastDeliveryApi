using System;
using System.Linq;

namespace Pessoa.Shared.Helpers
{
    public class StringHelper
    {
        public static string MakeAlphaNumeric(string value, params char[] exceptions)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }

            var charArray = value.ToCharArray();
            var alphaNumeric = Array.FindAll(charArray,
                (c => char.IsLetterOrDigit(c) || exceptions?.Contains(c) == true));

            return new string(alphaNumeric);
        }
    }
}
