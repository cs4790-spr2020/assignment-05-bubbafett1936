using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class UserAdapter_MySql_Test {
        [TestMethod]
        public void TestAddAndGetUser() {
            UserAdapter _harness1 = new UserAdapter(new MySqlUser() );
            User _user = new User("foobar@example.com");
            //Arrange
            _user.RegisterDTTM = DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            //Act
            _harness1.Add(_user);
            User actual = _harness1.GetById(_user.Id);
            //Assert
            Assert.AreEqual(_user.Id, actual.Id);
            _harness1.Remove(_user);
        }
        
        [TestMethod]
        public void TestAddAndGetAll() {
            UserAdapter _harness2 = new UserAdapter(new MySqlUser() );
            User _user = new User("foobar@example.com");
            //Arrange
            _user.RegisterDTTM =DateTime.Now;
            _user.LastLoginDTTM = DateTime.Now;
            _harness2.Add(_user);
            //Act
            ArrayList users = (ArrayList) _harness2.GetAll();
            User actual = (User) users[users.Count - 1];
            //Assert
            Assert.AreEqual(_user.Id.ToString(), actual.Id.ToString() );
            _harness2.Remove(_user);
        }
    }
}