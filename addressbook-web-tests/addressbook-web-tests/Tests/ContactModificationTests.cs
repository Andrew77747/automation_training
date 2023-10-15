using NUnit.Framework;
using System.Collections.Generic;

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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0] = contact; //TODO можно просто вставить объект целиком
            //oldContacts[0].Firstname = contact.Firstname;
            //oldContacts[0].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
