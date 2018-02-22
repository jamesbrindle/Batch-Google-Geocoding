using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GoogleGeolocation
{
    public class AddressStringHelper
    {
        public static string GetFormattedAddress(string inputString)
        {

            if (inputString[inputString.Length - 1] == ',')
                inputString = inputString.Substring(0, inputString.Length - 1);

            if (inputString[inputString.Length - 1] == ' ')
                inputString = inputString.Substring(0, inputString.Length - 1);

            if (inputString.Contains("(") || inputString.Contains(")"))
                inputString = RemoveTextBetween(inputString, "(", ")", "");

            return inputString;
        }

        public static string RemoveTextBetween(string inputString, string firstChar, string secondChar, string replacementString)
        {
            int start = inputString.IndexOf(firstChar);
            int end = inputString.IndexOf(secondChar);
            string result = inputString.Substring(start, end - start);

            inputString = inputString.Replace(result, replacementString);

            return inputString;
        }

        private static string part1 =
            "([A-PR-UWYZ]" +
            "([0-9]{1,2}|([A-HK-Y][0-9]|[A-HK-Y][0-9]([0-9]|[ABEHMNPRV-Y]))|[0-9][A-HJKS-UW]))";

        private static string part2 = @"[0-9][ABD-HJLNP-UW-Z]{2}";

        public static string GetPostCodeFromAddress(string inputString)
        {
            try
            {
                string fullPostcode = "";

                // post code with a space..............................................................

                fullPostcode = part1 + " " + part2;

                Regex re = new Regex(fullPostcode);  //create regex
                MatchCollection matches = re.Matches(inputString.ToUpper()); //create matches with text

                if (matches.Count == 0)
                {
                    // post code without a space.........................................................

                    fullPostcode = part1 + part2;

                    re = new Regex(fullPostcode);  //create regex
                    matches = re.Matches(inputString.ToUpper()); //create matches with text
                }

                if (matches.Count == 0)
                    return inputString; // as we can't match a postcode
                else
                    return matches[0].Value;
            }
            catch
            {
                return inputString;
            }
        }
    }
}
