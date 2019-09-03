using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using MicrosoftShimTesting.Fakes;
using Moq;
using NUnit.Framework;

namespace MicrosoftShimTesting
{
    public class A
    {
        private Connection _connection;

        public A(Connection connection)
        {
            _connection = connection;
        }

        public string[] GetAll()
        {
            return new[]
            {
                _connection.PublicProp,
                _connection.GetSettings()
            };
        }
    }

    [TestFixture]
    public class TestConnection
    {
        [Test]
        public void testing()
        {
            var cut = new Mock<IConnectionProvider>();
            cut.Setup(x => x.GetConnection).Returns(() =>
            {
                var x = new ShimConnection();
                x.GetSecret = () => "fake";
                x.GetSettings = () => "fake";
                x.PublicPropGet = () => "fake";
                return x;
            });

            using (ShimsContext.Create())
            {
                var a = new A(cut.Object.GetConnection);
                Assert.AreEqual(a.GetAll().Length, 2);
                Assert.AreEqual(a.GetAll()[0], "fake");
                Assert.AreEqual(a.GetAll()[1], "fake");
            }
        }
    }
}
