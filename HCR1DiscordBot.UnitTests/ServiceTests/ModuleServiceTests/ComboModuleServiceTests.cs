using HCR1DiscordBot.Services;
using HCR1DiscordBot.Services.ModuleServices;
using HCR1DiscordBot.UnitTests.Data;

namespace HCR1DiscordBot.UnitTests.ServiceTests.ModuleServiceTests
{
    public class ComboModuleServiceTests
    {
        private int _randSeed;
        private HCR1DiscordBotFaker _faker;

        [SetUp]
        public void Setup()
        {
            _randSeed = 0;
            _faker = new HCR1DiscordBotFaker();
        }

        [Test]
        public void GetRandomVehicle_ValidArray_ReturnsRandomVehicle()
        {
            var service = new ComboModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            var expected = _faker.GetAllExampleVehicles().Last();

            var actual = service.GetRandomVehicle();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetRandomVehicle_EmptyArray_ThrowsIndexOutOfRangeException()
        {
            var service = new ComboModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\EmptyArray.json",
                stagesFilePath: @"..\..\..\Data\EmptyArray.json"
            );

            Assert.That(() => service.GetRandomVehicle(),
                Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void GetRandomVehicle_NullArray_ThrowsNullReferenceException()
        {
            var service = new ComboModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\Empty.json",
                stagesFilePath: @"..\..\..\Data\Empty.json"
            );

            Assert.That(() => service.GetRandomVehicle(),
                Throws.Exception.TypeOf<NullReferenceException>());
        }








        [Test]
        public void GetRandomStage_ValidArrayWithMissions_ReturnsRandomStage()
        {
            var service = new ComboModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            var expected = _faker.GetAllExampleStages()[3];

            var actual = service.GetRandomStage(excludeMissions: false);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetRandomStage_ValidArrayWithoutMissions_ReturnsRandomStage()
        {
            var service = new ComboModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            var expected = _faker.GetExampleStagesWithoutMissons().Last();

            var actual = service.GetRandomStage(excludeMissions: true);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void GetRandomStage_EmptyArray_ThrowsIndexOutOfRangeException(bool excludeMissions)
        {
            var service = new ComboModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\EmptyArray.json",
                stagesFilePath: @"..\..\..\Data\EmptyArray.json"
            );

            Assert.That(() => service.GetRandomStage(excludeMissions),
                Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void GetRandomStage_NullArray_ThrowsNullReferenceException(bool excludeMissions)
        {
            var service = new ComboModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\Empty.json",
                stagesFilePath: @"..\..\..\Data\Empty.json"
            );

            Assert.That(() => service.GetRandomStage(excludeMissions),
                Throws.Exception.TypeOf<NullReferenceException>());
        }
    }
}
