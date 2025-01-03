
namespace NameBookTest
{
    [TestClass]
    public sealed class NameBookTest
    {
        [TestMethod]
        public void AccessNameBookList()
        {
            //Arrange
            string key = "7801235624";
            Dictionary<double, List<string>> NameBook = new Dictionary<double, List<string>>();
            NameBook.Add(7801235624, new List<string> { "Angelina Harvey", "angelshpat@gmail.com", key });
            //Act
            double keyToCheck = 7801235624;
            List<string> expectedValue = new List<string> { "Angelina Harvey", "angelshpat@gmail.com", key };
            bool valueMatches = NameBook.ContainsKey(keyToCheck) && AreListEqual(NameBook[keyToCheck], expectedValue);
            //Assert
            Assert.IsTrue(valueMatches);
            
        }

        private bool AreListEqual(List<string> list1, List<string> list2)
        {
            if(list1.Count != list2.Count) { return false; }
            for (int i = 0; i < list1.Count; i++) { if (list1[i] != list2[i]) { return false; } }
            return true;
        }

        [TestMethod]
        public void VerifyInitialListIsEmpty()
        {
        }
        [TestMethod]
        public void AddContactName()
        {
        }
        [TestMethod]
        public void VerifyCorrectContactNameType()
        {
        }
        [TestMethod]
        public void AddContactPhoneNumber()
        {
        }
        [TestMethod]
        public void VerifyCorrectContactPhoneNumberType()
        {
        }
        [TestMethod]
        public void VerifyCorrectPhoneNumberToName()
        {
        }
        [TestMethod]
        public void AddContactEmail()
        {
        }
        [TestMethod]
        public void VerifyCorrectContactEmailType()
        {
        }
        [TestMethod]
        public void VerifyCorrectEmailToName()
        {
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
