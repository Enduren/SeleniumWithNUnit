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
    internal class Child1
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

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }


        [Test]
        public void ChildTest1()
        {
            IWebElement freeAccess = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));

            freeAccess.Click();

            //getting the count of window handles which should be 2
            Assert.AreEqual(2, driver.WindowHandles.Count);

            //naming the childWindow which is WindowHandles[1
            String childWindowName = driver.WindowHandles[1];

            //this is how to swith to child window
            driver.SwitchTo().Window(childWindowName);

            //print the email of the child window by doing this
            IWebElement childEmail = driver.FindElement(By.CssSelector(".red"));


            TestContext.WriteLine(childEmail.Text);
            String text = childEmail.Text;
            //String[] splittedText = text.Split("at");

            








        }
    }

}
