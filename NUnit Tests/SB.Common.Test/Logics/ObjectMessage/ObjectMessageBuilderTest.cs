using System.Collections.Generic;
using NUnit.Framework;
using SB.Common.Logics.ObjectMessage;

namespace SB.Common.Test.Logics.ObjectMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class ObjectMessageBuilderTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuildWithArgIndex()
        {
            var builder = new ObjectMessageBuilder("Hello {[0]} {[1]}");
            var buildResult = builder.Build("World", "Builder");

            Assert.AreEqual(buildResult, "Hello World Builder");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuildWithPropertyName()
        {
            var builder = new ObjectMessageBuilder("Hello {FriendName}");
            var buildResult = builder.Build(new { FriendName = "Alex" });

            Assert.AreEqual(buildResult, "Hello Alex");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuildWithArgIndexAndPropertyName()
        {
            var builder = new ObjectMessageBuilder("Hello {[0].FriendName}");
            var buildResult = builder.Build(new { FriendName = "Alex" });

            Assert.AreEqual(buildResult, "Hello Alex");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuildWithMultiplePropertyName()
        {
            var builder = new ObjectMessageBuilder("Name: {Name}, Age: {Age}");
            var buildResult = builder.Build(new { Name = "Alex", Age = 15 });

            Assert.AreEqual(buildResult, "Name: Alex, Age: 15");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuildWithMultipleArgAndMultiplePropertyName()
        {
            var builder = new ObjectMessageBuilder("Name: {Name}, Age: {Age}");
            var buildResult = builder.Build(
                new { Name = "Alex", Age = 15 },
                new { Name = "Sophia", Age = 17 });

            Assert.AreEqual(buildResult, "Name: Alex, Age: 15");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuildWithArgIndexAndMultiplePropertyName()
        {
            var builder = new ObjectMessageBuilder("Name: {[0].Name}, Age: {[1].Age}");
            var buildResult = builder.Build(
                new { Name = "Alex", Age = 15 },
                new { Name = "Sophia", Age = 17 });

            Assert.AreEqual(buildResult, "Name: Alex, Age: 17");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuildWithList()
        {
            var names = new List<string> { "Alex", "Sophia" };
            var builder = new ObjectMessageBuilder("First Name: {[0].[0]}, Second Name: {[0].[1]}");
            var buildResult = builder.Build(names);

            Assert.AreEqual(buildResult, "First Name: Alex, Second Name: Sophia");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuildWithListProperties()
        {
            var names = new List<object> { new { Name = "Alex" }, new { Name = "Sophia" } };
            var builder = new ObjectMessageBuilder("First Name: {[0].[0].Name}, Second Name: {[0].[1].Name}");
            var buildResult = builder.Build(names);

            Assert.AreEqual(buildResult, "First Name: Alex, Second Name: Sophia");
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuildWithListPropertiesAndWithOutArgIndex()
        {
            var names = new List<object> { new { Name = "Alex" }, new { Name = "Sophia" } };
            var builder = new ObjectMessageBuilder("First Name: {[0].Name}, Second Name: {[1].Name}");
            var buildResult = builder.Build(names);

            Assert.AreEqual(buildResult, "First Name: Alex, Second Name: Sophia");
        }
    }
}
