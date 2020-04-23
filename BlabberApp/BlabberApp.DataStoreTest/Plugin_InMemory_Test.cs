using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class Plugin_InMemory_Test {
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
        public void Test_Create_ReadAll_Update_DeleteUser() {
            InMemory _im_harness1 = new InMemory();
            User user1 = new User("foo@example.com");
            User user2 = new User("bar@example.com");
            User user3 = new User("baz@example.com");
            
            // Arrange
            user1.RegisterDTTM = DateTime.Now;
            user1.LastLoginDTTM = DateTime.Now;
            user2.RegisterDTTM = DateTime.Now;
            user2.LastLoginDTTM = DateTime.Now;
            user3.RegisterDTTM = DateTime.Now;
            user3.LastLoginDTTM = DateTime.Now;
            
            // Act
            _im_harness1.Create(user1);
            _im_harness1.Create(user2);
            _im_harness1.Create(user3);
            User user4 = _im_harness1.ReadByUserEmail("baz@example.com") as User;
            _im_harness1.Update(user1);
            ArrayList al_users = (ArrayList) _im_harness1.ReadAll();
            
            // Assert
            Assert.AreEqual( ( (User)al_users[2] ).Email, "foo@example.com");
            Assert.AreEqual( ( (User)al_users[0] ).Email, "bar@example.com");
            Assert.AreEqual( ( (User)al_users[1] ).Email, "baz@example.com");
            Assert.AreEqual(user4.RegisterDTTM, user3.RegisterDTTM);
            _im_harness1.Delete(user1);
            _im_harness1.Delete(user2);
            _im_harness1.Delete(user3);
            Assert.AreEqual(((ArrayList)_im_harness1.ReadAll()).Count, 0);
        }
        
        [TestMethod]
        public void Test_Create_ReadById_ReadByUserIdBlab() {
            InMemory _im_harness2 = new InMemory();
            User user4 = new User("foo@example.com");
            User user5 = new User("bar@example.com");
            User user6 = new User("baz@example.com");
            User user7 = new User("naz@example.com");
            Blab blab1 = new Blab(user4, "foo's first blab");
            Blab blab2 = new Blab(user4, "foo's second blab");
            Blab blab3 = new Blab(user5, "bar's only blab");
            Blab blab4 = new Blab(user6, "baz's first blab");
            Blab blab5 = new Blab(user6, "baz's second blab");
            Blab blab6 = new Blab(user6, "baz's third blab");
            Blab blab7 = new Blab(user7);
            Blab blab8 = new Blab("Anonymous user");

            // Arrange
            _im_harness2.Create(blab1);
            _im_harness2.Create(blab2);
            _im_harness2.Create(blab3);
            _im_harness2.Create(blab4);
            _im_harness2.Create(blab5);
            _im_harness2.Create(blab6);
            
            // Act
            Blab blab9 = _im_harness2.ReadById(blab3.Id) as Blab;
            ArrayList blabs = _im_harness2.ReadByUserId("baz@example.com") as ArrayList;
            
            // Assert
            Assert.AreEqual(blab9.Message.ToString(), "bar's only blab");
            Assert.AreEqual( ( (Blab)blabs[0] ).Message.ToString(), "baz's first blab");
            Assert.AreEqual( ( (Blab)blabs[1] ).Message.ToString(), "baz's second blab");
            Assert.AreEqual( ( (Blab)blabs[2] ).Message.ToString(), "baz's third blab");
        }
    }
}
