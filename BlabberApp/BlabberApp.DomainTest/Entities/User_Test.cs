using BlabberApp.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BlabberApp.DomainTest.Entities {
    [TestClass]
    public class User_Test {
        [TestMethod]
        public void TestSetGetEmail_Success() {
            // Arrange
            User _harness1 = new User(); 
            string expected = "foobar@example.com";
            _harness1.Email = "foobar@example.com";
            // Act
            string actual = _harness1.Email; // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail00() {
            // Arrange
            User _harness2 = new User(); 
            
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => _harness2.Email = "Foobar");
            // Assert
            Assert.AreEqual("Email is invalid", ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail01() {
            // Arrange
            User _harness3 = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => _harness3.Email = "example.com");
            // Assert
            Assert.AreEqual("Email is invalid", ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail02() {
            // Arrange
            User _harness4 = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => _harness4.Email = "foobar.example");
            // Assert
            Assert.AreEqual("Email is invalid", ex.Message.ToString());
        }

        [TestMethod]
        public void TestId() {
            // Arrange
            User _harness5 = new User();
            Guid expected = _harness5.Id;
            // Act
            Guid actual = _harness5.Id;
            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}