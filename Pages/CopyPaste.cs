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
    internal class CopyPaste
    {
        public static void CopyPasteMethod()
        {
            KandMDrivers.driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            KandMDrivers.wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("userName")));
            KandMDrivers.driver.FindElement(By.Id("userName")).SendKeys("rasool");
            KandMDrivers.driver.FindElement(By.Id("userEmail")).SendKeys("rasool123@xyz.com");
            KandMDrivers.driver.FindElement(By.Id("currentAddress")).SendKeys("Banglore, Karnataka, India");
            //performing copy action 
            KandMDrivers.actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            KandMDrivers.actions.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control).Perform();
            IWebElement Element = KandMDrivers.driver.FindElement(By.Id("permanentAddress"));
            //scrolling to the webelement by using java executor script
            ScrollingToElement(Element);
            Element.Click();
            //performing paste action
            KandMDrivers.actions.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Perform();
            KandMDrivers.driver.FindElement(By.Id("submit")).Click();
        }
        public static void ScrollingToElement(IWebElement webElement)
        {
            IJavaScriptExecutor jsp = KandMDrivers.driver as IJavaScriptExecutor;
            jsp.ExecuteScript("arguments[0].scrollIntoView();", webElement);
        }
        public static void CopyPasteVerifyAndScreenshot()
        {
            KandMDrivers.wait.Until(ExpectedConditions.ElementIsVisible(By.Id("output")));
            string TextAfterSubmit = KandMDrivers.driver.FindElement(By.XPath("(//p[@class='mb-1'])[1]")).Text;
            if(TextAfterSubmit.Contains("rasool"))
            {
                CaptureScreenshot.TakeScreensot("CopyPasteAction");
            }
            else
            {
                Console.WriteLine("Action Unsuccessfull, Hence unable to capture Screenshot");
            }
            Assert.That(TextAfterSubmit.Contains("rasool"), Is.EqualTo(true));
        }
    }
}
