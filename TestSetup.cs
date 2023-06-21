using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FinalProjectSeluniom
{
    class TestSetup
    {
        //@"C:\Users\DANA\.nuget\packages\selenium.webdriver.chromedriver\104.0.5112.2900\driver\win32"         // ** instance of chrome ***//          //can use path after chromedriver or not 
        public static IWebDriver driver = new ChromeDriver();

        //url i do testing for it (link i would testing
        public static string url = "https://www.saucedemo.com/";



        //method for open website 
        public static void NavigateToURL(IWebDriver driver, string url)
        {
            //to show full screen (open chrome in window(height,width))            // driver.Manage().Window.Maximize();
            driver.Manage().Window.Size = new Size(1600, 900);
            //to navigate to url 
            driver.Navigate().GoToUrl(url);

        }


        //to highlight all step automation test & its static because can call it anywhere
        public static void HighlightElement(IWebDriver driver, IWebElement element)
        {
            //javascript execute in element               //casting element to javascript executor in driver(chrome ) to execute script 
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            // to execute specific code 
            executor.ExecuteScript("arguments[0].setAttribute('style','background:lightpink !important')", element);
            // to exit from style
            System.Threading.Thread.Sleep(1000);
            executor.ExecuteScript("arguments[0].setAttribute('style','border:solid 1px white !important')", element);

        }



    }
}
