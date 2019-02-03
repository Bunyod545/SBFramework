using NUnit.Framework;
using SB.Common.Logics.PhoneNumbers;

namespace SB.Common.Test.Logics.PhoneNumbers
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneNumberTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void PhoneParseTest()
        {
            var phone = PhoneNumber.Parse(null);
            Assert.IsNull(phone);

            phone = PhoneNumber.Parse(string.Empty);
            Assert.IsNull(phone);

            phone = PhoneNumber.Parse("97 777-77-77");
            Assert.IsTrue(phone.IsCorrect);

            phone = PhoneNumber.Parse("977777777");
            Assert.IsTrue(phone.IsCorrect);

            phone = PhoneNumber.Parse("(97) 777 77 77");
            Assert.IsTrue(phone.IsCorrect);

            phone = PhoneNumber.Parse("(97)777 77 77");
            Assert.IsTrue(phone.IsCorrect);

            phone = PhoneNumber.Parse("99897 777 77 77");
            Assert.IsTrue(phone.IsCorrect);

            phone = PhoneNumber.Parse("+99897 777 77 77");
            Assert.IsTrue(phone.IsCorrect);

            phone = PhoneNumber.Parse("+99897 777-77-77");
            Assert.IsTrue(phone.IsCorrect);
        }
    }
}
