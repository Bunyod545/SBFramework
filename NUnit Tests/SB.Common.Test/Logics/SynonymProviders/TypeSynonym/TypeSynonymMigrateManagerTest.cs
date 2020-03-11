using System.Reflection;
using NUnit.Framework;
using SB.Common.Logics.SynonymProviders;
using SB.Common.Test.Logics.SynonymProviders.TestHelpers;

namespace SB.Common.Test.Logics.SynonymProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeSynonymMigrateManagerTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MigrateTest()
        {
            var migrateManager = new TypeSynonymMigrateManager();
            migrateManager.Migrate<TestTypeSynonymMigrator, TestTypeSynonymInfo>();

            var enSynonym = SynonymProvider.Get(Property(nameof(TestType.LoginOrPasswordIncorrect)), CultureHelper.EnLanguage);
            Assert.AreEqual(enSynonym, "Login or password incorrect");

            var ruSynonym = SynonymProvider.Get(Property(nameof(TestType.LoginOrPasswordIncorrect)), CultureHelper.RuLanguage);
            Assert.AreEqual(ruSynonym, "Неверный логин или пароль");

            var uzSynonym = SynonymProvider.Get(Property(nameof(TestType.LoginOrPasswordIncorrect)), CultureHelper.UzLanguage);
            Assert.AreEqual(uzSynonym, "Foydalanuvchi nomi yoki parol noto'g'ri");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private PropertyInfo Property(string name)
        {
            return typeof(TestType).GetProperty(name);
        }
    }
}
