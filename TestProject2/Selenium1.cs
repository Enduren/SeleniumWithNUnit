using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject2
{
    class Selenium1_test
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            //Methods - getUrl, click-
            //chromedriver.exce is needed
            //or use WebDriverManager which will tell selenium what chrome verison you have
            //for Firefox browser setup
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //driver = new FirefoxDriver();

            //for Edge browser setup
            //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            // driver = new EdgeDriver();

            //for chrome browser setup
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            //Have your window at fullscreen
            driver.Manage().Window.Maximize();

        }
        /*
         * Test house the rest of the code that has what to do in the 
         * browser
         * URL
         * implicit payment 
         */
        [Test]  //for each test there needs to be a setup and a tear down
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
            //driver.Close();//CLOSES ONE WINDOW
            //driver.Quit(); CLOSES ALL WINDOWS
        }


        [TearDown]
        public void CloseBrowser()
        {
            //driver.Quit(); //CLOSES ALL WINDOWS
        }

    }
}
