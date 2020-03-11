using SB.Common.Logics.SynonymProviders;

namespace SB.Common.Test.Logics.SynonymProviders.TestHelpers
{
    /// <summary>
    /// 
    /// </summary>
    [TypeSynonym]
    public class TestType
    {
        /// <summary>
        /// Entered login or password incorrect
        /// </summary>
        /// <uz>Foydalanuvchi nomi yoki parol noto'g'ri</uz>
        /// <ru>Неверный логин или пароль</ru>
        /// <en>Login or password incorrect</en>
        public string LoginOrPasswordIncorrect { get; set; }

        /// <summary>
        /// Incorrect data entered
        /// </summary>
        /// <uz>Noto'g'ri ma'lumotlar kiritildi</uz>
        /// <ru>Введен неправильный данные</ru>
        /// <en>Incorrect data entered</en>
        public string IncorrectData { get; set; }

        /// <summary>
        /// Incorrect amount data entered
        /// </summary>
        public string IncorrectAmountData { get; set; }
    }
}
