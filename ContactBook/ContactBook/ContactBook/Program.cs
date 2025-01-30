// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using NameBook;

Console.WriteLine("Would you like to make a new contactbook? (y/n)");
string answer = Console.ReadLine();
if (answer == "y")
{
    Console.WriteLine("Who would you like to add into your contactbook? (Please type full name)");
    string fullName = Console.ReadLine();
    Console.WriteLine("What is their phone number? (Please type in 10 digits)");
    Double phoneNumber = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("What is their email? (Please enter a valid email)");
    string email = Console.ReadLine();
    Dictionary<Phone, FullContactInfo> multiContact = new Dictionary<Phone, FullContactInfo>();
    var phone = new Phone
    {
        PhoneNumber = phoneNumber
    };
    var contact1 = new FullContactInfo
    {
        FullName = fullName,
        Email = email,
        PhoneNumber = phone.GetFormattedPhoneNumber()
    };
    multiContact.Add(phone, contact1);

    foreach (var kvp in multiContact)
    {
        Console.WriteLine($"Phone: {kvp.Key.PhoneNumber}, ContactInfo: Name: {kvp.Value.FullName}, Email: {kvp.Value.Email}, Phone Number: {kvp.Value.PhoneNumber}");
    }

    Console.WriteLine("Would you like to add more contacts? (y/n)");
    string answer2 = Console.ReadLine();
    while (answer2 == "y")
    {
        Console.WriteLine("Who would you like to add into your contactbook? (Please type full name)");
        string fullName2 = Console.ReadLine();
        Console.WriteLine("What is their phone number? (Please type in 10 digits)");
        double phoneNumber2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What is their email? (Please enter a valid email)");
        string email1 = Console.ReadLine();
        var phone2 = new Phone
        {
            PhoneNumber = phoneNumber2
        };
        var contact2 = new FullContactInfo
        {
            FullName = fullName2,
            Email = email1,
            PhoneNumber = phone2.GetFormattedPhoneNumber()
        };
        multiContact.Add(phone2, contact2);
        foreach (var kvp in multiContact)
        {
            Console.WriteLine($"Phone: {kvp.Key.PhoneNumber}, ContactInfo: Name: {kvp.Value.FullName}, Email: {kvp.Value.Email}, Phone Number: {kvp.Value.PhoneNumber}");
        }
        Console.WriteLine("Would you like to add more contacts? (y/n)");
        answer2 = Console.ReadLine();
    }

    Console.WriteLine("Would you like to search for a contact? (y/n)");
    string answer3 = Console.ReadLine();
    while (answer3 == "y")
    {
        Console.WriteLine("Would you like to search by name or email? (name/email)");
        string searchBy = Console.ReadLine();
        if (searchBy == "name")
        {
            Console.WriteLine("Please type in the name you would like to search for");
            string searchName = Console.ReadLine();
            var searchResult = SearchByMethods.SearchByContactName(searchName, multiContact);
            foreach (var kvp in searchResult)
            {
                Console.WriteLine($"Name: {kvp.Value.FullName} \nPhone Number: {kvp.Value.PhoneNumber} \n Email: {kvp.Value.Email}");
            }
        }
        else if (searchBy == "email")
        {
            Console.WriteLine("Please type in the email you would like to search for?");
            string searchEmail = Console.ReadLine();
            var searchResult = SearchByMethods.SearchByContactEmail(searchEmail, multiContact);
            foreach (var kvp in searchResult)
            {
                Console.WriteLine($"Name: {kvp.Value.FullName} \nPhone Number: {kvp.Value.PhoneNumber} \n Email: {kvp.Value.Email}");
            }
        }

        Console.WriteLine("Would you like to search for another contact? (y/n)");
        answer3 = Console.ReadLine();
    }
    Console.WriteLine("Goodbye!");
}
else
{
    Console.WriteLine("Goodbye!");
}


