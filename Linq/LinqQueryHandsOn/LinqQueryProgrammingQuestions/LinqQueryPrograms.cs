using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueryProgrammingQuestions
{
    public class LinqQueryPrograms
    {
        /*1.	Write a program in C# Sharp to find the positive numbers from a list of numbers using two where conditions in LINQ Query.
                Input: 
                int[] n1 = {1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14};*/

        public static void PositiveNoLinqMethod()
        {
            int[] n1 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };

            //immediate execution
            var output = (from n1Item in n1
                          where n1Item >= 0
                          select n1Item).ToList();

            foreach (var n2Item in output)
            {
                Console.Write(n2Item + " ");
            }
            Console.WriteLine();
        }

        /*  2.	Write a program in C# Sharp to display the number and frequency of number from given array.
                Input: 
                int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };  */

        public static void DisplayNumNFrequency()
        {
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            
            var displayArr = (from arr1Item in arr1
                              select arr1Item).ToList();

            Console.WriteLine("The numbers in the array  are :");

            foreach (var displayArrItem in displayArr)
            {
                Console.Write($"{displayArrItem} ");
            }
            Console.WriteLine();
            Console.WriteLine("Numbers and the frequency are :");

            var result = (from arr1Item in arr1
                          group arr1Item by arr1Item).ToList();

            foreach (var resultItems in result)
            {   
                var number = (from resultSubItem in resultItems
                              select resultSubItem).FirstOrDefault();

                Console.WriteLine($"Number {number} appears {resultItems.Count()} times.");

            }

        }

        public static void CharNFrequencyMethod(string myString)
        {
            /* 3.	Write a program in C# Sharp to display the characters and frequency of character from giving string

                    Input the string: apple
                    Expected Output:
                    The frequency of the characters are :
                    Character a: 1 times */
            char[] charactersArr= myString.ToCharArray();

            Console.WriteLine("Input string is :"+myString);

            var result = (from charactersArrItem in charactersArr
                          group charactersArrItem by charactersArrItem).ToList();

            Console.WriteLine("The frequency of the characters are :");
            foreach (var resultItems in result)
            {
                var character = (from resultSubItem in resultItems
                              select resultSubItem).FirstOrDefault();

                Console.WriteLine($"Character {character}: {resultItems.Count()} times");

            }

        }

        /*4.	Write a program in C# Sharp to find the string which starts and ends with a specific character
                  Input:
                  The cities are : 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABU DHABI','PARIS'
                  Input starting character for the string : A
                  Input ending character for the string : M
                  Expected Output :
                  The city starting with A and ending with M is : AMSTERDAM*/

            public static void StartsEndsWithCharMethod()
            {
                  List<string> cityLists = new List<string>()
                  {
                      "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI","PARIS"
                  };
                  
                  var displayCityLsit = (from city in cityLists
                                         select city).ToList();

                  Console.WriteLine("The cities are :");
                  foreach(var city in displayCityLsit)
                  {
                    Console.Write($"{city} ");
                  }
            Console.WriteLine();
            Console.Write("Input starting character for the string :");
            string startWith, endsWith;
            startWith = Console.ReadLine();

            Console.Write("Input ending character for the string :");
            endsWith = Console.ReadLine();

             var resCity = (from city in cityLists
                        where city.StartsWith(startWith)&&city.EndsWith(endsWith)
                        select city).FirstOrDefault();

            Console.WriteLine($"The city starting with {startWith} and ending with {endsWith} is :{resCity}");
        }
/*5.	Write a program in C# Sharp to display the top n-th records.

Input :
The members of the list are :
5
7
13
24
6
9
8
7
How many records you want to display ? : 3
Expected Output :
The top 3 records from the list are :
24
13
9
 */
        public static void DisplayTopNRecords()
        {
            int[] records = { 5, 7, 13, 24, 6, 9, 8, 7 };
            Console.Write("How many records you want to display ? :");
            int input = Convert.ToInt32(Console.ReadLine());

            var res = (from rec in records
                       orderby rec descending
                       select rec).ToList();
            Console.WriteLine($"The top {input} records from the list are :");
            for (int i = 0; i < input; i++)
            {
                   Console.WriteLine(res[i]);
            }
        }


        //6.	Write a program in C# Sharp to find the n-th Maximum grade point achieved by the students from the
        //list of students.
        public static void NthMaxGrade()
        {
            List<Students> stulist = new List<Students>();
            stulist.Add(new Students { StuId = 1, StuName = " Joseph ", GrPoint = 800 });
            stulist.Add(new Students { StuId = 2, StuName = "Alex", GrPoint = 458 });
            stulist.Add(new Students { StuId = 3, StuName = "Harris", GrPoint = 900 });
            stulist.Add(new Students { StuId = 4, StuName = "Taylor", GrPoint = 900 });
            stulist.Add(new Students { StuId = 5, StuName = "Smith", GrPoint = 458 });
            stulist.Add(new Students { StuId = 6, StuName = "Natasa", GrPoint = 700 });
            stulist.Add(new Students { StuId = 7, StuName = "David", GrPoint = 750 });
            stulist.Add(new Students { StuId = 8, StuName = "Harry", GrPoint = 700 });
            stulist.Add(new Students { StuId = 9, StuName = "Nicolash", GrPoint = 597 });
            stulist.Add(new Students { StuId = 10, StuName = "Jenny", GrPoint = 750 });

            //Which maximum grade point(1st, 2nd, 3rd, ...) you want to find  : 3 
            Console.Write("Which maximum grade point(1st, 2nd, 3rd, ...) you want to find  :");
            int nthGrPoints = Convert.ToInt32(Console.ReadLine());

            var res = (from stulistitems in stulist
                       orderby stulistitems.GrPoint descending
                       group stulistitems.GrPoint by stulistitems.GrPoint
                       ).ToList();


            var list = res[nthGrPoints-1];

            List<Students> result = new List<Students>();

            foreach (var item in list)
            {
                 result = (from stulistitems in stulist
                              where stulistitems.GrPoint == item
                              select stulistitems).ToList();
            }  
                foreach(var resultitem in result)
                {
                    Console.WriteLine($"id: {resultitem.StuId} name: {resultitem.StuName} Achived grade points: {resultitem.GrPoint}");
                }

                
                Console.WriteLine();
            
        }
        //7.    linq statement for people with last name that starts with the letter D
        //8.	Number of people whose last name starts with the letter D
        public static void LinqStatementMethod()
        {
            var people = new List<Person>()
        {
            new Person("Bill", "Smith", 41),
            new Person("Sarah", "Jones", 22),
            new Person("Stacy","Baker", 21),
            new Person("Vivianne","Dexter", 19 ),
            new Person("Bob","Smith", 49 ),
            new Person("Brett","Baker", 51 ),
            new Person("Mark","Parker", 19),
            new Person("Alice","Thompson", 18),
            new Person("Evelyn","Thompson", 58 ),
            new Person("Mort","Martin", 58),
            new Person("Eugene","DeLauter", 84 ),
            new Person("Gail","Dawson", 19 ),

        };
            Console.Write("Enter a character to fine all lastname which start from that character: ");
            String s = Console.ReadLine();
            var res = (from peopleItem in people
                       where peopleItem.Lname.StartsWith(s)
                       select peopleItem.Lname).ToList();
            foreach(var resultitem in res)
            {
                Console.WriteLine(resultitem);
            }

            //8.	Number of people whose last name starts with the letter D
            Console.WriteLine($"Number of people whose name startswith {s} are: {res.Count()}");

            //query
            //9.	Write linq statement for first Person Older Than 40 In Descending Alphabetical Order By First Name
            var resdescName = (from peopleItem in people
                               where peopleItem.Age>40
                               orderby peopleItem.Fname descending
                               select peopleItem.Fname).ToList();

      
            foreach(var resultitem in resdescName)
            {
                Console.Write($"{resultitem}, ");
            }

        }
        //10.	Find the words in the collection that start with the letter 'L'
        public static void FindWordsStartsWithL()
        {
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            var outputList = (from froutList in fruits
                              where froutList.StartsWith("L")
                              select froutList).ToList();
            Console.WriteLine("words in the collection that start with the letter 'L'");
            foreach (var resultitem in outputList)
            {
                Console.Write($"{resultitem}, ");
            }
            Console.WriteLine("");

        }

        //11.	Which of the following numbers are multiples of 4 or 6
        public static void Multiple4Or6Method()
        {
            List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var res = (from item in mixedNumbers
                       where item%4==0 && item%6==0
                       select item).ToList();

          Console.WriteLine("The following numbers are multiples of 4 or 6:");
            foreach (var resultitem in res)
            {
                Console.Write($"{resultitem}, ");
            }
            Console.WriteLine();

        }

    }

    internal class Person
    {
       public string Fname { get; set; }
       public string Lname { get; set; }
        public int Age { get; set; }

        public Person(string Fname,string Lname,int Age)
        {
             this.Fname=Fname;
           this.Lname=Lname;
            this.Age=Age;
        }
    }
    internal class Students
    {
        public int StuId { get; set; }
        public string StuName { get; set; }    
        public int GrPoint { get; set; }   

    }
  
}