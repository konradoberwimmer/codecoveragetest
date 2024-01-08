using FlaUI.Core;
using FlaUI.UIA3;
using System.Reflection;

namespace TestCodeCoverageTest
{
    public class TestApp
    {
        [Fact]
        public void TestAppStart()
        {
            var app = Application.Launch(Path.Combine(AssemblyDirectory, "CodeCoverageTest.exe"));
            using UIA3Automation uiAutomation = new();

            var mainWindow = app.GetMainWindow(uiAutomation, TimeSpan.FromSeconds(3));
            Assert.NotNull(mainWindow);

            mainWindow.Close();
            app.Dispose();
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().Location;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path)!;
            }
        }
    }
}