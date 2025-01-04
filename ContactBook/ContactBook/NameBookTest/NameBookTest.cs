
using System;
using System.Security.AccessControl;
using NameBook;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NameBookTest
{
    [TestClass]
    public sealed class NameBookTest
    {
        [TestMethod]
        public void AccessInitializedEmptyIndividualContact()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(individualContact);
            Xunit.Assert.Empty(individualContact);

        }
        [TestMethod]
        public void AddIndividualContactData()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();
            var phone = new Phone
            {
                PhoneNumber = 1234567890
            };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            Xunit.Assert.Single(individualContact); // Check that the dictionary contains exactly one item
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(individualContact.ContainsKey(phone)); // Check that the key exists
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("John Doe", individualContact[phone].FullName); // Validate the contact's Name
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("john.doe@example.com", individualContact[phone].Email); // Validate the contact's Email
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("123-456-7890", phone.GetFormattedPhoneNumber()); // Validate the contact's PhoneNumber
        }
        [TestMethod]
        public void VerifyIfEmailIsAValidEmail()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();
            var phone = new Phone
            {
                PhoneNumber = 1234567890
            };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            var emailvalidator = new EmailValidator { };
            emailvalidator.IsValidEmail(individualContact[phone].Email);

        }
        [TestMethod]
        public void ChangeContactName()
        {

        }
        [TestMethod]
        public void ChangeContactPhoneNumber()
        {
        }
        [TestMethod]
        public void ChangeContactEmail()
        {
        }
        [TestMethod]
        public void RemoveContactName()
        {
        }
        [TestMethod]
        public void RemoveContactPhoneNumber()
        {
        }
        [TestMethod]
        public void RemoveContactEmail()
        {
        }
        [TestMethod]
        public void SearchByContactName()
        {
        }
        [TestMethod]
        public void SearchIfContactNameExists()
        {
        }
        [TestMethod]
        public void SearchByPhoneNumber()
        {
        }
        [TestMethod]
        public void SearchByEmail()
        {
        }
        [TestMethod]
        public void SortContactNamesByAlphanumeric()
        {
        }

        //copilot extra tests
        /*
        VerifyUniqueContactNames
        VerifyUniquePhoneNumbers
        VerifyUniqueEmails
        CheckContactCount
        VerifyNameUpdateReflectsInAllReferences
        VerifyPhoneNumberUpdateReflectsInAllReferences
        VerifyEmailUpdateReflectsInAllReferences
        VerifyErrorOnAddingInvalidContactData
        VerifyErrorOnDuplicateContactAddition
        SearchForNonExistentContact
        VerifyAlphabeticalSortingCaseInsensitive
        BackupAndRestoreContacts?
         */
    }
}
