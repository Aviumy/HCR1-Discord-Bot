using HCR1DiscordBot.Services;
using HCR1DiscordBot.UnitTests.Data;

namespace HCR1DiscordBot.UnitTests.ServiceTests
{
    public class JsonReaderServiceTests
    {
        private JsonReaderService _validJsonReaderService;
        private HCR1DiscordBotFaker _faker;

        [SetUp]
        public void Setup()
        {
            _validJsonReaderService = new JsonReaderService(
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            _faker = new HCR1DiscordBotFaker();
        }

        [Test]
        public void ReadAllVehicles_CorrectPath_ReturnsAllVehiclesArray()
        {
            var expected = _faker.GetAllExampleVehicles();

            var actual = _validJsonReaderService.ReadAllVehicles();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null)]
        public void ReadAllVehicles_NullPath_ThrowsArgumentNullException(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );

            Assert.That(() => jsonReaderService.ReadAllVehicles(), 
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data\WrongPath.json")]
        [TestCase(@"..\..\..\Data\WrongPath.txt")]
        public void ReadAllVehicles_NonExistentPath_ThrowsFileNotFoundException(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );

            Assert.That(() => jsonReaderService.ReadAllVehicles(), 
                Throws.Exception.TypeOf<FileNotFoundException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data\HCR1DiscordBotFaker.cs")]
        public void ReadAllVehicles_WrongFileExtension_ThrowsJsonReaderException(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );

            Assert.That(() => jsonReaderService.ReadAllVehicles(), 
                Throws.Exception.TypeOf<Newtonsoft.Json.JsonReaderException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data")]
        public void ReadAllVehicles_PathIsDirectory_ThrowsUnauthorizedAccessException(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );

            Assert.That(() => jsonReaderService.ReadAllVehicles(), 
                Throws.Exception.TypeOf<UnauthorizedAccessException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data\InvalidSyntax.json")]
        public void ReadAllVehicles_WrongJsonSyntax_ThrowsJsonReaderException(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );

            Assert.That(() => jsonReaderService.ReadAllVehicles(), 
                Throws.Exception.TypeOf<Newtonsoft.Json.JsonReaderException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data\Vehicles_NullProps.json")]
        public void ReadAllVehicles_NullProps_ReturnsAllVehiclesArray(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );
            var expected = _faker.GetExampleVehiclesWithNullProps();

            var actual = jsonReaderService.ReadAllVehicles();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(@"..\..\..\Data\Vehicles_WrongProps.json")]
        public void ReadAllVehicles_ParseNonExistentProps_ReturnsAllVehiclesArray(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );
            var expected = _faker.GetAllExampleVehicles();

            var actual = jsonReaderService.ReadAllVehicles();

            Assert.That(actual, Is.EqualTo(expected));
        }







        [Test]
        public void ReadAllStages_CorrectPath_ReturnsAllStagesArray()
        {
            var expected = _faker.GetAllExampleStages();

            var actual = _validJsonReaderService.ReadAllStages();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ReadAllStages_CorrectPathAndExcludeMissionsTrue_ReturnsStagesArrayWithoutMissions()
        {
            var expected = _faker.GetExampleStagesWithoutMissons();

            var actual = _validJsonReaderService.ReadAllStages(excludeMissions: true);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null)]
        public void ReadAllStages_NullPath_ThrowsArgumentNullException(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );

            Assert.That(() => jsonReaderService.ReadAllStages(), 
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data\WrongPath.json")]
        [TestCase(@"..\..\..\Data\WrongPath.txt")]
        public void ReadAllStages_NonExistentPath_ThrowsFileNotFoundException(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );

            Assert.That(() => jsonReaderService.ReadAllStages(), 
                Throws.Exception.TypeOf<FileNotFoundException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data\HCR1DiscordBotFaker.cs")]
        public void ReadAllStages_WrongFileExtension_ThrowsJsonReaderException(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );

            Assert.That(() => jsonReaderService.ReadAllStages(), 
                Throws.Exception.TypeOf<Newtonsoft.Json.JsonReaderException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data")]
        public void ReadAllStages_PathIsDirectory_ThrowsUnauthorizedAccessException(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );

            Assert.That(() => jsonReaderService.ReadAllStages(), 
                Throws.Exception.TypeOf<UnauthorizedAccessException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data\InvalidSyntax.json")]
        public void ReadAllStages_WrongJsonSyntax_ThrowsJsonReaderException(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );

            Assert.That(() => jsonReaderService.ReadAllStages(), 
                Throws.Exception.TypeOf<Newtonsoft.Json.JsonReaderException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data\Stages_NullProps.json")]
        public void ReadAllStages_NullProps_ReturnsAllStagesArray(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );
            var expected = _faker.GetExampleStagesWithNullProps();

            var actual = jsonReaderService.ReadAllStages();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(@"..\..\..\Data\Stages_WrongProps.json")]
        public void ReadAllStages_ParseNonExistentProps_ReturnsAllStagesArray(string path)
        {
            var jsonReaderService = new JsonReaderService(
                vehiclesFilePath: path,
                stagesFilePath: path
            );
            var expected = _faker.GetAllExampleStages();

            var actual = jsonReaderService.ReadAllStages();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
