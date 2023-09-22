using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseUrl;

        public NavigationHelper(IWebDriver driver, string baseUrl) : base(driver)
        {
            this.baseUrl = baseUrl;
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
