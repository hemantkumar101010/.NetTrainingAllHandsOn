using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtMApp
{
    public class ManageFoodCategory : ManageFoodItems
    {
        
       public static Dictionary<int, string> foodCategoryList = new Dictionary<int, string>();
        
        public static void AddNewFoodCategory()
        {
                Console.WriteLine("Enter food category Id");
                int foodItemId = Convert.ToInt32(Console.ReadLine());

                System.Console.WriteLine("Enter new food category name");
                string foodCategoryName = Console.ReadLine();

                //adding food new item name
               foodCategoryList.Add(foodItemId, foodCategoryName);
                 
        }

        public static void ShowDetailsOfFoodCategory(string foodCategoryName)
        {
            string s = foodCategoryName;
            switch (s)
            {
                case "North indian 0":
                    {
                        foreach (var foodItem in ManageFoodCategory.foodItemList)
                        {
                            if (foodItem.Value.Contains("0"))
                            {
                                Console.WriteLine($"{foodItem.Key}\t{foodItem.Value}");
                            }
                        } 
                            
                        break;
                    }
                case "Sorth indian 1":
                    {
                        foreach (var foodItem in ManageFoodCategory.foodItemList)
                        {
                            if (foodItem.Value.Contains("1"))
                            {
                                Console.WriteLine($"{foodItem.Key}\t{foodItem.Value}");
                            }
                        }

                        break;
                    }
                case "Chinese food 2":
                    {
                        foreach (var foodItem in ManageFoodCategory.foodItemList)
                        {
                            if (foodItem.Value.Contains("2"))
                            {
                                Console.WriteLine($"{foodItem.Key}\t{foodItem.Value}");
                            }
                        }

                        break;
                    }
            }
        }

        public static void ShowAllFoodCategory()
        {
            Console.WriteLine();
            for (int i = 0; i < foodCategoryList.Count; i++)
            {
                Console.WriteLine(foodCategoryList[i]);
                foreach (var foodItem in ManageFoodCategory.foodItemList)
                {
                    if (foodItem.Value.Contains(Convert.ToString(i)))
                    {
                        Console.WriteLine($"{foodItem.Key}\t{foodItem.Value}");
                    }
               }
                Console.WriteLine();
            }
            
        }
    }
}
