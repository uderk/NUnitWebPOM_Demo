using NUnit.Framework;
using NUnitWebPOM_Demo.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace NUnitWebPOM_Demo.Tests
{
    public class ViewStudentsTests
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
        public void TestViewStudentsPageHomePageLink()
        {
            var viewStudent = new ViewStudentsPage(driver);
            viewStudent.Open();
            viewStudent.HomeLink.Click();
            var homePage = new HomePage(driver);
            Assert.AreEqual(homePage.GetPageUrl(), driver.Url);
            Assert.That("Students Registry", Is.EqualTo(homePage.GetPageHeading()));
            Assert.That(homePage.GetPageTitle, Is.EqualTo("MVC Example"));
        }

        [Test]
        public void ViewStudentHeadingAndTitle()
        {
            var viewStudent = new ViewStudentsPage(driver);
            viewStudent.Open();
            Assert.That(viewStudent.GetPageHeading(), Is.EqualTo("Registered Students"));
            Assert.That(viewStudent.GetPageTitle(), Is.EqualTo("Students"));
        }
 
        [Test]
        public void TestViewStudentsPageAddStudentLink()
        {
            var viewStudent = new ViewStudentsPage(driver);
            viewStudent.Open();
            viewStudent.AddStudentLink.Click();
            var addStudent = new AddStudentPage(driver);
            Assert.That(driver.Url, Is.EqualTo(addStudent.GetPageUrl()));
            Assert.That(addStudent.GetPageTitle,Is.EqualTo("Add Student"));
        }
        
        [Test]
        public void TestAddedStudentsAreShown()
        {
            var viewStudent = new ViewStudentsPage(driver);
            viewStudent.Open();
            string[] listOfStudents = viewStudent.GetStudentsList();

            foreach (string student in listOfStudents)
            {
                Assert.IsTrue(student.IndexOf("(")>0);
                Assert.IsTrue(student.LastIndexOf(")") == student.Length - 1);
            }
        }
    }
}
