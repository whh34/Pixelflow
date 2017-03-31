using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PixelFlow;
using static NUnit.Framework.Assert;

namespace Tests
{
    [TestFixture]
    public class SampleTest
    {
        [Test]
        public void DoSomethingTest()
        {
            TestClass.DoSomething();
            AreEqual(0, 1);
        }

        [Test]
        public void DoSomethingElse()
        {
            AreEqual(0, 0);
        }

        [Test]
        public void Ermagherd()
        {
            AreNotEqual(1, 0);
        }
    }
}
