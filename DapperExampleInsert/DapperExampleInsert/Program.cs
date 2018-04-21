using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
namespace DapperExampleInsert
{

   
    class Program
    {
        public static IContactsRepository contactsRepository = new ContactsRepository();
        public void InsertData()
        {
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("Enter the FirstName, LastName , Company And Title Of Contacts");
            Console.Write("First Name : ");
            String fName = Console.ReadLine();
            Console.Write("Last Name : ");
            String lName = Console.ReadLine();
            Console.Write("Company Name : ");
            String company = Console.ReadLine();
            Console.Write("Title Name : ");
            String title = Console.ReadLine();
            //inserting
            Contacts contacts1 = new Contacts
            {
                FirstName = fName,
                LastName = lName,
                Company = company,
                Title = title
            };
            contactsRepository.Add(contacts1);
            ShowData();

        }
        public void ShowData()
        {
            Console.WriteLine(new string('*', 20));
            List<Contacts> contacts = contactsRepository.GetAll();
            foreach (var cont in contacts)
            {
                Console.WriteLine(cont.Id + " " + cont.FirstName + " " + cont.LastName + " " + cont.Company + " " + cont.Title);
            }
        }
        public void UpdatingData()
        {
            Console.WriteLine(new string('*', 20));
            //Updating
            Console.WriteLine("What Id do you want to Update ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What do you want to Update....");
            Console.Write("First Name press 1 ");
            Console.Write(" Last Name press 2 ");
            Console.Write(" Company press 3 ");
            Console.Write(" Title press 4 ");
            int ch = Convert.ToInt32(Console.ReadLine());
            Contacts contacts = contactsRepository.GetById(id);
            String Name = null;
            switch (ch)
            {
                case 1:
                    Console.WriteLine("First Name : ");
                    string fName = Console.ReadLine();
                    contacts.FirstName = fName;
                    Name = "FirstName";
                    contactsRepository.Update(contacts, Name);
                    GetByID(id);
                    break;
                case 2:
                    Console.WriteLine("Lase Name : ");
                    string lName = Console.ReadLine();
                    contacts.LastName = lName;
                    Name = "LastName";
                    contactsRepository.Update(contacts, Name);
                    GetByID(id);
                    break;
                case 3:
                    Console.WriteLine("Company : ");
                    string company = Console.ReadLine();
                    contacts.Company = company;
                    Name = "Company";
                    contactsRepository.Update(contacts, Name);
                    GetByID(id);
                    break;
                case 4:
                    Console.WriteLine("Title : ");
                    string title = Console.ReadLine();
                    contacts.Title = title;
                    Name = "Title";
                    contactsRepository.Update(contacts, Name);
                    GetByID(id);
                    break;
                default:
                    Console.WriteLine("Please select a choice atleast");
                    break;
            }
        }
        //Get By ID Method
        public void GetByID(int id)
        {
            Console.WriteLine(new string('*', 20));
            Contacts contacts2 = contactsRepository.GetById(id);
            if (contacts2 != null)
            {
                Console.WriteLine(contacts2.Id + " " + contacts2.FirstName + " " + contacts2.LastName + " " + contacts2.Company + " " + contacts2.Title);
            }
        }
        //Delete Method
        public void DeleteData()
        {
            Console.WriteLine(new string('*', 20));
            ShowData();
            Console.WriteLine(new string('*', 20));

            //Deletion
            Console.Write("What id do you want to delete :");
            int id = Convert.ToInt32(Console.ReadLine());
            contactsRepository.Delete(id);
            Contacts con = contactsRepository.GetById(3);
            if (con == null)
            {
                Console.WriteLine("Employee record is deleted already");
            }
            Console.WriteLine(new string('*', 20));
            ShowData();
        }
        public void SelectOption()
        {
            Console.WriteLine(new string('*', 20));

            Console.WriteLine("Welcome To Dapper Example :");
            Console.WriteLine(new string('*', 20));
            Console.WriteLine("For...");
            Console.WriteLine("Show Data Select 1");
            Console.WriteLine("Insert Data Select 2");
            Console.WriteLine("Update Data Select 3");
            Console.WriteLine("Delete Data Select 4");
            Console.WriteLine();
            Console.Write("Your Selection :  ");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    ShowData();
                    break;
                case 2:
                    InsertData();
                    break;
                case 3:
                    UpdatingData();
                    break;
                case 4:
                    DeleteData();
                    break;
                default:
                    break;
            }

            Console.WriteLine(new string('*', 20));
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.SelectOption();


            Console.ReadLine();
        }
    }
}