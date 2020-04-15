using BlabberApp.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlabberApp.DomainTest.Entities {
    [TestClass]
    public class Blab_Test {
        [TestMethod]
        public void TestSetGetMessage() {
            // Arrange
            Blab _harness1 = new Blab();
            string expected = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."; 
            _harness1.Message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...";
            // Act
            string actual = _harness1.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestId() {
            // Arrange
            Blab _harness2 = new Blab();
            Guid expected = _harness2.Id;
            // Act
            Guid actual = _harness2.Id;
            // Assert
            Assert.AreEqual(actual, expected);
        }
        
        [TestMethod]
        public void TestDTTM() {
            // Arrange
            Blab Expected = new Blab();
            // Act
            Blab Actual = new Blab();
            // Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }
    }
}