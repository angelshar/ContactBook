using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NameBook
{
    public class EmailValidator
    {
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // Regular expression pattern for validating email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
    }
    public class FullContactInfo
    {
        //Create a class or method that accepts full name, phone number, and email
        //Maybe an address, social media, and birthday (and notes if we feeling risky)
        //Create a method or dictionary to add to an empty list or for each individual
        //Search or print and sort all contacts in the namebook
        //A way to delete or change a contact
        //A way to list all the contacts
        //Make a crazy intellisense like your phone does to automatically know which contacts you possibly refer to

        //Use dictionary; the phone number will be the key and the value will be a list containing
        //the elements we want the contact to have
        //the phone number will also be listed as a string
        //default elements to null if not in use?
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class Phone
    {
        public int PhoneNumber { get; set; }

        public string GetFormattedPhoneNumber()
        {
            // Format the phone number as "123-456-7890"
            return $"{PhoneNumber / 10000000:D3}-{(PhoneNumber / 10000) % 1000:D3}-{PhoneNumber % 10000:D4}";
        }
    }

    public class SearchByMethods
    {
       
        public static string GetKeyFromValue(string valueVar)
        {
            foreach (string keyVar in Dictionary<Phone, FullContactInfo>)
            {
                if (Dictionary[keyVar] == valueVar)





                {
                    return keyVar;
                }
            }
            return null;
        }
    }

}
//copilot code to help us
/*
 using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NameBook
{
    public class EmailValidator
    {
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // Regular expression pattern for validating email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
    }

    public class FullContactInfo
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string SocialMedia { get; set; }
        public DateTime? Birthday { get; set; }
        public string Notes { get; set; }
    }

    public class Phone
    {
        public int PhoneNumber { get; set; }

        public string GetFormattedPhoneNumber()
        {
            // Format the phone number as "123-456-7890"
            return $"{PhoneNumber / 10000000:D3}-{(PhoneNumber / 10000) % 1000:D3}-{PhoneNumber % 10000:D4}";
        }
    }

    public class ContactList
    {
        private Dictionary<Phone, FullContactInfo> contacts = new Dictionary<Phone, FullContactInfo>();

        public void AddContact(FullContactInfo contact, Phone phone)
        {
            contacts[phone] = contact;
        }

        public FullContactInfo GetContact(Phone phone)
        {
            contacts.TryGetValue(phone, out var contact);
            return contact;
        }

        public void DeleteContact(Phone phone)
        {
            contacts.Remove(phone);
        }

        public List<FullContactInfo> ListAllContacts()
        {
            return new List<FullContactInfo>(contacts.Values);
        }

        public List<FullContactInfo> SearchContacts(string searchTerm)
        {
            List<FullContactInfo> results = new List<FullContactInfo>();

            foreach (var contact in contacts.Values)
            {
                if (contact.FullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    contact.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    contact.Address?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true)
                {
                    results.Add(contact);
                }
            }

            return results;
        }
    }

    class Program
    {
        static void Main()
        {
            ContactList contactList = new ContactList();
            EmailValidator emailValidator = new EmailValidator();

            var phone = new Phone { PhoneNumber = 1234567890 };
            var contact = new FullContactInfo
            {
                FullName = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = phone.GetFormattedPhoneNumber(),
                Address = "123 Main St",
                Birthday = new DateTime(1990, 1, 1)
            };

            if (emailValidator.IsValidEmail(contact.Email))
            {
                contactList.AddContact(contact, phone);
                Console.WriteLine("Contact added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid email address.");
            }

            // Example usage
            var retrievedContact = contactList.GetContact(phone);
            Console.WriteLine($"Retrieved Contact: {retrievedContact.FullName}");
        }
    }
}
*/