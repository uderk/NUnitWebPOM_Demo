using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitWebPOM_Demo.Pages
{
   public  class BasePage
    {
        protected readonly IWebDriver driver;
        public virtual string PageUrl { get; }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //with lambda expression
        public IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));

        //without lambda expression. "Standart" function, but must have same behaviour
        public IWebElement ViewStudentsLink()
        {
            return driver.FindElement(By.LinkText("View Students"));
        }
        public IWebElement AddStudentLink => driver.FindElement(By.LinkText("Add Student"));

        public IWebElement PageHeading => driver.FindElement(By.CssSelector("body>h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(this.PageUrl);
        }

        public bool isOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageUrl()
        {
            return driver.Url;
        }

        public string GetPageHeading()
        {
            return PageHeading.Text;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
