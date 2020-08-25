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
