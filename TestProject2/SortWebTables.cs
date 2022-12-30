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
    public class SortWebTables
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

            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";

        }

        [Test]
        public void SortTable()
        {
            ArrayList a = new ArrayList();
            IWebElement pageSize = driver.FindElement(By.XPath("//select[@id='page-menu']"));
            SelectElement dropdown = new SelectElement(pageSize);
            dropdown.SelectByText("20");

            //step1 get all veggie names into array list A
            IList<IWebElement> veggies1 = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in veggies1)
            {
                a.Add(veggie.Text);

            }

            //step2 sort this array list
            foreach (String item in a)
            {
                TestContext.Progress.WriteLine("before sorting " + item);
            }

            //TestContext.Progress.WriteLine("after sorting");
            a.Sort();
            foreach (String item in a)
            {
                TestContext.Progress.WriteLine("after sorting " + item);
            }


            //step 3 click the column
            driver.FindElement(By.CssSelector("th[aria-label*= 'fruit name']")).Click();

            //step 4 get all veggie names into array list B
            ArrayList b = new ArrayList();
            IList<IWebElement> Sortedveggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in Sortedveggies)
            {
                b.Add(veggie.Text);
            }
            //arralist A to B = equal

            Assert.AreEqual(a, b);



        }
    }
}
