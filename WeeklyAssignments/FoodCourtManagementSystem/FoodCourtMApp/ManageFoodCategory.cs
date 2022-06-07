using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtMApp
{
    public class ManageFoodCategory : ManageFoodItems
    {
        //dictionary contains one key (food category type) and one value of type tuple
       public static Dictionary<int, (string,string)> foodCategoryList = new Dictionary<int, (string,string)>();
        
        public static void AddNewFoodCategory()
        {
            System.Console.WriteLine("Enter new food category id");
            int foodCategoryId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter food category name");
            string foodCategoryName = (Console.ReadLine());

            System.Console.WriteLine("Enter new food category type");
            string foodCategoryType = Console.ReadLine();
                

            //adding food new food category
            foodCategoryList.Add(foodCategoryId, (foodCategoryName, foodCategoryType));
                 
        }

        public static void EditExistingFoodCategory(int foodCategoryId)
        {
            foodCategoryList.Remove(foodCategoryId);
            ManageFoodItems.foodItemList.Remove(foodCategoryId);
            Console.WriteLine($"{foodCategoryId} removed successfully from your portals");
                
        }
        public static void ShowDetailsOfFoodCategory(string foodCategoryName)
        {
            string s = foodCategoryName;
            switch (s)
            {
                case "North indian":
                    {
                        foreach (var foodCategory in foodCategoryList)
                        {
                            if (foodCategory.Value.Item1.Equals(s))
                            {
                                Console.Write($"{foodCategory.Key}\t{foodCategory.Value.Item2}\t");
                            }
                        }
                        foreach (var foodItem in ManageFoodItems.foodItemList)
                        {

                            if (foodItem.Value.Item3.Equals(s))
                            {
                                Console.WriteLine($"{foodItem.Value.Item1}");
                            }
                        }

                        break;
                    }
                case "South indian":
                    {
                        foreach (var foodCategory in foodCategoryList)
                        {
                            if (foodCategory.Value.Item1.Equals(s))
                            {
                                Console.WriteLine($"{foodCategory.Key}\t{foodCategory.Value.Item2}");
                            }
                        }
                        foreach (var foodItem in ManageFoodItems.foodItemList)
                        {

                            if (foodItem.Value.Item3.Equals(s))
                            {
                                Console.WriteLine($"{foodItem.Value.Item1}");
                            }
                        }

                        break;
                    }
                case "Chinese food":
                    {
                        foreach (var foodCategory in foodCategoryList)
                        {
                            if (foodCategory.Value.Item1.Equals(s))
                            {
                                Console.WriteLine($"{foodCategory.Key}\t{foodCategory.Value.Item2}");
                            }
                        }
                        foreach (var foodItem in ManageFoodItems.foodItemList)
                        {

                            if (foodItem.Value.Item3.Equals(s))
                            {
                                Console.WriteLine($"{foodItem.Value.Item1}");
                            }
                        }

                        break;
                    }
            }
        }

        public static void ShowAllFoodCategory()
        {
            Console.WriteLine();
            
            foreach (var foodCategory in ManageFoodCategory.foodCategoryList)
            {
                Console.WriteLine(foodCategory.Value.Item1);
                foreach (var foodItem in ManageFoodItems.foodItemList)
                {
                   if(foodItem.Value.Item3==foodCategory.Value.Item1)
                     Console.WriteLine($"{foodItem.Key}\t{foodItem.Value.Item1}\t{foodCategory.Value.Item2}");
                }
            }
        }
    }
}
