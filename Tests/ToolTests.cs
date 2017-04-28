using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Windows.Forms;
using System.Drawing;
using PixelFlow;
using static NUnit.Framework.Assert;

namespace Tests
{
    
    [TestFixture]
    public class ToolTests
    {
        private DrawPane sPane, mPane, lPane, rPane;
        [SetUp]
        public void Init()
        {
            sPane = new DrawPane(1, 1, 1);
            mPane = new DrawPane(32, 32, 1);
            lPane = new DrawPane(1024, 1024, 1);
            rPane = new DrawPane(16, 30, 1);
        }

        [Test]
        public void ColorTest()
        {
            AreEqual(1, 1);
        }

        [Test]
        public void PencilTest()
        {
            
            sPane.DrawPane_MouseDown("pencil", new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));
            mPane.DrawPane_MouseDown("pencil", new MouseEventArgs(MouseButtons.Left, 1, 16, 16, 0));
            lPane.DrawPane_MouseDown("pencil", new MouseEventArgs(MouseButtons.Left, 1, 1024, 1024, 0));
            rPane.DrawPane_MouseDown("pencil", new MouseEventArgs(MouseButtons.Left, 1, 8, 25, 0));
            AreEqual(sPane.GetPixel(1, 1), Color.Black);
            AreEqual(mPane.GetPixel(16, 16), Color.Black);
            AreEqual(lPane.GetPixel(1024, 1024), Color.Black);
            AreEqual(rPane.GetPixel(8, 25), Color.Black);

        }

        [Test]
        public void LineTest()
        {
            AreEqual(1, 1);
        }

        [Test]
        public void RectangleTest()
        {
            AreEqual(1, 1);
        }

        [Test]
        public void CircleTest()
        {
            AreEqual(1, 1);
        }

        [Test]
        public void GradientTest()
        {

        }

        [Test]
        public void FillTest()
        {

        }

        [Test]
        public void SelectTest()
        {

        }

        [Test]
        public void DragTest()
        {

        }
    }
}
