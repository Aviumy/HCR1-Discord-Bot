using HCR1DiscordBot.Services.ModuleServices;
using HCR1DiscordBot.UnitTests.Data;
using System.Globalization;

namespace HCR1DiscordBot.UnitTests.ServiceTests.ModuleServiceTests
{
    public class InfoModuleServiceTests
    {
        private int _randSeed;
        private HCR1DiscordBotFaker _faker;

        [SetUp]
        public void Setup()
        {
            _randSeed = 0;
            _faker = new HCR1DiscordBotFaker();
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
        }

        [Test]
        public void GetRandomVehicleOrStage_ReturnsRandomVehicleOrStage()
        {
            var service = new InfoModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            var expected = _faker.GetAllExampleStages().Last();

            var actual = service.GetRandomVehicleOrStage();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("Hill Climber")]
        [TestCase("hill climber")]
        [TestCase("hillclimber")]
        [TestCase("h i l lc l i m b e r")]
        [TestCase(" \t\n\r-+_=*~`|Hill -+_=*~`|Climber \t\n\r-+_=*~`|")]
        public void GetVehicleOrStageInfo_ValidVehicleName_ReturnsVehicleInfo(string parameter)
        {
            var service = new InfoModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            var expected = _faker.GetExampleVehiclesAndStagesInfo().First();

            var actual = service.GetVehicleOrStageInfo(parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("jeep")]
        [TestCase("JEEP")]
        [TestCase("j e e p")]
        [TestCase(" \t\n\r-+_=*~`|jeep \t\n\r-+_=*~`|")]
        public void GetVehicleOrStageInfo_ValidVehicleAlias_ReturnsVehicleInfo(string parameter)
        {
            var service = new InfoModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            var expected = _faker.GetExampleVehiclesAndStagesInfo().First();

            var actual = service.GetVehicleOrStageInfo(parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(":hill_climber:")]
        [TestCase(":HILL_CLIMBER:")]
        [TestCase(":hillclimber:")]
        [TestCase(": h i l l c l i m b e r :")]
        [TestCase(" \t\n\r-+_=*~`|:hill -+_=*~`|climber \t\n\r-+_=*~`|:")]
        public void GetVehicleOrStageInfo_ValidVehicleEmoji_ReturnsVehicleInfo(string parameter)
        {
            var service = new InfoModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            var expected = _faker.GetExampleVehiclesAndStagesInfo().First();

            var actual = service.GetVehicleOrStageInfo(parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }








        [Test]
        [TestCase("Countryside")]
        [TestCase("countryside")]
        [TestCase("C o u n t r y s i d e")]
        [TestCase(" \t\n\r-+_=*~`|Countryside \t\n\r-+_=*~`|")]
        public void GetVehicleOrStageInfo_ValidStageName_ReturnsStageInfo(string parameter)
        {
            var service = new InfoModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            var expected = _faker.GetExampleVehiclesAndStagesInfo().Last();

            var actual = service.GetVehicleOrStageInfo(parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("contry")]
        [TestCase("CONTRY")]
        [TestCase("c o n t r y")]
        [TestCase(" \t\n\r-+_=*~`|contry \t\n\r-+_=*~`|")]
        public void GetVehicleOrStageInfo_ValidStageAlias_ReturnsStageInfo(string parameter)
        {
            var service = new InfoModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            var expected = _faker.GetExampleVehiclesAndStagesInfo().Last();

            var actual = service.GetVehicleOrStageInfo(parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }





        [Test]
        [TestCase("")]
        [TestCase("Inexsistent vehicle")]
        public void GetVehicleOrStageInfo_InvalidVehicleOrStageName_ReturnsCouldntFindString(string parameter)
        {
            var service = new InfoModuleService(
                randSeed: _randSeed,
                vehiclesFilePath: @"..\..\..\Data\VehiclesExample.json",
                stagesFilePath: @"..\..\..\Data\StagesExample.json"
            );
            var expected = "Couldn't find such vehicle or stage";

            var actual = service.GetVehicleOrStageInfo(parameter);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
