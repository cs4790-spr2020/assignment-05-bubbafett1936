using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class BlabAdapter_MySql_Test {
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
        public void Test_Add_GetByUserId_RemoveBlab() {
            BlabAdapter _harness_blab = new BlabAdapter(new MySqlBlab() );
            UserAdapter _harness_user = new UserAdapter(new MySqlUser() );

            // Arrange
            string email = "fooabar@example.com";
            User mockuser = new User(email);
            _harness_user.Add(mockuser);
            Blab blab = new Blab(mockuser, "Now is the time for, blabs...");
            
            // Act
            _harness_blab.Add(blab);
            ArrayList actual = (ArrayList) _harness_blab.GetByUserId(email);
            Blab blab2 = (Blab) actual[0];
            
            // Assert
            Assert.IsTrue(blab.IsValid() );
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(blab2.Message, "Now is the time for, blabs...");
            _harness_blab.Remove(blab);
            _harness_user.Remove(mockuser);
        }

        [TestMethod]
        public void Test_Add_Update_GetById_GetAll_RemoveBlab() {
            BlabAdapter _harness_blab2 = new BlabAdapter(new MySqlBlab() );
            UserAdapter _harness_user2 = new UserAdapter(new MySqlUser() );

            // Arrange
            string email2 = "fakemail@mail.com";
            User mockuser2 = new User(email2);
            _harness_user2.Add(mockuser2);
            Blab blab3 = new Blab(mockuser2, "This is another fake blab");
            Blab blab4 = new Blab(mockuser2, "More fake blabs");
            
            // Act
            _harness_blab2.Add(blab3);
            _harness_blab2.Add(blab4);
            _harness_blab2.Update(blab3);
            Blab blab5 = _harness_blab2.GetById(blab3.Id);
            ArrayList get_all = (ArrayList) _harness_blab2.GetAll();

            // Assert
            Assert.AreEqual(blab3.Message, blab5.Message);
            Assert.IsTrue(get_all.Count > 2);
            _harness_blab2.Remove(blab3);
            _harness_blab2.Remove(blab4);
            _harness_user2.Remove(mockuser2);
        }
    }
}