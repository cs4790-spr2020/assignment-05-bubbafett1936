using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class UserAdapter_MySql_Test {
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

        [TestMethod]
        public void Test_Add_GetByEmail_RemoveUser() {
            UserAdapter _harness1 = new UserAdapter(new MySqlUser() );
            User user1 = new User("foobar@example.com");
            
            // Arrange
            user1.RegisterDTTM = DateTime.Now;
            user1.LastLoginDTTM = DateTime.Now;
            
            // Act
            _harness1.Add(user1);
            User actual = _harness1.GetByEmail(user1.Email);
            
            // Assert
            Assert.IsTrue(actual.IsValid() );
            Assert.AreEqual(user1.Id, actual.Id);
            _harness1.Remove(user1);
        }
        
        [TestMethod]
        public void Test_Add_Update_GetById_GetAll_RemoveUser() {
            UserAdapter _harness2 = new UserAdapter(new MySqlUser() );
            User user2 = new User("foo@example.com");
            User user3 = new User("bar@email.com");

            // Arrange
            user2.RegisterDTTM = DateTime.Now;
            user2.LastLoginDTTM = DateTime.Now;
            user3.RegisterDTTM = DateTime.Now;
            user3.LastLoginDTTM = DateTime.Now;
            _harness2.Add(user2);
            _harness2.Add(user3);
            _harness2.Update(user2);
            
            // Act
            User user4 = _harness2.GetById(user3.Id);
            ArrayList users = (ArrayList) _harness2.GetAll();
            User user5 = (User) users[users.Count - 1];
            
            // Assert
            Assert.AreEqual(user3.Id.ToString(), user4.Id.ToString() );
            Assert.AreEqual(user4.Id.ToString(), user5.Id.ToString() );
            _harness2.Remove(user2);
            _harness2.Remove(user3);
        }
    }
}