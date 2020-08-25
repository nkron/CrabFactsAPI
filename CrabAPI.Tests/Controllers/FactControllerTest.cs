using CrabAPI.Controllers;
using Moq;
using CrabFactsLibrary.Models;
using CrabFactsLibrary;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrabAPI.Tests.Controllers
{
    [TestClass]
    public class FactControllerTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var repo = new Mock<ISqliteDataAccess>();

            var controller = new FactController(repo.Object);

            Assert.IsNotNull((controller));
        }

        [TestMethod]
        public void Get_ReturnsCorrectFact()
        {
            var repo = new Mock<ISqliteDataAccess>();
            repo.Setup(p => p.LoadFacts()).Returns(GetFakeData());
            var controller = new FactController(repo.Object);
            var expectedId = 1; 
            var actualId = 0;

            actualId = controller.Get(1).id;

            Assert.AreEqual(expectedId,actualId);
        }

        [TestMethod]
        public void RandomFact_GivesFact()
        {
            // Arrange
            var repo = new Mock<ISqliteDataAccess>();
            repo.Setup(p => p.LoadFacts()).Returns(GetFakeData());
            var controller = new FactController(repo.Object);
            Fact result = null;

            // Act
            result = controller.RandomFact();

            // Assert
            Assert.IsNotNull(result);
        }

        private List<Fact> GetFakeData()
        {
            var data = new List<Fact>()
            {
                new Fact(){id=0,description="testDesc0"},
                new Fact(){id=1,description="testDesc1"},
            };
            return data;
        }
    }
}
