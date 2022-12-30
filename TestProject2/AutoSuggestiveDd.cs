using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using System.Threading;

namespace TestProject2
{
    public class Tests1
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
        public void AutoSuggestiveDd()
        {
            
            IWebElement inputSuggession = driver.FindElement(By.Id("autocomplete"));

            inputSuggession.SendKeys("Ind");
           // driver.FindElement(By.Id("autocomplete")).SendKeys("Ind");
            Thread.Sleep(3000);

            //putting all the values that are in .ui-menu-item div in a array list 
            IList<IWebElement> autoSuggessions = driver.FindElements(By.CssSelector(".ui-menu-item div"));

            //finding the text that equals India and clicking it
            foreach  (IWebElement option in autoSuggessions)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }
                
            }
            //to get value of text that may no  longer be there do this
            TestContext.Progress.WriteLine( inputSuggession.GetAttribute("value") ); 





        }
    }
}
