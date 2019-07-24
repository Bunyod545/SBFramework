using NUnit.Framework;
using SB.Common.Logics.SynonymProviders;
using SB.Common.Test.Logics.EnumSynonyms.TestHelpers;

namespace SB.Common.Test.Logics.EnumSynonyms
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumSynonymMigrateManagerTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MigrateTest()
        {
            var migrateManager = new EnumSynonymMigrateManager();
            migrateManager.Migrate<TestEnumSynonymMigrator, TestEnumSynonymInfo>();

            var enSynonym = EnumSynonymProvider.Get(TestEnum.LoginOrPasswordIncorrect, CultureHelper.EnLanguage);
            Assert.AreEqual(enSynonym, "Login or password incorrect");

            var ruSynonym = EnumSynonymProvider.Get(TestEnum.LoginOrPasswordIncorrect, CultureHelper.RuLanguage);
            Assert.AreEqual(ruSynonym, "Неверный логин или пароль");

            var uzSynonym = EnumSynonymProvider.Get(TestEnum.LoginOrPasswordIncorrect, CultureHelper.UzLanguage);
            Assert.AreEqual(uzSynonym, "Foydalanuvchi nomi yoki parol noto'g'ri");
        }
    }
}
