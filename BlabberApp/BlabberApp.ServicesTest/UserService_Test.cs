using BlabberApp.Domain.Entities;
using BlabberApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace BlabberApp.ServicesTest {
    [TestClass]
    public class UserService_Test {

        [TestMethod]
        public void GetAllEmptyTest() {
            //Arrange
            UserServiceFactory _userServiceFactory = new UserServiceFactory();
            UserService userService = _userServiceFactory.CreateUserService();
            ArrayList expected = new ArrayList();
            //Act
            IEnumerable actual = userService.GetAll();
            //Assert
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }

        [TestMethod]
        public void AddNewUserSuccessTest() {
            //Arrange
            UserServiceFactory _userServiceFactory = new UserServiceFactory();
            string email = "user@example.com"; 
            UserService userService = _userServiceFactory.CreateUserService();
            User expected = userService.CreateUser(email);
            userService.AddNewUser(email);
            //Act
            User actual = userService.FindUser(email);
            //Assert
            Assert.AreEqual(expected.Email, actual.Email);
        }
    }
}