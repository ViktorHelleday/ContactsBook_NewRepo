using ContactsBook.Services;
using ContactsBook.Models;

namespace ConsoleApp.Test__xUnit
{
    public class ContactsBook_Tests
    {
        private MenuManager menuManager;
        private Contact contact;

        public ContactsBook_Tests()
        {
            // Arrange
            menuManager = new MenuManager();
            contact = new Contact();
        }

        [Fact]
        public void Should_Add_Contact()
        {
            // Act
            menuManager.contacts.Add(contact);  
            // Assert
            Assert.Single(menuManager.contacts);
        }

        [Fact]
        public void Should_Remove_Contact()
        {
            // Arrangee
            menuManager.contacts.Add(contact);
            menuManager.contacts.Add(contact);

            // Act
            menuManager.contacts.Remove(contact);

            //Assert
            Assert.Single(menuManager.contacts);
        }
    }
}