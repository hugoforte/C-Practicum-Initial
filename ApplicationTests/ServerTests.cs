using Application;

namespace ApplicationTests
{
    [TestFixture]
    public class ServerTests
    {
        private Server _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Server(new DishManager());
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void ErrorGetsReturnedWithBadInput()
        {
            var order = "One";
            string expected = "error";
            var actual = _sut.TakeOrder(order);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanServeSteak()
        {
            var order = "1";
            string expected = "steak";
            var actual = _sut.TakeOrder(order);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanServe2Potatoes()
        {
            var order = "2,2";
            string expected = "potato(x2)";
            var actual = _sut.TakeOrder(order);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanServeSteamPotatoWineCake()
        {
            var order = "1,2,3,4";
            string expected = "steak,potato,wine,cake";
            var actual = _sut.TakeOrder(order);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanServeSteakPotatoX2Cake()
        {
            var order = "1,2,2,4";
            string expected = "steak,potato(x2),cake";
            var actual = _sut.TakeOrder(order);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanGenerateErrorWithWrongDish()
        {
            var order = "1,2,3,5";
            string expected = "error";
            var actual = _sut.TakeOrder(order);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CanGenerateErrorWhenTryingToServerMoreThanOneSteak()
        {
            var order = "1,1,2,3,5";
            string expected = "error";
            var actual = _sut.TakeOrder(order);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}