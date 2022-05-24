using NUnit.Framework;
using NUnitWebPOM_Demo.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NUnitWebPOM_Demo.Tests
{
    public class HomePageTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.driver = new ChromeDriver(@"D:\venko\QAautomation\NUnitWebPOM_Demo\NUnitWebPOM_Demo\bin\Debug\netcoreapp2.1");
            wait = new WebDriverWait(driver,TimeSpan.FromSeconds(15));
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
        [Test]
        public void TestHomePageLinks()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            // homePage.PageUrl() ! Attention, in homePage Class is overriden 
          //  Thread.Sleep(15000); was only for debuging purpose , now wait implemented 
            Assert.AreEqual(homePage.GetPageUrl(), driver.Url);
            Assert.That("Students Registry", Is.EqualTo(homePage.GetPageHeading()));
            Assert.That(homePage.GetPageTitle, Is.EqualTo("MVC Example"));
        }

        [Test]
        public void TestHomePageHomeLink()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.HomeLink.Click();
            Assert.That(homePage.GetPageTitle, Is.EqualTo("MVC Example"));
        }

        [Test]
        public void TestHomePageStudentCount()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.HomeLink.Click();
            Assert.Greater(homePage.GetStudentCount(), 0);
        }

        [Test]
        public void TestHomePageAddStudentLink()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.AddStudentLink.Click();
            var addStudent = new AddStudentPage(driver);
            Assert.That(driver.Url, Is.EqualTo(addStudent.GetPageUrl()));
            Assert.That(addStudent.GetPageTitle,Is.EqualTo("Add Student"));
        }

        [Test]
        public void TestHomePageViewStudentsLink()
        {
            var homePage = new HomePage(driver);
            homePage.Open();
            homePage.AddStudentLink.Click();
            var viewStudent = new ViewStudentsPage(driver);
            Assert.That(driver.Url, Is.EqualTo(viewStudent.GetPageUrl()));
            Assert.That(viewStudent.GetPageTitle, Is.EqualTo("Add Student"));
        }
    }
}
