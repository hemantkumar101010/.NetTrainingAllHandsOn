using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtMApp
{
    public class ManageFoodItems
    {
        public static Dictionary<int,(string,int,string)> foodItemList = new Dictionary<int,(string,int,string)> ();
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
                
                System.Console.WriteLine("Enter new food item name ");
                string foodItemName = Console.ReadLine();

                System.Console.WriteLine("Enter  food category name ");
                string categoryName = Console.ReadLine();

                Console.WriteLine("Enter category Id");
                int foodCategoryId = Convert.ToInt32(Console.ReadLine());

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
                    //adding food new item
                    foodItemList.Add(foodItemId, (foodItemName,foodCategoryId,categoryName));
                    Console.WriteLine($"{foodItemName} successfully added in your food items list.");
                }
                //storing food items cost 
                foodItemCostList.Add(foodItemId, foodItemCost);
                Console.WriteLine($"{foodItemName} cost successfully added in your food items cost list.");

            }
        }

        public static void ShowDetailsOfFoodItem(string itemName)
        {
           foreach(var foodItem in foodItemList)
            {
                if (foodItem.Value.Item1.Equals(itemName))
                {
                    //Console.WriteLine("rahul");
                    Console.WriteLine($"Details of {foodItem.Value.Item1} food item.");

                    Console.WriteLine($"Item id: {foodItem.Key}");
                    Console.WriteLine($"Food category id: {foodItem.Value.Item2}");
                    Console.WriteLine($"Food Name: {foodItem.Value.Item1}");
                    Console.WriteLine($"Item Cost: ${foodItemCostList[foodItem.Key]}/item");
                    Console.WriteLine();
                }

            }
            
            
        }

        public static void ShowDetailsOfAllItems()
        {
            Console.WriteLine($"All available food items:");
            Console.WriteLine();
            Console.WriteLine("ItemId\tItemName\tCategoryId\tCategoryName\tItemCost");
            foreach (var item in foodItemList)
            {
                int id = item.Key;
                Console.WriteLine($"{id}\t{item.Value.Item1}\t{item.Value.Item2}\t{item.Value.Item3}\t{foodItemCostList[id]}");                            
            }
            Console.WriteLine();
        }

        //edit food items
        public static void UpdateFooditem(string itemName)
        {
            
            Console.WriteLine();
            //getting id of the food item having item name
            int id = foodItemList.FirstOrDefault(x => x.Value.Equals(itemName)).Key;

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
