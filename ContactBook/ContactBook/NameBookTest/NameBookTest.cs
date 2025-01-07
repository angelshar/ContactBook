
using System;
using System.Security.AccessControl;
using NameBook;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

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


            string validEmail = contact.Email;


            // Act
            bool isValid = emailvalidator.IsValidEmail(validEmail);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(isValid, "Expected the email to be valid.");
        }

        [TestMethod]
        public void VerifyIfEmailIsInvalidEmail()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();
            var phone = new Phone
            {
                PhoneNumber = 1234567890
            };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doeexample.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            var emailvalidator = new EmailValidator { };

            string invalidEmail = contact.Email;

            // Act
            bool isInvalid = emailvalidator.IsValidEmail(invalidEmail);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(isInvalid, "Expected the email to be invalid.");
        }

        [TestMethod]
        public void ChangeContactName()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();
            var phone = new Phone
            {
                PhoneNumber = 1234567890
            };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doeexample.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            individualContact[phone].FullName = "Harvey";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Harvey", individualContact[phone].FullName); // Validate the contact's Name


            contact.FullName = "Isaac";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Isaac", individualContact[phone].FullName); // Validate the contact's Name

        }

        [TestMethod]
        public void ChangeContactPhoneNumber()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();
            var phone = new Phone
            {
                PhoneNumber = 1234567890
            };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doeexample.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            phone.PhoneNumber = 0987654321;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("098-765-4321", phone.GetFormattedPhoneNumber()); // Validate the contact's PhoneNumber

        }

        [TestMethod]
        public void ChangeContactEmail()
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

            individualContact[phone].Email = "Harvey@google.com";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Harvey@google.com", individualContact[phone].Email); // Validate the contact's Name


            contact.Email = "Isaac@gmail.com";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Isaac@gmail.com", individualContact[phone].Email); // Validate the contact's Name
        }

        [TestMethod]
        public void RemoveContact()
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

            individualContact.Remove(phone);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(individualContact);
            Xunit.Assert.Empty(individualContact);

        }

        [TestMethod]
        public void SearchByContactName()
        {
            Dictionary<Phone, FullContactInfo> multiContact = new Dictionary<Phone, FullContactInfo>();
            var phoneJohn = new Phone
            {
                PhoneNumber = 1234567890
            };
            var contactJohnInfo = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phoneJohn.GetFormattedPhoneNumber()
            };

            var phoneIsaac = new Phone
            {
                PhoneNumber = 0987654321
            };
            var contactIsaacInfo = new FullContactInfo
            {
                FullName = "Isaac Perez",
                Email = "isaac.perez@example.com",
                PhoneNumber = phoneJohn.GetFormattedPhoneNumber()
            };

            var phoneHarvey = new Phone
            {
                PhoneNumber = 1231231234
            };
            var contactHarveyInfo = new FullContactInfo
            {
                FullName = "Ash Harvey",
                Email = "ash.harvey@example.com",
                PhoneNumber = phoneJohn.GetFormattedPhoneNumber()
            };

            multiContact.Add(phoneJohn, contactJohnInfo);
            multiContact.Add(phoneIsaac, contactIsaacInfo);
            multiContact.Add(phoneHarvey, contactHarveyInfo);


        }

        [TestMethod]
        public void AddMultipleContacts()
        {
            Dictionary<Phone, FullContactInfo> multiContact = new Dictionary<Phone, FullContactInfo>();
            var phoneJohn = new Phone
            {
                PhoneNumber = 1234567890
            };
            var contactJohnInfo = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phoneJohn.GetFormattedPhoneNumber()
            };

            var phoneIsaac = new Phone
            {
                PhoneNumber = 0987654321
            };
            var contactIsaacInfo = new FullContactInfo
            {
                FullName = "Isaac Perez",
                Email = "isaac.perez@example.com",
                PhoneNumber = phoneJohn.GetFormattedPhoneNumber()
            };

            var phoneHarvey = new Phone
            {
                PhoneNumber = 1231231234
            };
            var contactHarveyInfo = new FullContactInfo
            {
                FullName = "Ash Harvey",
                Email = "ash.harvey@example.com",
                PhoneNumber = phoneJohn.GetFormattedPhoneNumber()
            };

            multiContact.Add(phoneJohn, contactJohnInfo);
            multiContact.Add(phoneIsaac, contactIsaacInfo);
            multiContact.Add(phoneHarvey, contactHarveyInfo);


            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(multiContact.ContainsKey(phoneJohn)); // Check that the key exists
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("John Doe", multiContact[phoneJohn].FullName); // Validate the contact's Name
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("john.doe@example.com", multiContact[phoneJohn].Email); // Validate the contact's Email
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("123-456-7890", phoneJohn.GetFormattedPhoneNumber()); // Validate the contact's PhoneNumber



            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(multiContact.ContainsKey(phoneIsaac)); // Check that the key exists
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Isaac Perez", multiContact[phoneIsaac].FullName); // Validate the contact's Name
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("isaac.perez@example.com", multiContact[phoneIsaac].Email); // Validate the contact's Email
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("098-765-4321", phoneIsaac.GetFormattedPhoneNumber()); // Validate the contact's PhoneNumber


            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(multiContact.ContainsKey(phoneHarvey)); // Check that the key exists
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Ash Harvey", multiContact[phoneHarvey].FullName); // Validate the contact's Name
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("ash.harvey@example.com", multiContact[phoneHarvey].Email); // Validate the contact's Email
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("123-123-1234", phoneHarvey.GetFormattedPhoneNumber()); // Validate the contact's PhoneNumber


        }
        [TestMethod]
        public void SearchIfContactNameExists()
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
        }
        [TestMethod]
        public void SearchByPhoneNumber()
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
        }
        [TestMethod]
        public void SearchByEmail()
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
        }
        [TestMethod]
        public void SortContactNamesByAlphanumeric()
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
