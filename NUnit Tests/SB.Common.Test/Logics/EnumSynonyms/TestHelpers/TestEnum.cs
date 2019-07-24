using SB.Common.Logics.SynonymProviders;

namespace SB.Common.Test.Logics.EnumSynonyms.TestHelpers
{
    /// <summary>
    /// 
    /// </summary>
    [EnumSynonym]
    public enum TestEnum
    {
        /// <summary>
        /// Entered login or password incorrect
        /// </summary>
        /// <uz>Foydalanuvchi nomi yoki parol noto'g'ri</uz>
        /// <ru>Неверный логин или пароль</ru>
        /// <en>Login or password incorrect</en>
        LoginOrPasswordIncorrect = -1,

        /// <summary>
        /// Incorrect data entered
        /// </summary>
        /// <uz>Noto'g'ri ma'lumotlar kiritildi</uz>
        /// <ru>Введен неправильный данные</ru>
        /// <en>Incorrect data entered</en>
        IncorrectData = -2,

        /// <summary>
        /// Incorrect amount data entered
        /// </summary>
        IncorrectAmountData = -2,
    }
}
