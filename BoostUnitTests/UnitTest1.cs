using BoostRedirectChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BoostUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Router router = new Router();

            var answer = router.Process(new List<string> {
                    "/home",
                    "/our-ceo.html -> /about-us.html",
                    "/about-us.html -> /about",
                    "/product-1.html -> /seo"
                });

            Assert.AreEqual(new string[3] { "/home", "/our-ceo.html -> /about-us.html -> /about", "/product-1.html -> /seo" }.ToString(), answer.ToString());
        }
    }
}