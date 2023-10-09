using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Иван", "Иванов");
            contact.Middlename = "Иванович";

            app.Contacts.Create(contact);
        }
    }
}
