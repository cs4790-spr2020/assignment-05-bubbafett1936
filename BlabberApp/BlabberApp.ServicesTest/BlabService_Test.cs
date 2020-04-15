using BlabberApp.Domain.Entities;
using BlabberApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace BlabberApp.ServicesTest {
    [TestClass]
    public class BlabService_Test {
        [TestMethod]
        public void GetAllEmptyTest() {
            //Arrange
            BlabServiceFactory _harness1 = new BlabServiceFactory();
            BlabService blabService = _harness1.CreateBlabService();
            ArrayList expected = new ArrayList();
            //Act
            IEnumerable actual = blabService.GetAll();
            //Assert
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }

        [TestMethod]
        public void AddNewBlabSuccessTest() {
            //Arrange
            BlabServiceFactory _harness2 = new BlabServiceFactory();
            string email = "user@example.com";
            string msg = "Prow scuttle parrel provost Sail ho shrouds spirits boom mizzenmast yardarm.";
            BlabService blabService = _harness2.CreateBlabService();
            Blab blab = blabService.CreateBlab(msg, email);
            blabService.AddBlab(blab);
            //Act
            // Not yet implemented
            // Blab actual = (Blab)blabService.FindUserBlabs(email);
            //Assert
            // Assert.AreEqual(blab.Message, actual.Message);
        }
    }
}