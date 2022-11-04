using Moq;

namespace PRO2ST2223PE.Test
{
    [TestClass]
    public class BoredServiceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var boredServiceApi = new Mock<IBoredApiService>();
            boredServiceApi.Setup(x => x.GetBoredResponse().Activity).Returns("Go swimming with a friend");

            var service = new BoredService(boredServiceApi.Object);
            var result = service.BoredRandom();

            Assert.AreEqual("Go swimming with a friend", result);
            
        }
    }
}