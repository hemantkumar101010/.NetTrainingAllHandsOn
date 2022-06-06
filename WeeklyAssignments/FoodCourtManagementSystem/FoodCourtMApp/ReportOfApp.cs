using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCourtMApp
{
    public class ReportOfApp
    {
        public static void ReportOfAllFoodItems()
        {
            ManageFoodItems.ShowDetailsOfAllItems();

        }

        public static void ReportofAllFoodCategory()
        {
            ManageFoodCategory.ShowAllFoodCategory();
        }
        public static void ReportOfAllSales()
        {
            ManageSales.ShowAllSalesDetails();
        }
    }
}
