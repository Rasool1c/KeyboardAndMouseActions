using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras;
//using SeleniumExtras.BaseClass.waitHelpers;
using KeyboardAndMouseActions.Utility;
using KeyboardAndMouseActions.Drivers;
using SeleniumExtras.WaitHelpers;

namespace KeyboardAndMouseActions.Pages
{
    public class DragAndDrop
    {
        public static void DragAndDropMethod()
        {
            KandMDrivers.driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            KandMDrivers.wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));           
            var Source = KandMDrivers.driver.FindElement(By.Id("draggable"));
            var Target = KandMDrivers.driver.FindElement(By.Id("droppable"));
            //performing drag and drop using actions
            KandMDrivers.actions.DragAndDrop(Source, Target).Perform();
        }
        public static void DragandDropVerifyAndScreenshot()
        {
            var DropElement = KandMDrivers.driver.FindElement(By.Id("droppable"));
            KandMDrivers.wait.Until(ExpectedConditions.TextToBePresentInElement(DropElement, "Dropped!"));
            var Text = DropElement.Text;
            if(Text.Contains("Dropped!"))
            {
                CaptureScreenshot.TakeScreensot("Drag&DropAction");
            }
            else
            {
                Console.WriteLine("Action Unsuccessfull, Hence unable to capture Screenshot");
            }
        }
    }
}
