using BlabberApp.DataStore.Adapters;
using BlabberApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.ServicesTest {
    [TestClass]
    public class UserServiceFactory_Test {
        [TestMethod]
        public void BuildAdapterPluginTest() {
            //Arrange and Act
            UserServiceFactory _harness1 = new UserServiceFactory();
            UserAdapter userAdapter = _harness1.CreateUserAdapter();
            //Assert
            Assert.IsTrue(userAdapter is UserAdapter);
        }

        [TestMethod]
        public void BuildServiceAdapterPluginTest() {
            //Arrange and Act
            UserServiceFactory _harness2 = new UserServiceFactory();
            UserService userService = _harness2.CreateUserService();
            //Assert
            Assert.IsTrue(userService is UserService);
        }
    }
}