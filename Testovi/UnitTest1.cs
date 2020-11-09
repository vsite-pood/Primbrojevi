using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood;
namespace Testovi
{
    [TestClass]
    public class testPrimBrojeva
    {
        [TestMethod]
        public void GenerirajPrimBrojeveZa0VraćaPrazanNiz()
        {
            Assert.AreEqual(0, Program.GenerirajPrimBrojeve(0).Length);
        }
        [TestMethod]
        public void GenerirajPrimBrojeveZa1VraćaBroj2()
        {
            Assert.AreEqual(0, Program.GenerirajPrimBrojeve(1).Length);
        }
        [TestMethod]
        public void GenerirajPrimBrojeveZa2VraćaPrazanNiz()
        {
            Assert.AreEqual(1, Program.GenerirajPrimBrojeve(2).Length);
            Assert.AreEqual(2, Program.GenerirajPrimBrojeve(2)[0]);
        }
        [TestMethod]
        public void GenerirajPrimBrojeveZa100Vraća25Primbrojeva()
        {
            Assert.AreEqual(7, Program.GenerirajPrimBrojeve(100)[3]);
        }
        [TestMethod]
        public void GenerirajPrimBrojeveZa0Vraćabroj7()
        {
            Assert.AreEqual(7, Program.GenerirajPrimBrojeve(100)[3]);
        }
        [TestMethod]
        public void GenerirajPrimBrojeveZa100VraćaPrimbroj97()
        {
            Assert.AreEqual(97, Program.GenerirajPrimBrojeve(100)[24]);
        }
    }
}
