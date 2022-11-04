using Moq;

namespace PRO2ST2223PE.Test
{
    [TestClass]
    public class BoredServiceTests
    {
        [TestMethod]
        public void BoredVullen_Of_Er_10_Variabalen_Toegevoegd_Zijn()
        {
            var boredServiceApi = new Mock<IBoredApiService>();
            boredServiceApi.Setup(x => x.GetBoredResponse()).Returns(new BoredResponse() { });
            var service = new BoredService(boredServiceApi.Object);
            service.BoredVullen();
            var expected = new List<BoredResponse>();
            for (int i = 0; i < 10; i++)
            {
                expected.Add(new BoredResponse() { });
            }
            Assert.AreEqual(expected.Count, BoredInMemoryDb.boredResponses.Count);
        }

        [TestMethod]
        public void BoredRandom_Kleiner_Dan_Twee()
        {
            var boredServiceApi = new Mock<IBoredApiService>();
            boredServiceApi.Setup(x => x.GetBoredResponse()).Returns(new BoredResponse() { Activity = "Organize your music collection", Participants = 1 });
            var service = new BoredService(boredServiceApi.Object);
            service.BoredVullen();
            var expected = "I don't have enough friends to => Organize your music collection";
            Assert.AreEqual(expected, service.BoredRandom());
        }

        [TestMethod]
        public void BoredRandom_Groter_Dan_Twee()
        {
            var boredServiceApi = new Mock<IBoredApiService>();
            boredServiceApi.Setup(x => x.GetBoredResponse()).Returns(new BoredResponse() { Activity = "Go see a Broadway production", Participants = 4 });
            var service = new BoredService(boredServiceApi.Object);
            service.BoredVullen();
            var expected = "Let's do some => Go see a Broadway production";
            Assert.AreEqual(expected, service.BoredRandom());
        }
    }
}