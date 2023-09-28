using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddContactPage();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int index, ContactData contact)
        {
            InitContactModification(index);
            FillContactForm(contact);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            SelectContact(index);
            InitRemoveContact();
            //TODO не всегда удаляет, надо дожидаться алерта
            AcceptAlert();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            //TODO это правильный селектор и его надо вынести в старый код
            driver.FindElement(By.XPath($"//*[@name='MainForm']//tr[{index + 1}]/td[8]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            //TODO это правильный селектор и его надо вынести в старый код
            driver.FindElement(By.XPath($"//*[@name='MainForm']//tr[{index + 1}]/td[1]")).Click();
            return this;
        }

        public ContactHelper InitRemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            //TODO здесь три элемента по такому селектору, а в старом коде два вместе с кнопкой Delete //input[@name='update'][1]
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }
    }
}