using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlabberApp.ClientTest {
    [TestClass]
    public class Client_Test {
        [TestMethod]
        public void CanaryTests() {
            string test_string = "test string";
            string same_string = test_string;
            Assert.IsTrue(true);
            Assert.IsFalse(!true);
            Assert.IsFalse(false);
            Assert.IsNull(null);
            Assert.IsNotNull(1);
            Assert.IsInstanceOfType(test_string, typeof(string) );
            Assert.IsNotInstanceOfType(2, typeof(Array) );
            Assert.AreEqual(1, 1);
            Assert.AreNotEqual(1, test_string);
            Assert.AreSame(test_string, same_string);
            Assert.AreNotSame("a", "Z");
        }
    }
}
