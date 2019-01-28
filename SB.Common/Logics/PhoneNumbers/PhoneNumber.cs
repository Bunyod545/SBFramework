using SBCommon.Extensions;
using SBCommon.Helpers;

namespace SB.Common.Logics.PhoneNumbers
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsHasPlus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OperatorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NumberFirstPart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NumberSecondPart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NumberThirdPart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserEnteredPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Strings.Plus}{CountryCode}{OperatorCode}{Number}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToStringWithOutPlus()
        {
            return $"{CountryCode}{OperatorCode}{Number}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string ToShortStringWithDelimiter()
        {
            return $"({OperatorCode}) {NumberFirstPart}-{NumberSecondPart}-{NumberThirdPart}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string ToShortString()
        {
            return $"({OperatorCode}) {Number}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string ToSecurityString()
        {
            return $"{Strings.Plus}{CountryCode}{OperatorCode}***{NumberSecondPart}{NumberThirdPart}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        public static bool operator ==(PhoneNumber numberOne, PhoneNumber numberTwo)
        {
            return numberOne.ToSafeString() == numberTwo.ToSafeString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOne"></param>
        /// <param name="numberTwo"></param>
        /// <returns></returns>
        public static bool operator !=(PhoneNumber numberOne, PhoneNumber numberTwo)
        {
            return !(numberOne == numberTwo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static PhoneNumber Parse(string phone)
        {
            return PhoneNumberParser.Parse(phone);
        }
    }
}
