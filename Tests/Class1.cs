﻿using System;
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
    }
}