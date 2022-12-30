using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace TestProject2
{
    internal class drangNDrop
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

            driver.Url = "https://demoqa.com/droppable/";

        }


        [Test]
        public void ActionTest1()
        {

            Actions a = new Actions(driver);
            //use this to move your mouse to the element and Perform() activates this action
           // a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            Thread.Sleep(3000);
            IWebElement drag = driver.FindElement(By.XPath("//div[@id='draggable']"));
            IWebElement drop = driver.FindElement(By.XPath("//div[@id='droppable']"));
            //about.Click();

            //YOU CAN ALSO USE aCTION TO CLICK THE ELEMENT AS WELL
            a.DragAndDrop(drag,drop).Perform();







        }
    }
}
