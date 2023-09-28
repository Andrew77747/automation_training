using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("Сергей", "Сергеев");
            contact.Middlename = "Сергеевич";

            app.Contacts.Modify(1, contact);
        }
    }
}
