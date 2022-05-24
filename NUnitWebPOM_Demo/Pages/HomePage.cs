using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace NUnitWebPOM_Demo.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co";

        public IWebElement StudentCount => driver.FindElement(By.CssSelector("body>p>b"));

        public int GetStudentCount()
        {
            return int.Parse(StudentCount.Text);
        }
    }

}


