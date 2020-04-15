using BlabberApp.DataStore.Adapters;
using BlabberApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.ServicesTest {
    [TestClass]
    public class BlabServiceFactory_Test {

        [TestMethod]
        public void BuildAdapterPluginTest() {
            //Arrange and Act
            BlabServiceFactory _harness1 = new BlabServiceFactory();
            BlabAdapter blabAdapter = _harness1.CreateBlabAdapter();
            //Assert
            Assert.IsTrue(blabAdapter is BlabAdapter);
        }
        
        [TestMethod]
        public void BuildServiceAdapterPluginTest() {
            //Arrange and Act
            BlabServiceFactory _harness2 = new BlabServiceFactory();
            BlabService blabService = _harness2.CreateBlabService();
            //Assert
            Assert.IsTrue(blabService is BlabService);
        }
    }
}