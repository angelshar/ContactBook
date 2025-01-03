namespace NameBook
{
    public class NameBook
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
        public NameBook()
        {
            Dictionary<double, List<string>> _NameBook = new Dictionary<double, List<string>>();
        }
    }
}
