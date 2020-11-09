using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood;

namespace Testovi
{
    [TestClass]
    public class TestPrimbrojeva
    {
        [TestMethod]
        public void GenerirajPrimBrojeveZa0VracaPrazanNiz()
        {
            Assert.AreEqual(0, Program.GenerirajPrimBrojeve(0).Length);
        }

        [TestMethod]
        public void GenerirajPrimBrojeveZa1VracaPrazanNiz()
        {
            Assert.AreEqual(0, Program.GenerirajPrimBrojeve(1).Length);
        }

        [TestMethod]
        public void GenerirajPrimBrojeveZa2VracaBroj2()
        {
            Assert.AreEqual(1, Program.GenerirajPrimBrojeve(2).Length);
            Assert.AreEqual(2, Program.GenerirajPrimBrojeve(2)[0]);
        }

        [TestMethod]
        public void GenerirajPrimBrojeveZa100Vraca25PrimBrojeva()
        {
            Assert.AreEqual(25, Program.GenerirajPrimBrojeve(100).Length);         
        }

        [TestMethod]
        public void GenerirajPrimBrojeveZa100VracaprimBroj7()
        {
            Assert.AreEqual(7, Program.GenerirajPrimBrojeve(100)[3]);
        }
        [TestMethod]
        public void GenerirajPrimBrojeveZa100VracaprimBroj97()
        {
            Assert.AreEqual(97, Program.GenerirajPrimBrojeve(100)[24]);
        }
    }
}
