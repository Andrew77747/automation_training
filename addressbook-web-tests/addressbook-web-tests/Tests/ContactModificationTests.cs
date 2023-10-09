using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.CreateContactIfNotExist();

            ContactData contact = new ContactData("Сергей", "Сергеев");
            contact.Middlename = "Сергеевич";

            app.Contacts.Modify(1, contact);
        }
    }
}
