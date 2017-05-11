using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.PageObjects.Actions;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class UITests
    {
        [Test]
        public void CheckSiteLoad()
        {
            IWebDriver driver = BrowseHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(60));
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost:60634/Article/List");
            var logo = wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));
            Assert.AreEqual("SOFTUNI BLOG",logo.Text);

            driver.Quit();
        }
        [Test]
        public void RegisterUser()
        {
            IWebDriver driver = BrowseHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost:60634/Article/List");
            var RegButton = wait.Until(w => w.FindElement(By.Id("registerLink")));
            RegButton.Click();

            var Email = wait.Until(w => w.FindElement(By.Id("Email")));
            Email.SendKeys("xrissti@gmail.com");

            var FullName = driver.FindElement(By.Id("FullName"));
            FullName.SendKeys("Hristina Petkova");

            var Password = driver.FindElement(By.Id("Password"));
            Password.SendKeys("12345678");

            var ConfirmPassword = driver.FindElement(By.Id("ConfirmPassword"));
            ConfirmPassword.SendKeys("Hristina Petkova");


    //        Assert.AreEqual("SOFTUNI BLOG", regButton.Text);

            driver.Quit();
        }

    }
    
}
