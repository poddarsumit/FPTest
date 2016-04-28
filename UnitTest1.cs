using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTests
{
    [TestClass]
    public class Untitled
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;

        [TestInitialize]
        public void SetupTest()
        {
            //driver = new FirefoxDriver();
            //baseURL = "https://www.fisherpaykel.com/nz.html";
            //verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            try
            {
                //Quit browser while exiting
                driver.Quit();
                Console.WriteLine("Test Ending");
            }
            catch (Exception e)
            {
                // Ignore errors if unable to close the browser
                Console.WriteLine("Test Ending but unable to close the browser" + e.InnerException.ToString());
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TestViaSearch()
        {
            string homePage = "https://www.fisherpaykel.com/nz.html";
            FirefoxDriver driver = new FirefoxDriver();
            //This can be a timeout setting in a config file - from requirements
            //How many seconds to wait to conclude that the page is unresponsive
            //Setting it to 5 seconds
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            FisherPaykelPageObject fpObject = new FisherPaykelPageObject();
            fpObject.openPage(homePage, driver);
            verificationErrors = new StringBuilder();

            //Click on search icon
            fpObject.ClickSearchIcon(driver);
            //Enter search term
            fpObject.EnterSearchTerm("RS90AU1", driver);
            //Click search
            fpObject.clickSearch(driver);
            //Ensure search page has the fridge listed
            Assert.IsTrue(fpObject.IsTextPresent("RS90AU1",driver));

            //Can either click linktext or can click image
            //fpObject.ClickLinkText("ActiveSmart™ Fridge 900mm French Door Slide -in with Ice & Water – Stainless Steel", driver);
            fpObject.ClickFridgeImage(driver);
            //Ensure search page has the fridge listed
            Assert.IsTrue(fpObject.IsTextPresent("RS90AU1", driver));

            //Click View All Specs
            //fpObject.ClickLinkText("View All Specs", driver);

            //Ensure that the dimensions for the fridge are showing
            //Assert.IsTrue(fpObject.IsTextPresent("1798", driver));
            //Assert.IsTrue(fpObject.IsTextPresent("896", driver));
            //Assert.IsTrue(fpObject.IsTextPresent("606", driver));
            
        }

        [TestMethod]
        //Navigation via Kitchen -> Cool -> Built in Refrigerator
        public void TestViaNavigation()
        {
            string homePage = "https://www.fisherpaykel.com/nz.html";
            FirefoxDriver driver = new FirefoxDriver();
            //This can be a timeout setting in a config file - from requirements
            //How many seconds to wait to conclude that the page is unresponsive
            //Setting it to 5 seconds
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            FisherPaykelPageObject fpObject = new FisherPaykelPageObject();
            fpObject.openPage(homePage, driver);
            verificationErrors = new StringBuilder();
            //reuse common functions in the page object
            //fpObject.ClickLinkText("Kitchen", driver); - opens kitchen in a new page
            driver.FindElement(By.XPath("//div[@id='footer-top']/div/div/div/div[2]/a/h6")).Click();
            //Click on cool
            fpObject.ClickCool(driver);
            //Click on Built in Refrigerator image
            fpObject.ClickBuiltInRefrigeratorImage(driver);
            //Ensure search page has the fridge listed
            Assert.IsTrue(fpObject.IsTextPresent("RS90AU1", driver),"Failed to locate the element");
            //Click on the image
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@id='wrap']/div[3]/div/div[3]/div/div[2]/div/div/a/img")).Click();
            System.Threading.Thread.Sleep(2000);
            //Click on View All Specs
            fpObject.ClickLinkText("View All Specs", driver);
            
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }


        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
