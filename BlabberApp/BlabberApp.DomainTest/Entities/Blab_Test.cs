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
            Blab _harness2 = new Blab("Anonymous blabber");
            Guid expected = _harness2.Id;
            // Act
            Guid actual = _harness2.Id;
            // Assert
            Assert.AreEqual(actual, expected);
        }
        
        [TestMethod]
        public void TestDTTM() {
            // Arrange
            Blab _harness3 = new Blab(new User() );
            DateTime actual = DateTime.Now;
            // Act
            _harness3.DTTM = actual;
            // Assert
            Assert.AreEqual(_harness3.DTTM.ToString(), actual.ToString() );
        }

        [TestMethod]
        public void Test_Valid_Construction() {
            // Arrange
            User testuser = new User("testuser@email.com");
            testuser.LastLoginDTTM = DateTime.Now;
            testuser.RegisterDTTM = DateTime.Now;

            // Act
            Blab _harness4 = new Blab(testuser, "test string");
            _harness4.DTTM = DateTime.Now;

            // Assert
            Assert.IsTrue(_harness4.IsValid() );
        }
    }
}