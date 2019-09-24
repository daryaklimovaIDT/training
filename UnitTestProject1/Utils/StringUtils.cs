using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Utils
{
    public class StringUtils
    {
        private static Random random = new Random();
        const string alphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const string alphabeticalChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        const string numericChars = "0123456789";
        const string specialChars = @"!@#$%^\/&*()-=";

        public static string GenerateAlphabeticalString(int length = 5)
        {
            return GenerateRandomString(alphabeticalChars, length);
        }

        public static string GenerateAlphanumericString(int length = 5)
        {
            return GenerateRandomString(alphanumericChars, length);
        }

        public static string GenerateNumericString(int length = 5)
        {
            return GenerateRandomString(numericChars, length);
        }

        public static string SpecialCharsString(int length = 5)
        {
            return GenerateRandomString(specialChars, length);
        }

        private static string GenerateRandomString(string chars, int length)
        {
            string randomString = "";
            for (int i = 0; i < length; i++)
            {
                int randomInt = random.Next(0, chars.Length);
                char letter = chars[randomInt];
                randomString += letter;
            }

            return randomString;
        }
    }
}
