using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject2
{
    public class JavaAlert
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
        public void AlertPopUoTest()
        {
            String name = "Dexter";
            IWebElement inputName = driver.FindElement(By.XPath("//input[@id='name']"));
            IWebElement confirmBtn = driver.FindElement(By.XPath("//input[@id='confirmbtn']"));



            inputName.SendKeys("Dexter");
            confirmBtn.Click();

            String alertText = driver.SwitchTo().Alert().Text;


            //Accept will click okay and Dimiss() will click cancel
            driver.SwitchTo().Alert().Accept();

            //If you want to type in the aletbox do this
            // driver.SwitchTo().Alert().SendKeys("");


            //To test that the strings match do this

            StringAssert.Contains(name, alertText);


        }
    }
}
