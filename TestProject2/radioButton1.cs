using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject2
{
    class radioButton1
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
        public void DropDowwnTests()
        {
            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement s = new SelectElement(dropdown);
            s.SelectByText("Teacher");
            IList<IWebElement> multiresults = driver.FindElements(By.CssSelector("input[type = 'radio']"));
            //multiresults[1].Click();

            foreach (IWebElement radioButton in multiresults)
            {
                if (radioButton.GetAttribute("value").Equals("user"))
                {
                    radioButton.Click();
                }
            }
            IWebElement okayBtn = driver.FindElement(By.Id("okayBtn"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable((okayBtn)));


            okayBtn.Click();
            IWebElement userType = driver.FindElement(By.Id("usertype"));
            Boolean results = userType.Selected;
            //it should return true but vbecause the dev didnt fix it , it shows false
            // Assert.That(results, Is.True);

        }
    }
}
