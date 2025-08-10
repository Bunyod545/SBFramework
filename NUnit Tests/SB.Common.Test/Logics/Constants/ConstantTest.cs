using NUnit.Framework;
using SB.Common.Logics.Business;
using SB.Common.Logics.Constants.Logics.ConstantRepositories;
using SB.Common.Logics.Metadata;
using SB.Common.Test.Logics.Constants.Models;
using SB.Common.Test.Logics.Metadata.Initializers;
using System.Collections.Generic;

namespace SB.Common.Test.Logics.Constants
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstantTest
    {
        /// <summary>
        /// 
        /// </summary>
        private const string OrgName = "Test org";

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            SBType.Initializer = new SBTypeTestInitializer();
            SBType.InitializeTypes();
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestOrgName()
        {
            var context = new ConstantContext();
            context.OrgName.SetValue(OrgName);
            context.SaveChanges();

            var orgNameValue = context.OrgName.GetValue(); 
            Assert.AreEqual(OrgName, orgNameValue);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestDirector()
        {
            var director = new ConstantEmployee();
            director.Id = 1;
            director.Name = "Test Director";
            MemoryConstantRepository.Entities.Add(typeof(ConstantEmployee), new List<IIdentified>() { director });

            var context = new ConstantContext();
            context.Director.SetValue(director);
            context.SaveChanges();

            var directorValue = context.Director.GetValue();
            Assert.AreEqual(director.Id, directorValue.Id);
        }
    }
}
