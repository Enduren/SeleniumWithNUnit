using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject2
{
    class Locators
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
        /*
         * Locators: Xpath,Css, id,Classname, tagname
         */
        [Test]  //for each test there needs to be a setup and a tear down
        public void LocatorIdentification()
        {

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            // driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("learning1");
            //By CSS Selector  tagname[attribute = 'value']
            //driver.FindElement(By.CssSelector("input[name='signin']")).Click();
            //ByXpath  //tagName[@attribute='value']
            //CSS Abs path   .text-info span:nth-child(1) input
            //or  .text-info span input
            //and for Xpath  //label[@class='text-info']/span/input
            //another way to write xpath by staring to parent and end to child(where the element you want is )
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();


            //Explicit wait
            IWebElement signInWait = driver.FindElement(By.XPath("//input[@name='signin']"));
            signInWait.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue((signInWait), "Sign In"));

            //Thread.Sleep(3000);
            //text-center text-white
            String errMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errMessage);
            //by Link text
            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            // identify link text and check if the url is what i am expecting
            String hrefAttr = link.GetAttribute("href");
            String expectedURL = "https://rahulshettyacademy.com/documents-request";
            ////div[@class='form-group'][5]/label/span/input
            //driver.FindElement(By.CssSelector("div[class='form-group'] :nth-child(5) label span input");


            Assert.AreEqual(expectedURL, hrefAttr);


        }


        [TearDown]
        public void CloseBrowser()
        {
            //driver.Quit(); //CLOSES ALL WINDOWS
        }
    }
}
