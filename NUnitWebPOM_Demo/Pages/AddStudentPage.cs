using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace NUnitWebPOM_Demo.Pages
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";

        public IWebElement StudentCount => driver.FindElement(By.CssSelector("body>p>b"));

        public IWebElement NameField => driver.FindElement(By.Id("name"));

        public IWebElement EmailField => driver.FindElement(By.Id("email"));

        public IWebElement AddButton => driver.FindElement(By.XPath("/html/body/form/button"));

        public IWebElement ErrorMsg => driver.FindElement(By.XPath("/html/body/div"));

        public void RegisterStudent(string name, string mail)
        {
           this.NameField.SendKeys(name);
           this.EmailField.SendKeys(mail);
           this.AddButton.Click();
        }

        public string GetErrorMsg()
        {
            return ErrorMsg.Text;
        }

    }

}


