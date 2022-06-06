using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtMApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Note: You have to implement file handling or array storage to maintain data about food and sales information
             Your console screen should be show 4 menu options: ManageFood,Manage Foot category, ManageSales, Reports
             Based on menu selection you should show other sub menu items.
     Example: If admin select Manage food items(Add new food,view fooditem, Edit footitem,listing all the food items.Like this you have to 
            show other sub menus part of main menus.
     */
            //1 denote north indian, 2 denote south indian,3 denote chinese food in dictionary value parameter

            ManageFoodItems.foodItemList.Add(1, "Veg Sandwich0");
            ManageFoodItems.foodItemCostList.Add(1, 99);
            ManageFoodItems.foodItemList.Add(2, "French fries2");
            ManageFoodItems.foodItemCostList.Add(2, 199);
            ManageFoodItems.foodItemList.Add(3, "veg Alo Toast1");
            ManageFoodItems.foodItemCostList.Add(3, 75);
            ManageFoodItems.foodItemList.Add(4, "Veg rice1");
            ManageFoodItems.foodItemCostList.Add(4, 300);
            ManageFoodItems.foodItemList.Add(5, "Non-veg rice1");
            ManageFoodItems.foodItemCostList.Add(5, 200);

            ManageFoodCategory.foodCategoryList.Add(0, "South indian dishes");
            ManageFoodCategory.foodCategoryList.Add(1, "North indian dishes");
            ManageFoodCategory.foodCategoryList.Add(2, "Chinese food dishes");

            ManageSales.salesList.Add(1, ("Hemant", "French fries2", DateTime.Now, 2));

        TOP0:
            Console.WriteLine("---------------WELCOME TO FOOD COURT MANAGEMENT APP MENU---------------");
            Console.WriteLine("Please choose any of the following options:");
            Console.WriteLine("1. Manage Food items");
            Console.WriteLine("2. Manage Food category");
            Console.WriteLine("3. Manage Sales");
            Console.WriteLine("4. Manage  Reports");
            Console.WriteLine("");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {

                case 1:
                    {
                    TOP1:
                        Console.WriteLine("You are in Food Item Management portal");
                        Console.WriteLine();

                        Console.WriteLine("Choose on of the following actions");
                        Console.WriteLine("1. Add a new food item");
                        Console.WriteLine("2. Edit the existing food item");
                        Console.WriteLine("3. View details of a particular food item");
                        Console.WriteLine("4. Listing all food items");

                        int subChoice = Convert.ToInt32(Console.ReadLine());

                        switch (subChoice)
                        {
                            case 1:
                                {
                                    //add new items function
                                    ManageFoodItems.AddNewFoodItem();

                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP1;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;
                                    }
                                }
                            case 2:
                                {
                                    //updating cost of a item
                                    Console.WriteLine("Enter the item name to update cost");
                                    string itemName = Console.ReadLine();
                                    ManageFoodItems.UpdateFooditem(itemName);
                                    Console.WriteLine();
                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP1;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;
                                    }

                                }
                            case 3:
                                {
                                    //show a particular item detail function
                                    Console.WriteLine("Enter name of the food item");
                                    string itemName = Console.ReadLine();
                                    ManageFoodItems.ShowDetailsOfFoodItem(itemName);

                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP1;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;
                                    }

                                }
                            case 4:
                                {
                                    //show all current available food items
                                    ManageFoodItems.ShowDetailsOfAllItems();

                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP1;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;
                                    }
                                }
                            default:
                                {
                                    Console.WriteLine("Enter a vaild number!!");

                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP1;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;
                                    }
                                }
                        }
                        break;
                    }
                case 2:
                    {
                    TOP2:
                        Console.WriteLine("You are in Food Category Management portal");
                        Console.WriteLine();

                        Console.WriteLine("Choose on of the following actions");
                        Console.WriteLine("1. Add a new food category");
                        Console.WriteLine("2. View details of a particular food category");
                        Console.WriteLine("3. Edit the existing food category");
                        Console.WriteLine("4. Listing all food category");

                        int subChoice = Convert.ToInt32(Console.ReadLine());

                        switch (subChoice)
                        {
                            case 1:
                                {
                                    ManageFoodCategory.AddNewFoodCategory();
                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP2;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;
                                    }
                                }
                            case 2:
                                {
                                    Console.WriteLine("Enter food category name");
                                    string fc = Console.ReadLine();
                                    ManageFoodCategory.ShowDetailsOfFoodCategory(fc);
                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP2;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;
                                    }
                                   

                                }
                            case 4:
                                {
                                    ManageFoodCategory.ShowAllFoodCategory();
                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP2;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");


                                    }

                                }
                                break;
                        }
                        break;

                    }
                case 3:
                    {
                    TOP3:
                        Console.WriteLine("You are in Sales Management portal");
                        Console.WriteLine();

                        Console.WriteLine("Choose on of the following actions");
                        Console.WriteLine("1. Add a new sale");
                        Console.WriteLine("2. edit the existing sale");
                        Console.WriteLine("3. view details of the sales");
                        Console.WriteLine("4. view all sales generated");

                        int subChoice = Convert.ToInt32(Console.ReadLine());
                        switch (subChoice)
                        {
                            case 1:
                                {
                                    ManageSales.AddASale();
                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP3;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;

                                    }          

                                }
                            case 3:
                                {
                                    Console.WriteLine("Enter sales id");
                                    int sid =Convert.ToInt32(Console.ReadLine());
                                    ManageSales.viewSalesDetails(sid);
                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP3;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;

                                    }
                                }
                            case 4:
                                {

                                    ManageSales.ShowAllSalesDetails();
                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP3;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;

                                    }
                                }


                        }
                        break;
                    }
                case 4:
                    {
                    TOP3:
                        Console.WriteLine("You are in Reports Management portal");
                        Console.WriteLine();

                        Console.WriteLine("Choose on of the following actions");
                        Console.WriteLine("1. Show food item report");
                        Console.WriteLine("2. Show food category report");
                        Console.WriteLine("3. Show sales report");
                       

                        int subChoice = Convert.ToInt32(Console.ReadLine());
                        switch (subChoice)
                        {
                            case 1:
                                {
                                    ReportOfApp.ReportOfAllFoodItems();
                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP3;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;

                                    }
                                }
                            case 2:
                                {
                                    ReportOfApp.ReportofAllFoodCategory();
                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP3;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;

                                    }
                                }
                            case 3:
                                {
                                    ReportOfApp.ReportOfAllSales();
                                    Console.WriteLine("Press 1 to go previous portal");
                                    Console.WriteLine("Press 0 to go stating portal");
                                    int i = Convert.ToInt32(Console.ReadLine());
                                    if (i == 1)
                                        goto TOP3;
                                    else if (i == 0)
                                        goto TOP0;
                                    else
                                    {
                                        Console.WriteLine("Enter a valid number.");
                                        break;

                                    }
                                }

                        }
                        break;
                    }

            }
        }
    }
}
