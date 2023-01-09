using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using KeyboardAndMouseActions.Pages;
using NUnit.Framework;
using KeyboardAndMouseActions.Drivers;

namespace KeyboardAndMouseActions
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            ChromeOptions op = new ChromeOptions();
            //disable notification parameter
            op.AddArguments("--disable-notifications");
            KandMDrivers.driver = new ChromeDriver(op);
            KandMDrivers.driver.Manage().Window.Maximize();
            KandMDrivers.actions = new Actions(KandMDrivers.driver);
            KandMDrivers.wait = new WebDriverWait(KandMDrivers.driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void DragAndDropTest()
        {
            DragAndDrop.DragAndDropMethod();
            DragAndDrop.DragandDropVerifyAndScreenshot();
        }
        [Test]
        public void MouseHoverTest()
        {
            MouseHover.MouseHoverMethod();
            MouseHover.MouseHoverVerifyAndScreenshot();
        }
        [Test]
        public void CopyPasteTest()
        {
            CopyPaste.CopyPasteMethod();
            CopyPaste.CopyPasteVerifyAndScreenshot();
        }
        [TearDown]
        public void Teardown()
        {
            KandMDrivers.driver.Quit();
        }
    }
}