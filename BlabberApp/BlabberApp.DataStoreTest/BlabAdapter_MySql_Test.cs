using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class BlabAdapter_MySql_Test {
        [TestMethod]
        public void TestAddAndGetBlab() {
            BlabAdapter _harness = new BlabAdapter(new MySqlBlab() );
            //Arrange
            string email = "fooabar@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab(mockUser, "Now is the time for, blabs...");
            //Act
            _harness.Add(blab);
            ArrayList actual = (ArrayList) _harness.GetByUserId(email);
            //Assert
            Assert.AreEqual(1, actual.Count);
            _harness.Remove(blab);
        }
    }
}