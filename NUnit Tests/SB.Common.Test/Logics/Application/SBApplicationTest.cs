using NUnit.Framework;
using SB.EntityFramework;
using SBCommon.Logics.Application;

namespace SB.Common.Test.Logics.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class SBApplicationTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void InitializeTest()
        {
            SBApplication.Create()
                .UseEntityFramework(string.Empty)
                .UseEFSbTypesInitializer(new SBSystemTestContext())
                .Initialize();

            Assert.IsTrue(SBApplication.IsInitialized);
        }
    }
}
