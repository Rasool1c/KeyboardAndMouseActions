using KeyboardAndMouseActions.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardAndMouseActions.Utility
{
    internal class CaptureScreenshot
    {
        public static void TakeScreensot(string name)
        {

            ((ITakesScreenshot)KandMDrivers.driver).GetScreenshot().SaveAsFile(@"C:\Users\mindtree2301\source\repos\KeyboardAndMouseActions\Screenshots\" + name + ".png");
        }
    }
}
