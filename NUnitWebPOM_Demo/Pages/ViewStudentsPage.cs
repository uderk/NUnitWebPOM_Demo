using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NUnitWebPOM_Demo.Pages
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";

        public IReadOnlyCollection<IWebElement> ListOfStudents => driver.FindElements(By.XPath("/html/body/ul"));

        public string[] GetStudentsList()
        {
            var students = this.ListOfStudents.Select(s => s.Text).ToArray();
            return students;
        }
    }

}


