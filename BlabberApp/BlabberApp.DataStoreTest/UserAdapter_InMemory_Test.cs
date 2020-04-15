using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class UserAdapter_InMemory_Test {
        private UserAdapter _harness = new UserAdapter(new InMemory() );
        
        [TestMethod]
        public void Canary() {
            Assert.AreEqual(true, true);
        }
    }
}
