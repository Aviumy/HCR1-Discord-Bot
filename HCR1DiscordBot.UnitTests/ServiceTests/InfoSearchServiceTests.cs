using HCR1DiscordBot.Models;
using HCR1DiscordBot.Services;
using HCR1DiscordBot.UnitTests.Data;

namespace HCR1DiscordBot.UnitTests.ServiceTests
{
    public class InfoSearchServiceTests
    {
        private InfoSearchService _infoSearchService;
        private HCR1DiscordBotFaker _faker;

        [SetUp]
        public void Setup()
        {
            _infoSearchService = new InfoSearchService();
            _faker = new HCR1DiscordBotFaker();
        }

        [Test]
        [TestCase("Hill Climber")]
        [TestCase("hill climber")]
        public void FindIn_ValidArrayAndVehicleName_ReturnsVehicle(string parameter)
        {
            var vehicles = _faker.GetAllExampleVehicles();
            var expected = vehicles.First();

            var actual = _infoSearchService.FindIn(vehicles, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("Jeep")]
        [TestCase("jeep")]
        public void FindIn_ValidArrayAndVehicleAlias_ReturnsVehicle(string parameter)
        {
            var vehicles = _faker.GetAllExampleVehicles();
            var expected = vehicles.First();

            var actual = _infoSearchService.FindIn(vehicles, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("HillClimber")]
        [TestCase("hillclimber")]
        public void FindIn_VehicleNameWithoutWhitespaces_ReturnsVehicle(string parameter)
        {
            var vehicles = _faker.GetAllExampleVehicles();
            var expected = vehicles.First();

            var actual = _infoSearchService.FindIn(vehicles, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(" \t\n\r-+_=*~`|Hill -+_=*~`|Climber \t\n\r-+_=*~`|")]
        [TestCase(" \t\n\r-+_=*~`|hill -+_=*~`|climber \t\n\r-+_=*~`|")]
        public void FindIn_VehicleNameWithDifferentWhitespaces_ReturnsVehicle(string parameter)
        {
            var vehicles = _faker.GetAllExampleVehicles();
            var expected = vehicles.First();

            var actual = _infoSearchService.FindIn(vehicles, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("garageracecar")]
        [TestCase("GarageRaceCar")]
        public void FindIn_VehicleAliasWithoutWhitespaces_ReturnsVehicle(string parameter)
        {
            var vehicles = _faker.GetAllExampleVehicles();
            var expected = vehicles.Last();

            var actual = _infoSearchService.FindIn(vehicles, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(" \t\n\r-+_=*~`|garage \t\n\r-+_=*~`|race -+_=*~`|car \t\n\r-+_=*~`|")]
        [TestCase("G\ta\nr\ra-g+e R_a=c*e C~a`|r")]
        public void FindIn_VehicleAliasWithDifferentWhitespaces_ReturnsVehicle(string parameter)
        {
            var vehicles = _faker.GetAllExampleVehicles();
            var expected = vehicles.Last();

            var actual = _infoSearchService.FindIn(vehicles, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("")]
        [TestCase("Inexistent car")]
        public void FindIn_VehicleNotFound_ReturnsNull(string parameter)
        {
            var vehicles = _faker.GetAllExampleVehicles();

            var actual = _infoSearchService.FindIn(vehicles, parameter);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void FindIn_VehiclesArrayIsEmpty_ReturnsNull()
        {
            var vehicles = new Vehicle[0];

            var actual = _infoSearchService.FindIn(vehicles, "");

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void FindIn_VehiclesArrayIsNull_ThrowsArgumentNullException()
        {
            Vehicle[] vehicles = null;

            Assert.That(() => _infoSearchService.FindIn(vehicles, ""), 
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void FindIn_VehicleParameterIsNull_ThrowsArgumentNullException()
        {
            var vehicles = _faker.GetAllExampleVehicles();

            Assert.That(() => _infoSearchService.FindIn(vehicles, null), 
                Throws.Exception.TypeOf<ArgumentNullException>());
        }







        [Test]
        [TestCase("Countryside")]
        [TestCase("countryside")]
        public void FindIn_ValidArrayAndStageName_ReturnsStage(string parameter)
        {
            var stages = _faker.GetAllExampleStages();
            var expected = stages.First();

            var actual = _infoSearchService.FindIn(stages, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("Country")]
        [TestCase("country")]
        public void FindIn_ValidArrayAndStageAlias_ReturnsStage(string parameter)
        {
            var stages = _faker.GetAllExampleStages();
            var expected = stages.First();

            var actual = _infoSearchService.FindIn(stages, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("SpaceMission")]
        [TestCase("spacemission")]
        public void FindIn_StageNameWithoutWhitespaces_ReturnsStage(string parameter)
        {
            var stages = _faker.GetAllExampleStages();
            var expected = stages.Last();

            var actual = _infoSearchService.FindIn(stages, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(" \t\n\r-+_=*~`|Space -+_=*~`|Mission \t\n\r-+_=*~`|")]
        [TestCase(" \t\n\r-+_=*~`|space -+_=*~`|mission \t\n\r-+_=*~`|")]
        public void FindIn_StageNameWithDifferentWhitespaces_ReturnsStage(string parameter)
        {
            var stages = _faker.GetAllExampleStages();
            var expected = stages.Last();

            var actual = _infoSearchService.FindIn(stages, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("spacemision")]
        [TestCase("SpaceMision")]
        public void FindIn_StageAliasWithoutWhitespaces_ReturnsStage(string parameter)
        {
            var stages = _faker.GetAllExampleStages();
            var expected = stages.Last();

            var actual = _infoSearchService.FindIn(stages, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(" \t\n\r-+_=*~`|space \t\n\r-+_=*~`|mision \t\n\r-+_=*~`|")]
        [TestCase("S\tp\na\rc-+e M_i=s*i~o`|n")]
        public void FindIn_StageAliasWithDifferentWhitespaces_ReturnsStage(string parameter)
        {
            var stages = _faker.GetAllExampleStages();
            var expected = stages.Last();

            var actual = _infoSearchService.FindIn(stages, parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("")]
        [TestCase("Inexistent stage")]
        public void FindIn_StageNotFound_ReturnsNull(string parameter)
        {
            var stages = _faker.GetAllExampleStages();

            var actual = _infoSearchService.FindIn(stages, parameter);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void FindIn_StagesArrayIsEmpty_ReturnsNull()
        {
            var stages = new Stage[0];

            var actual = _infoSearchService.FindIn(stages, "");

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void FindIn_StagesArrayIsNull_ThrowsArgumentNullException()
        {
            Stage[] stages = null;

            Assert.That(() => _infoSearchService.FindIn(stages, ""),
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void FindIn_StageParameterIsNull_ThrowsArgumentNullException()
        {
            var stages = _faker.GetAllExampleStages();

            Assert.That(() => _infoSearchService.FindIn(stages, null),
                Throws.Exception.TypeOf<ArgumentNullException>());
        }
    }
}
