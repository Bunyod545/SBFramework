using SB.Common.Helpers;
using System.Linq;

namespace SB.Common.Logics.PhoneNumbers
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PhoneNumberParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static PhoneNumber Parse(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return null;

            var phoneNumber = new PhoneNumber();
            phoneNumber.UserEnteredPhone = phone;

            var cleandPhone = CleanNumber(phone);
            phoneNumber.IsCorrect = IsCorrect(cleandPhone);

            if (!phoneNumber.IsCorrect)
                return phoneNumber;

            phoneNumber.IsHasPlus = phone.StartsWith(Strings.Plus);
            phoneNumber.CountryCode = GetCountryCode(cleandPhone);
            phoneNumber.OperatorCode = GetOperatorCode(cleandPhone);
            phoneNumber.Number = GetNumber(cleandPhone);
            phoneNumber.NumberFirstPart = GetNumberFirstPart(phoneNumber.Number);
            phoneNumber.NumberSecondPart = GetNumberSecondPart(phoneNumber.Number);
            phoneNumber.NumberThirdPart = GetNumberThirdPart(phoneNumber.Number);

            return phoneNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        private static string CleanNumber(string phone)
        {
            return phone.Replace(Strings.WhiteSpace, string.Empty)
                .Replace(Strings.Minus, string.Empty)
                .Replace(Strings.LBracket, string.Empty)
                .Replace(Strings.RBracket, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        private static bool IsCorrect(string phone)
        {
            if (phone.Length == FullPhoneLenght && !phone.StartsWith(Strings.Plus))
                return false;

            var numbers = phone;
            if (phone.Length == FullPhoneLenght)
                numbers = numbers.Substring(PlusLength);

            if (numbers.Any(a => !char.IsDigit(a)))
                return false;

            return phone.Length == FullPhoneLenght ||
                   phone.Length == WithoutPlusLenght ||
                   phone.Length == WithoutCountryCodeLenght;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        private static string GetCountryCode(string phone)
        {
            if (phone.Length == FullPhoneLenght)
                return phone.Substring(PlusLength, CountryCodeLength);

            if (phone.Length == WithoutPlusLenght)
                return phone.Substring(0, CountryCodeLength);

            return DefaultCountryCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        private static string GetOperatorCode(string phone)
        {
            if (phone.Length == FullPhoneLenght)
                return phone.Substring(PlusLength + CountryCodeLength, OperatorCodeLength);

            if (phone.Length == WithoutPlusLenght)
                return phone.Substring(CountryCodeLength, OperatorCodeLength);

            if (phone.Length == WithoutCountryCodeLenght)
                return phone.Substring(0, OperatorCodeLength);

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        private static string GetNumber(string phone)
        {
            if (phone.Length == FullPhoneLenght)
                return phone.Substring(PlusLength + CountryCodeLength + OperatorCodeLength, NumberLength);

            if (phone.Length == WithoutPlusLenght)
                return phone.Substring(CountryCodeLength + OperatorCodeLength, NumberLength);

            if (phone.Length == WithoutCountryCodeLenght)
                return phone.Substring(OperatorCodeLength, NumberLength);

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string GetNumberFirstPart(string number)
        {
            return number.Substring(0, NumberFirstPartLenght);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string GetNumberSecondPart(string number)
        {
            return number.Substring(NumberFirstPartLenght, NumberSecondPartLenght);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string GetNumberThirdPart(string number)
        {
            return number.Substring(NumberFirstPartLenght + NumberSecondPartLenght, NumberThirdPartLenght);
        }
    }
}
