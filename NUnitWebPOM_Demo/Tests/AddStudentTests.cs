using NUnit.Framework;
using NUnitWebPOM_Demo.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;


namespace NUnitWebPOM_Demo.Tests
{
    public class AddStudentTests
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
        public void TestAddStudentsPageHomePageLinks()
        {
            var addStudent = new AddStudentPage(driver);
            addStudent.Open();
            addStudent.HomeLink.Click();
            var homePage = new HomePage(driver);
            Assert.AreEqual(homePage.GetPageUrl(), driver.Url);
            Assert.That("Students Registry", Is.EqualTo(homePage.GetPageHeading()));
            Assert.That(homePage.GetPageTitle, Is.EqualTo("MVC Example"));
        }

        [Test]
        public void AddStudentHeadingTitle()
        {
            var addStudent = new AddStudentPage(driver);
            addStudent.Open();
            Assert.That(addStudent.GetPageHeading(), Is.EqualTo("Register New Student"));
            Assert.That(addStudent.GetPageTitle(), Is.EqualTo("Add Student"));
        }
 
        [Test]
        public void TestAddStudentPageViewStudentLink()
        {
            var addStudent = new AddStudentPage(driver);
            addStudent.Open();
            addStudent.ViewStudentsLink().Click();
            var viewStudent = new ViewStudentsPage(driver);
            Assert.That(driver.Url, Is.EqualTo(viewStudent.GetPageUrl()));
            Assert.That(addStudent.GetPageTitle,Is.EqualTo("Students"));
        }

        [TestCase("veni","veni@bv.bg")]
        [TestCase("deni", "deni@bv.bg")]
        [TestCase("pesho", "pesho@bv.bg")]
        [TestCase("misho", "misho@bv.bg")]
        public void TestRegisterNewStudent(string name, string mail)
        {
            var addStudent = new AddStudentPage(driver);
            addStudent.Open();
            addStudent.RegisterStudent(name, mail);

            var viewStudent = new ViewStudentsPage(driver);
            string[] listOfStudents=viewStudent.GetStudentsList();//listOfStudents is actually string array. Do not confuse with datatype list
            string expectedResult = listOfStudents[listOfStudents.Length - 1];
            

            Assert.That(expectedResult.Contains(name) && expectedResult.Contains(mail));
        }

       [Test]
        public void TestTryToRegisterWithNoMail()
        {
            var addStudent = new AddStudentPage(driver);
            addStudent.Open();
            addStudent.NameField.SendKeys("someName");
            addStudent.AddButton.Click();
            string expectedMsg = "Cannot add student. Name and email fields are required!";

            Assert.That(expectedMsg, Is.EqualTo(addStudent.GetErrorMsg()));
        }
    }
}
