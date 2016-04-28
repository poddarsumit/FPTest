using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class FisherPaykelPageObject
    {
        //Can have all the elements listed here to make it easy to modify
        //public string searchIcon = "//div[@id='top-navbar-collapse']/div/div/div[4]/div[2]/ul/li/a/span";
        public void openPage(string homepage, FirefoxDriver driver)
        {

            Console.WriteLine("Navigating to Page" + homepage);
            driver.Navigate().GoToUrl(homepage);
            
        }

        public void ClickSearchIcon(FirefoxDriver driver)
        {
            Console.WriteLine("Clicking Search Icon on page");
            //Click on search icon
            driver.FindElement(By.XPath("//div[@id='top-navbar-collapse']/div/div/div[4]/div[2]/ul/li/a/span")).Click();
            driver.FindElement(By.XPath("//form[@id='global-search']/div/input")).Click();
            //Erase any text if already present
            driver.FindElement(By.XPath("//form[@id='global-search']/div/input")).Clear();
           
        }

        public void EnterSearchTerm(string searchTerm, FirefoxDriver driver)
        {
            Console.WriteLine("Entering search term" + searchTerm);
            driver.FindElement(By.XPath("//form[@id='global-search']/div/input")).SendKeys(searchTerm);
        }
        public void clickSearch(FirefoxDriver driver)
        {
            Console.WriteLine("Clicking Search");
            driver.FindElement(By.XPath("//form[@id='global-search']/div[2]/input")).Click();
        }

        public bool IsTextPresent(string text, FirefoxDriver driver)
        {
            Console.WriteLine("Ensuring text present " + text);
            IWebElement bodyTag = driver.FindElement(By.TagName("body"));
            return  bodyTag.Text.Contains(text);
            
        }

        public void ClickFridgeImage(FirefoxDriver driver)
        {
            Console.WriteLine("Clicking fridge image");
            driver.FindElement(By.XPath("//div[@id='wrap']/div[2]/div/div/div[2]/div/div/div/div/a/img")).Click();
        }
        public void ClickLinkText(string linkText, FirefoxDriver driver)
        {
            Console.WriteLine("Click Link Text" + linkText);
            WebDriverWait wait = new WebDriverWait(driver,new TimeSpan(0,0,30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(linkText)));
            driver.FindElement(By.LinkText(linkText)).Click();
        }

        public void ClickCool(FirefoxDriver driver)
        {
            driver.FindElement(By.XPath("//div[@id='wrap']/div[3]/div/div[3]/div/div/div/div/h2/a")).Click();
        }

        public void ClickBuiltInRefrigeratorImage(FirefoxDriver driver)
        {
            driver.FindElement(By.XPath("//div[@id='wrap']/div[4]/div/div/a/img")).Click();
        }
    }
}
