using NameBook;

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
            var phone = new Phone { PhoneNumber = 1234567890 };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            // Update the phone number
            var newPhone = new Phone { PhoneNumber = 1111111111 };
            var updatedContact = new FullContactInfo
            {
                FullName = contact.FullName,
                Email = contact.Email,
                PhoneNumber = newPhone.GetFormattedPhoneNumber()
            };

            // Remove the old key and add the new key
            individualContact.Remove(phone);
            individualContact.Add(newPhone, updatedContact);

            // Validate the updated phone number
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("111-111-1111", newPhone.GetFormattedPhoneNumber());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(individualContact.ContainsKey(newPhone));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("John Doe", individualContact[newPhone].FullName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("john.doe@example.com", individualContact[newPhone].Email);
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
            // Arrange
            Dictionary<Phone, FullContactInfo> multiContact = new Dictionary<Phone, FullContactInfo>();
            var phoneJohn = new Phone { PhoneNumber = 1234567890 };
            var contactJohnInfo = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phoneJohn.GetFormattedPhoneNumber()
            };

            var phoneIsaac = new Phone { PhoneNumber = 987654321 };
            var contactIsaacInfo = new FullContactInfo
            {
                FullName = "Isaac Perez",
                Email = "isaac.perez@example.com",
                PhoneNumber = phoneIsaac.GetFormattedPhoneNumber()
            };

            multiContact.Add(phoneJohn, contactJohnInfo);
            multiContact.Add(phoneIsaac, contactIsaacInfo);

            // Act
            var searchedContact1 = SearchByMethods.SearchByContactName("John", multiContact);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, searchedContact1.Count);
            var firstMatch = searchedContact1[0];
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(phoneJohn, firstMatch.Key);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("John Doe", firstMatch.Value.FullName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("john.doe@example.com", firstMatch.Value.Email);

            var searchedContact2 = SearchByMethods.SearchByContactName("Isaac", multiContact);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, searchedContact2.Count);
            var secondMatch = searchedContact2[0];
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(phoneIsaac, secondMatch.Key);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Isaac Perez", secondMatch.Value.FullName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("isaac.perez@example.com", secondMatch.Value.Email);
        }

        [TestMethod]
        public void SearchByContactNameToFindSimilarContacts()
        {
            // Arrange
            Dictionary<Phone, FullContactInfo> multiContact = new Dictionary<Phone, FullContactInfo>();
            var phoneJohnDoe = new Phone { PhoneNumber = 1234567890 };
            var contactJohnDoeInfo = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phoneJohnDoe.GetFormattedPhoneNumber()
            };

            var phoneJohnPerez = new Phone { PhoneNumber = 987654321 };
            var contactJohnPerezInfo = new FullContactInfo
            {
                FullName = "John Perez",
                Email = "john.perez@example.com",
                PhoneNumber = phoneJohnPerez.GetFormattedPhoneNumber()
            };

            var phoneJaneDoe = new Phone { PhoneNumber = 1231231234 };
            var contactJaneDoeInfo = new FullContactInfo
            {
                FullName = "Jane Doe",
                Email = "jane.doe@example.com",
                PhoneNumber = phoneJaneDoe.GetFormattedPhoneNumber()
            };

            multiContact.Add(phoneJohnDoe, contactJohnDoeInfo);
            multiContact.Add(phoneJohnPerez, contactJohnPerezInfo);
            multiContact.Add(phoneJaneDoe, contactJaneDoeInfo);

            // Act
            var searchedContacts = SearchByMethods.SearchByContactName("John", multiContact);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, searchedContacts.Count); // Expecting 2 matches

            // Verify that all returned contacts are correct
            var expectedContacts = new List<KeyValuePair<Phone, FullContactInfo>>
    {
        new KeyValuePair<Phone, FullContactInfo>(phoneJohnDoe, contactJohnDoeInfo),
        new KeyValuePair<Phone, FullContactInfo>(phoneJohnPerez, contactJohnPerezInfo)
    };

            foreach (var expected in expectedContacts)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(
                    searchedContacts.Contains(expected),
                    $"Expected contact with name {expected.Value.FullName} and email {expected.Value.Email} was not found."
                );
            }
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

            // Act: Retrieve the contact information using the key
            var retrievedContact = individualContact[phone];

            // Assert: Validate that the retrieved contact matches the expected values
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(retrievedContact);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("John Doe", retrievedContact.FullName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("john.doe@example.com", retrievedContact.Email);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(phone.GetFormattedPhoneNumber(), retrievedContact.PhoneNumber);
        }

        [TestMethod]
        public void SearchByEmail()
        {
            // Arrange
            Dictionary<Phone, FullContactInfo> multiContact = new Dictionary<Phone, FullContactInfo>();
            var phoneJohn = new Phone { PhoneNumber = 1234567890 };
            var contactJohnInfo = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phoneJohn.GetFormattedPhoneNumber()
            };

            var phoneIsaac = new Phone { PhoneNumber = 987654321 };
            var contactIsaacInfo = new FullContactInfo
            {
                FullName = "Isaac Perez",
                Email = "isaac.perez@example.com",
                PhoneNumber = phoneIsaac.GetFormattedPhoneNumber()
            };

            multiContact.Add(phoneJohn, contactJohnInfo);
            multiContact.Add(phoneIsaac, contactIsaacInfo);

            // Act
            var searchedContact1 = SearchByMethods.SearchByContactEmail("john.doe@example.com", multiContact);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, searchedContact1.Count);
            var firstMatch = searchedContact1[0];
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(phoneJohn, firstMatch.Key);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("John Doe", firstMatch.Value.FullName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("john.doe@example.com", firstMatch.Value.Email);

            var searchedContact2 = SearchByMethods.SearchByContactEmail("isaac.perez@example.com", multiContact);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, searchedContact2.Count);
            var secondMatch = searchedContact2[0];
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(phoneIsaac, secondMatch.Key);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Isaac Perez", secondMatch.Value.FullName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("isaac.perez@example.com", secondMatch.Value.Email);
        }

        [TestMethod]
        public void SortContactNamesByAlphabeticalOrder()
        {
            Dictionary<Phone, FullContactInfo> multiContact = new Dictionary<Phone, FullContactInfo>();
            var phoneJohn = new Phone
            {
                PhoneNumber = 1234567890
            };
            var contactJohn = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phoneJohn.GetFormattedPhoneNumber()
            };

            var phoneIsaac = new Phone { PhoneNumber = 987654321 };
            var contactIsaacInfo = new FullContactInfo
            {
                FullName = "Isaac Perez",
                Email = "isaac.perez@example.com",
                PhoneNumber = phoneIsaac.GetFormattedPhoneNumber()
            };

            var phoneAsh = new Phone { PhoneNumber = 123123134 };
            var contactAshInfo = new FullContactInfo
            {
                FullName = "Ash Harvey",
                Email = "ash.harvey@example.com",
                PhoneNumber = phoneAsh.GetFormattedPhoneNumber()
            };


            multiContact.Add(phoneJohn, contactJohn);
            multiContact.Add(phoneIsaac, contactIsaacInfo);
            multiContact.Add(phoneAsh, contactAshInfo);

            var sortedContacts = SearchByMethods.SortContactBookByName(multiContact);

            // Extract just the names from the sorted list to check if they are in alphabetical order
            List<string> actualNames = new List<string>();
            foreach (var contact in sortedContacts)
            {
                actualNames.Add(contact.Value.FullName!);
            }

            // Expected sorted names
            List<string> expectedNames = new List<string> { "Ash Harvey", "Isaac Perez", "John Doe" };

            // Assert that the actual names match the expected sorted names
            CollectionAssert.AreEqual(expectedNames, actualNames);
        }

        [TestMethod]
        public void CheckContactCount()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();
            var phone = new Phone { PhoneNumber = 1234567890 };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, individualContact.Count);
        }

        [TestMethod]
        public void VerifyNameUpdateReflectsInAllReferences()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();
            var phone = new Phone { PhoneNumber = 1234567890 };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            contact.FullName = "Jane Doe";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Jane Doe", individualContact[phone].FullName);
        }

        [TestMethod]
        public void VerifyPhoneNumberUpdateReflectsInAllReferences()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();
            var phone = new Phone { PhoneNumber = 1234567890 };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            // Update the phone number
            var newPhone = new Phone { PhoneNumber = 1111111111 };
            var updatedContact = new FullContactInfo
            {
                FullName = contact.FullName,
                Email = contact.Email,
                PhoneNumber = newPhone.GetFormattedPhoneNumber()
            };

            // Remove the old key and add the new key
            individualContact.Remove(phone);
            individualContact.Add(newPhone, updatedContact);

            // Validate the updated phone number
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("111-111-1111", newPhone.GetFormattedPhoneNumber());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(individualContact.ContainsKey(newPhone));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("John Doe", individualContact[newPhone].FullName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("john.doe@example.com", individualContact[newPhone].Email);
        }
        [TestMethod]
        public void VerifyEmailUpdateReflectsInAllReferences()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();
            var phone = new Phone { PhoneNumber = 1234567890 };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            contact.Email = "jane.doe@example.com";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("jane.doe@example.com", individualContact[phone].Email);
        }

        [TestMethod]
        public void SearchForNonExistentContact()
        {
            Dictionary<Phone, FullContactInfo> individualContact = new Dictionary<Phone, FullContactInfo>();
            var phone = new Phone { PhoneNumber = 1234567890 };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phone.GetFormattedPhoneNumber()
            };

            individualContact.Add(phone, contact);

            var searchedContact = SearchByMethods.SearchByContactName("Non Existent", individualContact);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, searchedContact.Count);
        }

    }
    [TestClass]
    public sealed class EmailValidatorTest
    {
        private EmailValidator? emailValidator;

        [TestInitialize]
        public void Setup()
        {
            emailValidator = new EmailValidator();
        }

        [TestMethod]
        public void IsValidEmail_ValidEmail_ReturnsTrue()
        {
            // Arrange
            string validEmail = "john.doe@example.com";

            // Act
            bool result = emailValidator!.IsValidEmail(validEmail);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidEmail_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            string invalidEmail = "john.doeexample.com";

            // Act
            bool result = emailValidator!.IsValidEmail(invalidEmail);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_EmptyString_ReturnsFalse()
        {
            // Arrange
            string emptyEmail = "";

            // Act
            bool result = emailValidator!.IsValidEmail(emptyEmail);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_NullString_ReturnsFalse()
        {
            // Arrange
            string nullEmail = null!;

            // Act
            bool result = emailValidator!.IsValidEmail(nullEmail);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_WhitespaceString_ReturnsFalse()
        {
            // Arrange
            string whitespaceEmail = "   ";

            // Act
            bool result = emailValidator!.IsValidEmail(whitespaceEmail);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_EmailWithSpaces_ReturnsFalse()
        {
            // Arrange
            string emailWithSpaces = "john.doe @example.com";

            // Act
            bool result = emailValidator!.IsValidEmail(emailWithSpaces);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_EmailWithoutDomain_ReturnsFalse()
        {
            // Arrange
            string emailWithoutDomain = "john.doe@";

            // Act
            bool result = emailValidator!.IsValidEmail(emailWithoutDomain);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_EmailWithoutAtSymbol_ReturnsFalse()
        {
            // Arrange
            string emailWithoutAtSymbol = "john.doeexample.com";

            // Act
            bool result = emailValidator!.IsValidEmail(emailWithoutAtSymbol);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidEmail_EmailWithMultipleAtSymbols_ReturnsFalse()
        {
            // Arrange
            string emailWithMultipleAtSymbols = "john@doe@example.com";

            // Act
            bool result = emailValidator!.IsValidEmail(emailWithMultipleAtSymbols);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

