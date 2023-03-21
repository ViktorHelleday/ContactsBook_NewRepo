using ContactsBook.Models;
using Newtonsoft.Json;


namespace ContactsBook.Services
{
    public class MenuManager
    {
        public List<Contact> contacts = new List<Contact>();
        public string FilePath { get; set; } = null!;
        public bool ConsoleAppRunning { get; set; } = true;
        private FileService file = new FileService();

        public void StartingMenu()
        {
            try
            {
                contacts = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath))!;
            }
            catch { }

            Console.WriteLine("- CONTACT BOOK -");
            Console.WriteLine();
            Console.WriteLine("1. Add new contact.");
            Console.WriteLine();
            Console.WriteLine("2. Display all contacts.");
            Console.WriteLine();
            Console.WriteLine("3. Search for specific contact.");
            Console.WriteLine();
            Console.WriteLine("4. Remove contact.");
            Console.WriteLine();
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.WriteLine("Choose an option by typing 1-4 on your keyboard: ");
            Console.WriteLine();

            var UserOption = Console.ReadLine();

            switch (UserOption)
            {
                case "1": AddNewContact(); break;
                case "2": DisplayAll(); break;
                case "3": SearchSpecific(); break;
                case "4": RemoveContact(); break;
                case "5": ExitApp(); break;
            }
        }

        private void AddNewContact()
        {
            Console.Clear();
            Console.WriteLine("Add new contact: ");
            Contact contact = new Contact();
            Console.Write("Firstname: ");
            contact.FirstName = Console.ReadLine() ?? "";
            Console.Write("Lastname: ");
            contact.LastName = Console.ReadLine() ?? "";
            Console.Write("Email: ");
            contact.Email = Console.ReadLine() ?? "";
            Console.Write("Phone number: ");
            contact.PhoneNumber = Console.ReadLine() ?? "";
            Console.Write("Street: ");
            contact.StreetName = Console.ReadLine() ?? "";
            Console.Write("Postal Code: ");
            contact.PostalCode = Console.ReadLine() ?? "";
            Console.Write("City: ");
            contact.City = Console.ReadLine() ?? "";

            contacts.Add(contact);
            file.Save(FilePath, JsonConvert.SerializeObject(contacts));
            Console.ReadKey();
        }

        private void DisplayAll()
        {
            Console.Clear();
            Console.WriteLine("Display all contacts: ");

            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"{contact.Email}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("There are no contacts saved yet.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to return the the menu.");
            Console.ReadKey();
        }

        private void SearchSpecific()
        {
            Console.Clear();
            Console.WriteLine("Search specific contact by: ");
            Console.WriteLine();
            Console.WriteLine("1. Firstname");
            Console.WriteLine();
            Console.WriteLine("2. Lastname");
            Console.WriteLine() ;

            int searchOptionNumber = int.Parse(Console.ReadLine() ?? "");
            Console.WriteLine();
            string searchNumber = Console.ReadLine() ?? "";
            Console.WriteLine();

            bool contactFound = false;

            foreach (var contact in contacts)
            {
                if (searchOptionNumber == 1 && contact.FirstName.Contains(searchNumber))
                {
                    Console.WriteLine($"Firstname: {contact.FirstName}");
                    Console.WriteLine($"Lastname: {contact.LastName}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Phone number: {contact.PhoneNumber}");
                    Console.WriteLine($"Adress: {contact.StreetName}, {contact.PostalCode} {contact.City}");
                    Console.WriteLine();
                    contactFound = true;
                }
                else if (searchOptionNumber == 2 && contact.LastName.Contains(searchNumber))
                {
                    Console.WriteLine($"Firstname: {contact.FirstName}");
                    Console.WriteLine($"Lastname: {contact.LastName}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Phone number: {contact.PhoneNumber}");
                    Console.WriteLine($"Adress: {contact.StreetName}, {contact.PostalCode} {contact.City}");
                    Console.WriteLine();
                    contactFound = true;
                }
            }
            if (!contactFound)
            {
                Console.WriteLine("No contact were found. Press any key to return to the menu.");
            }

            Console.ReadKey();
        }

        private void RemoveContact()
        {
            Console.Clear();
            Console.WriteLine("Write the firstname of the contact you want to remove: ");
            Console.WriteLine();
            string removeFirstname = (Console.ReadLine() ?? "").ToLower();
            Console.WriteLine();
            Console.WriteLine("Write the lastname of the contact you want to remove: ");
            Console.WriteLine();
            string removeLastname = (Console.ReadLine() ?? "").ToLower();

            bool removeContactFound = false;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].FirstName.ToLower() == removeFirstname.ToLower() && contacts[i].LastName.ToLower() == removeLastname.ToLower())
                {
                    Console.WriteLine();
                    Console.WriteLine($"Confirm that you want to remove {removeFirstname} {removeLastname} from your contact list by pressing y.");
                    string answer = (Console.ReadLine() ?? "").ToLower();

                    if (answer == "y")
                    {
                        contacts.RemoveAt(i);
                        Console.WriteLine("Contact has been removed.");
                        removeContactFound = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Contact wasn't removed.");
                    }
                }
            }
            if (!removeContactFound)
            {
                Console.WriteLine($"{removeFirstname} {removeLastname} wasn't found.");
            }

            File.WriteAllText(FilePath, JsonConvert.SerializeObject(contacts)); 

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        private void ExitApp()
        {
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
