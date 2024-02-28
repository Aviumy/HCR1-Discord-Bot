using HCR1DiscordBot.Services.ModuleServices;

namespace HCR1DiscordBot.UnitTests.ServiceTests.ModuleServiceTests
{
    public class HelpModuleServiceTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(@"..\..\..\Data\HelpExample.txt")]
        public void ReadHelpText_ValidPathAndTxtExtension_ReturnsText(string path)
        {
            var service = new HelpModuleService(path);
            var expected = "Help exmaple.";

            var actual = service.ReadHelpText();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(@"..\..\..\Data\HelpExample.json")]
        public void ReadHelpText_ValidPathNotTxtExtension_ReturnsText(string path)
        {
            var service = new HelpModuleService(path);
            var expected = "{\"help\": \"example\"}";

            var actual = service.ReadHelpText();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ReadHelpText_NullPath_ThrowsArgumentNullException()
        {
            var service = new HelpModuleService(null);

            Assert.That(() => service.ReadHelpText(),
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        [TestCase(@"..\..\..\Data\WrongPath.txt")]
        public void ReadHelpText_NonExistentPath_ThrowsFileNotFoundException(string path)
        {
            var service = new HelpModuleService(path);

            Assert.That(() => service.ReadHelpText(),
                Throws.Exception.TypeOf<FileNotFoundException>());
        }
    }
}
