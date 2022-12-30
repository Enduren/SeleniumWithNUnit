﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject2
{
    class Sigine2e1
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
        public void E2ETests()
        {
            String[] execptedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new String[2];
            IWebElement username = driver.FindElement(By.Id("username"));
            IWebElement password = driver.FindElement(By.Id("password"));
            IWebElement terms = driver.FindElement(By.Id("terms"));
            IWebElement signIn = driver.FindElement(By.Id("signInBtn"));

            username.SendKeys("rahulshettyacademy");
            password.SendKeys("learning");
            terms.Click();
            signIn.Click();

            IWebElement checkOut = driver.FindElement(By.PartialLinkText("Checkout"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            //put the elements that are in "app-card" in a list
            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {

                if (execptedProducts.Contains((product.FindElement(By.CssSelector(".card-title a")).Text)))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();

                }
                //TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }

            checkOut.Click();

            //verify that the phones selected are iphone x and blackberry

           IList <IWebElement> CheckOutCarts = driver.FindElements(By.CssSelector("h4 a"));

            //  Assert.AreEqual(execptedProducts, PhoneSelected);

            for (int i = 0; i < CheckOutCarts.Count; i++)
            {
                actualProducts[i] = CheckOutCarts[i].Text;

            }

            Assert.AreEqual( execptedProducts, actualProducts);


            // finishing checking process 
           IWebElement checkOut2= driver.FindElement(By.XPath("//button[@class='btn btn-success']"));

           // WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            //wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            checkOut2.Click();



            IWebElement inputSuggession = driver.FindElement(By.XPath("//input[@id='country']"));
            inputSuggession.SendKeys("Ind");

            //wait until you see India
           // signInWait.Click();
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();
            //Thread.Sleep(8000);

            //click I agree checkbox
            IWebElement agree = driver.FindElement(By.XPath("//label[@for='checkbox2']"));
            agree.Click();

            //click the purchase button
            driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();

            // confirmText = (Success! Thank you!)

            String confirmText = driver.FindElement(By.CssSelector(".alert.alert-success.alert-dismissible")).Text;
           
            //verify Success message is in the the confirmText =(Success! Thank you!)
            StringAssert.Contains("Success",confirmText);
            


            /*
            //putting all the values that are in .ui-menu-item div in a array list 
            IList<IWebElement> autoSuggessions = driver.FindElements(By.XPath("//div[@class='suggestions']"));

            //finding the text that equals India and clicking it
            foreach (IWebElement option in autoSuggessions)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }

            }
            IWebElement agree = driver.FindElement(By.XPath("//label[@for='checkbox2']"));
            agree.Click();

            driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();

            */





        }
    }
}
