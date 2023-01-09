using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using KeyboardAndMouseActions.Utility;
using KeyboardAndMouseActions.Drivers;

namespace KeyboardAndMouseActions.Pages
{
    internal class MouseHover
    {
        public static void MouseHoverMethod()
        {
            KandMDrivers.driver.Navigate().GoToUrl("https://www.spicejet.com/");
            var Hover = By.XPath("(//div[@class='css-1dbjc4n r-1awozwy r-1loqt21 r-18u37iz r-le9fof r-1otgn73'])[1]");
            KandMDrivers.wait.Until(ExpectedConditions.ElementIsVisible(Hover));
            //Hovering on to the element using keyboard and mouse action
            KandMDrivers.actions.MoveToElement(KandMDrivers.driver.FindElement(Hover)).Perform();
            KandMDrivers.driver.FindElement(By.XPath("//*[@data-testid='test-id-Visa Services']")).Click();           
        }
        public static void MouseHoverVerifyAndScreenshot()
        {
            var tabs = KandMDrivers.driver.WindowHandles;
            int count = tabs.Count;
            foreach (string tab in tabs)
            {
                //switching the tab
                KandMDrivers.driver.SwitchTo().Window(tab);
            }
            KandMDrivers.wait.Until(ExpectedConditions.UrlContains("VisaServices"));
            string Titled = KandMDrivers.driver.Url;
            if(Titled.Contains("VisaServices"))
            {
                CaptureScreenshot.TakeScreensot("MouseHoverAction");
            }
            else
            {
                Console.WriteLine("Driver URL not matched, Hence unable to capture Screenshot");
            }
            Assert.That(Titled.Contains("VisaServices"), Is.EqualTo(true), "not matching");
        }
    }
}
