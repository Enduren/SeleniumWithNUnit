using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace TestProject2
{
    internal class Frames1
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            //Methods - getUrl, click-

            //for chrome browser setup
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            // Implicit wait can be declared globally
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Have your window at fullscreen
            driver.Manage().Window.Maximize();

            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";

        }


        [Test]
        public void FrameTest1()
        {
            IWebElement coures = driver.FindElement(By.Id("courses-iframe"));

            //scroll using avaScriptExecutor
            IJavaScriptExecutor jS = (IJavaScriptExecutor)driver;

            //this is what to use when you want to scroll make sure you give the element at the end of the arguement
            jS.ExecuteScript("arguments[0].scrollIntoView(true);",coures);


            //give frame id(courses-iframe),name(iframe-name), or index to get the iframe
            driver.SwitchTo().Frame(coures);

            //click on all access plan of the iframe
            driver.FindElement(By.LinkText("All Access Plan")).Click();

            //this will print out iframe 
            Thread.Sleep(8000);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
           // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
          //  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("h1")));

            //to exit out of Iframe do thos
            driver.SwitchTo().DefaultContent();

            //now that you exit iframes this will print out elements of the whole page
            
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);










        }
    }
}
