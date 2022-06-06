using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtMApp
{
    public class ManageFoodItems
    {
        public static Dictionary<int, string> foodItemList = new Dictionary<int, string>();
        public static Dictionary<int, int> foodItemCostList = new Dictionary< int, int>();    
        public static void AddNewFoodItem()
        {
            Console.WriteLine("Enter no. of new food items you wants to add in the list.");
            int totalItems = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < totalItems; i++)
            {
                TOP1:
                Console.WriteLine("Enter food Id");
                int foodItemId= Convert.ToInt32(Console.ReadLine());
                
                System.Console.WriteLine("Enter new food item name");
                string foodItemName = Console.ReadLine();

                System.Console.WriteLine("Enter new food item Cost per item");
                int foodItemCost = Convert.ToInt32(Console.ReadLine());
    
                if (foodItemList.ContainsKey(foodItemId))
                {
                    Console.WriteLine($"{foodItemId} food Id is already in the food items list.");
                    Console.WriteLine("Add new id which is not in your food list.");
                    goto TOP1;
                }
                else
                {
                    //adding food new item name
                    foodItemList.Add(foodItemId, foodItemName);
                    Console.WriteLine($"{foodItemName} successfully added in your food items list.");
                }
                //storing food items cost 
                foodItemCostList.Add(foodItemId, foodItemCost);
                Console.WriteLine($"{foodItemName} cost successfully added in your food items cost list.");

            }
        }

        public static void ShowDetailsOfFoodItem(string itemsName)
        {
            if (foodItemList.ContainsValue(itemsName))
            {
                //Console.WriteLine("rahul");
                Console.WriteLine($"Details of {itemsName} food items");

                int id = foodItemList.FirstOrDefault(x => x.Value == itemsName).Key;

                Console.WriteLine($"Item id: {id}");
                Console.WriteLine($"Food Name: {itemsName}");
                Console.WriteLine($"Item Cost: ${foodItemCostList[id]}/item");
                Console.WriteLine();
            }
        }

        public static void ShowDetailsOfAllItems()
        {
            Console.WriteLine($"All available food items:");
            Console.WriteLine();
            Console.WriteLine("ItemId\tItemName\tItemCost");
            foreach (var item in foodItemList)
            {
                int id = item.Key;
                Console.WriteLine($"{id}\t{item.Value}\t{foodItemCostList[id]}");                            
            }
            Console.WriteLine();
        }

        //edit food items
        public static void UpdateFooditem(string itemName)
        {
            //getting id of the food item
            Console.WriteLine();
            int id = foodItemList.FirstOrDefault(x => x.Value == itemName).Key;

            int val;
            if (foodItemCostList.TryGetValue(id, out val))
            {
                Console.WriteLine($"Enter the updated cost of {itemName}");
                int newCost =Convert.ToInt32(Console.ReadLine());
                foodItemCostList[id] =  newCost;
                Console.WriteLine($"{itemName} get updated from ${val}/item to ${newCost}/item successfully.");
            }
            
            Console.WriteLine();
        }

    }



}
