using OrdersData;
using OrdersData.Entities;
using System;
using MailKit.Net.Smtp;
using MimeKit;
using System.Text.RegularExpressions;

namespace OrderAssignment
{
    public class OrdersMethods
    {
        string? ItemNameIs { get; set; }
        int ItemRateIs { get; set; }
        int ItemsQtyIs { get; set; }
        string? CustomerFNameIs { get; set; }
        string? CustomerLNameIs { get; set; }
        int CustomerPhoneIs { get; set; }
        string? CustomerEmailIs { get; set; }
        string? CustomerPasswordIs { get; set; }

        public void PrintValues()
        {
            Console.WriteLine("Printing all items");
            CRUDManager obj = new CRUDManager();
            foreach (Item i in obj.ListItems())
            {
                Console.WriteLine($"{i.ItemName}\t{i.ItemsRate}\t{i.ItemQty}");
            }
        }
        public void PrintCDetails(string yourMail)
        {
            Console.WriteLine("your registration details:");
            CRUDManager obj = new CRUDManager();
            Customer cus = obj.YourRegDetails(yourMail);
            
            Console.WriteLine($"{cus.CustomerFName}\t{cus.CustomerLName}\t{cus.CustomerPhone}\t{cus.CustomerEmail}\t{cus.CustomerPassword}");
           
        }
        public void ItemMasterMethods()
        {
            CRUDManager obj = new CRUDManager();
           
            Console.WriteLine("Welcome to Item Master portal.");
            Console.WriteLine();
        MAIN_MENU:
            Console.WriteLine("Enter 1 to add item in Items Table.");
            Console.WriteLine("Enter 2 to update item in Items Table.");
            Console.WriteLine("Enter 3 to list all item in Items Table.");
            Console.WriteLine("Enter 4 to delete item in Items Table.");

            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {

            ItemName:
                Console.WriteLine("Enter item name:");
                ItemNameIs = Console.ReadLine();
                if (ItemNameIs.Equals(""))
                {
                    Console.WriteLine("Item name should not be empty!");
                    goto ItemName;
                }
            ItemRate:
                Console.WriteLine("Enter item rate:");
                string? itemRates = (Console.ReadLine());
                if (itemRates.Equals(""))
                {
                    Console.WriteLine("Item rate should not be empty!");

                    goto ItemRate;
                }
                ItemRateIs = Convert.ToInt32(itemRates);
            ItemQty:
                Console.WriteLine("Enter quantity:");
                string? itemQtys = (Console.ReadLine());
                if (itemQtys.Equals(""))
                {
                    Console.WriteLine("Item quantity should not be empty!");
                    goto ItemQty;
                }
                ItemsQtyIs = Convert.ToInt32(itemQtys);

                obj.Insert(new Item { ItemName = ItemNameIs, ItemsRate = ItemRateIs, ItemQty = ItemsQtyIs });
                Console.WriteLine("Data inserted");

                Console.WriteLine("Enter 1 to go back.");
                Console.WriteLine("Enter 2 to exit.");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    goto MAIN_MENU;
                }
                else if (i == 2)
                {
                    return;
                }

            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter item name to update it's rate and qty.");
                ItemNameIs = Console.ReadLine();
                Console.WriteLine("Enter item rate to update.");
                ItemRateIs = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter item qty to update");
                ItemsQtyIs = Convert.ToInt32(Console.ReadLine());

                obj.Update(ItemNameIs, new Item { ItemName = ItemNameIs, ItemsRate = ItemRateIs, ItemQty = ItemsQtyIs });
                Console.WriteLine("Records updated!");
                
                Console.WriteLine("Enter 1 to go back.");
                Console.WriteLine("Enter 2 to exit.");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    goto MAIN_MENU;
                }
                else if (i == 2)
                {
                    return;
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("All available items are:");
                PrintValues();

                Console.WriteLine("Enter 1 to go back.");
                Console.WriteLine("Enter 2 to exit.");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    goto MAIN_MENU;
                }
                else if (i == 2)
                {
                    return;
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("Enter item name to delete its record from the list.");
                ItemNameIs = Console.ReadLine();
                obj.DeleteI(ItemNameIs);

                Console.WriteLine("Records deleted!");

                Console.WriteLine("Enter 1 to go back.");
                Console.WriteLine("Enter 2 to exit.");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    goto MAIN_MENU;
                }
                else if (i == 2)
                {
                    return;
                }

            }
        }

        public void CustomerMasterMethods()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Customer portal.");
            Console.WriteLine();
        MAIN_MENU:
            Console.WriteLine("Enter 1 for registration in 'online order portal'.");
            Console.WriteLine("Enter 2 to login.");
            Customer customer = new Customer();
            CRUDManager crudManager = new CRUDManager();
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
               CustomerEmail:
                #region customer-registration
                Console.WriteLine("Enter your mail.");
                string mail = Console.ReadLine();

                string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(mail);
                if (!match.Success)
                {
                    Console.WriteLine($"{mail} is not Valid Email Address");
                    goto CustomerEmail;
                }
                Console.WriteLine("Enter first name");
                string fname = Console.ReadLine(); ;
                Console.WriteLine("Enter last name");
                string lName = Console.ReadLine();
                Console.WriteLine("Enter phone");
                int phone = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Set password");
                string pass = Console.ReadLine();
                crudManager.Insert(new Customer { CustomerEmail = mail, CustomerFName = fname, CustomerLName = lName, CustomerPhone = phone, CustomerPassword = pass });


                #region send-mail
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Online Orders Portal", "heman5502@gmail.com"));
                message.To.Add(MailboxAddress.Parse(mail));

                message.Subject = "!!!Welcome!!!";
                message.Body = new TextPart("plain")
                {
                    Text = $"Dear {fname} {lName}, Thanks for registering with us."
                };

                #region private data
                string email = "heman5502@gmail.com";
                string password = "ytrnamdknanthdth";
                #endregion

                SmtpClient smtpClient = new SmtpClient();
                try
                {
                    smtpClient.Connect("smtp.gmail.com", 465, true);
                    smtpClient.Authenticate(email, password);
                    smtpClient.Send(message);
                    Console.WriteLine($"!!Thanks dear  {fname} {lName} for registration with us!!");
                    Console.WriteLine($"A 'Welcome Message' is just sent to your registered mail id from 'heman5502@gmail.com'");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    smtpClient.Disconnect(true);
                    smtpClient.Dispose();
                }
                #endregion
                Console.WriteLine("Enter 1 to go back.");
                Console.WriteLine("Enter 2 to exit.");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    goto MAIN_MENU;
                }
                else if (i == 2)
                {
                    return;
                }
                #endregion
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter your mail");
                string yourMail=Console.ReadLine();
                if (crudManager.EmailPresent(yourMail))
                {
                    Pass1:
                    Console.WriteLine("Enter password.");
                    string yourPass = Console.ReadLine();
                    if (crudManager.passwordPresent(yourPass))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Welcome to your 'online order customer portal'.");
                    CustomerFeaturs:
                        Console.WriteLine("Choose one of the following options.");
                        Console.WriteLine();
                 
                        Console.WriteLine("Enter 1 to see your registration details.");
                        Console.WriteLine("Enter 2 to delete your account/registration details.");
                        Console.WriteLine("Enter 3 to update your account details.");
                        int choiceInCustomer = Convert.ToInt32(Console.ReadLine());

                        if(choiceInCustomer == 1)
                        {
                            PrintCDetails(yourMail);
                            Console.WriteLine("Enter 1 to go back.");
                            Console.WriteLine("Enter 2 to logout.");
                            int i = Convert.ToInt32(Console.ReadLine());
                            if (i == 1)
                            {
                                goto CustomerFeaturs;
                            }
                            else if (i == 2)
                            {
                                return;
                            }
                        }
                        else if (choiceInCustomer == 2)
                        {

                            crudManager.Delete(yourMail);

                            Console.WriteLine("Enter 1 to go back.");
                            Console.WriteLine("Enter 2 to logout.");
                            int i = Convert.ToInt32(Console.ReadLine());
                            if (i == 1)
                            {
                                goto CustomerFeaturs;
                            }
                            else if (i == 2)
                            {
                                return;
                            }
                        }
                        else if (choiceInCustomer == 3)
                        {

                           
                            Console.WriteLine("Enter new phone");
                            int newPhone = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter new password");
                            string newPass = Console.ReadLine();

                            crudManager.UpdateAccount(yourMail,new Customer { CustomerPhone=newPhone,CustomerPassword=newPass});

                            Console.WriteLine("Enter 1 to go back.");
                            Console.WriteLine("Enter 2 to logout.");
                            int i = Convert.ToInt32(Console.ReadLine());
                            if (i == 1)
                            {
                                goto CustomerFeaturs;
                            }
                            else if (i == 2)
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry wrong password.");
                        goto Pass1;
                    }
                }
                else{
                    Console.WriteLine("Sorry you are no registered.");
                    goto MAIN_MENU;
                }

            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
            MAIN_MENU:
                Console.WriteLine();
                Console.WriteLine("Welcome to main menu of 'Online Order Portal'.");
                Console.WriteLine();

                Console.WriteLine("Enter 1 to do operations in Item master.");
                Console.WriteLine("Enter 2 to do operations in Customer master.");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine();

                    //all methods of item master
                    OrdersMethods ordersMethods = new OrdersMethods();
                    ordersMethods.ItemMasterMethods();
                    goto MAIN_MENU;
                }
                else if (choice == 2)
                {
                    OrdersMethods ordersMethods = new OrdersMethods();
                    ////all methods of customer master
                    ordersMethods.CustomerMasterMethods();
                    goto MAIN_MENU;
                }
            }
        }
    }
}