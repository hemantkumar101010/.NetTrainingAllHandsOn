using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHandsOn
{
    public class Course
    {
        public int CourseId { get; set; }
        public int Duration { get; set; }  
        public string CourseName { get; set; }
    }
    public class LinqHandsOn
    {
        public static void DefferedNImmediateExeMethod()
        {
           List<Course> courseList = new List<Course>
           {
                new Course{ CourseId =1,Duration=2,CourseName="Data Science"},
                new Course{ CourseId =2,Duration=1,CourseName="Web development"},
                new Course{ CourseId =3,Duration=3,CourseName="Cyber security"},
                new Course{ CourseId =4,Duration=1,CourseName="Java programming"},
                new Course{ CourseId =5,Duration=2,CourseName="Dot Net Stack"}
            };

            //accessing list data structure by Linq
            //deffered query execution: defferd query always executed in a foreach loop
            var outputdeffered = from course in courseList
                                 where course.Duration >= 2
                                 select course;

            courseList.Add(new Course { CourseId = 6, Duration = 4, CourseName = "ai" });
            foreach (var course in outputdeffered)
            {
                Console.WriteLine($"courseid: {course.CourseId}, coursename: {course.CourseName}, courseperiod: {course.Duration}");
            }



            // immediate query execution
            var outputImmediate = (from course in courseList
                                    where course.Duration >= 2
                                    select course).Count();

            courseList.Add(new Course { CourseId = 6, Duration = 4, CourseName = "AI" });

            Console.WriteLine($"Total course of duration >=2 are : {outputImmediate}");

        }

        public static void SignleNDefaultSingleMethod()
        {

            //linq single mehtod which take no params

            //Sequence contains one element
            List<int> numbers = new List<int>() {10};
            // it will return the only element which is present in the data source.   
           // int number = numbers.Single();
           // Console.WriteLine(number);
            Console.ReadLine();


            //Sequence contains no element
            List<int> numbers1 = new List<int>() { };
            //When we apply the Single method on an empty data source then it will throw an exception 
            //// If the data source is empty or if the data source contains more than one element, then it throws an exception.
            //int number1 = numbers1.Single();
            //Console.WriteLine(number1);
            Console.ReadLine();


            //single method contains a parameter predicate
            //Note: If your sequence contains more than one element and you need to fetch a single element based on some condition then you need to
            //use the other overloaded versions of the Single method which takes one predicate as a parameter.

            List<int> numbers2 = new List<int>() { 10, 20, 30 };
            // return the only one element from the sequence that satisfy the specific condition and throw exception if there are more then one
            //such element
            int number2 = numbers2.Single(num => num > 20);
            Console.WriteLine(number2);
            Console.ReadLine();



            //Note: If you don’t want to throw an exception when the sequence is empty or if the specified condition does not return an
            //element from a sequence then you need to use the Linq SingleOrDefault method.

            //if the data source is empty then it dont throw exception instead is return default values
            List<int> numbers3 = new List<int>() { 10, 20, 30 };

            //If the specified condition does not return any data then it will not throw an exception instead it returns the default value.
            //will throw exception if the sequence contains more than elements for the specified condition.
            int number3 = numbers3.SingleOrDefault(num => num < 10);
            Console.WriteLine(number3);
            Console.ReadLine();

        }

        public static void FirstNFirstDefaultMethod()
        {

            //Whenever the data source is empty or if the specified condition does not return any data,
            //then we will get the InvalidOperationException 
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //No params in First()
            int MethodSyntax = numbers.First();
            Console.WriteLine(MethodSyntax);
            Console.ReadLine();

            //contain para. predicate
            //method overloaded version return the first element from the data source which is divisible by 2
            int MethodSyntax1 = numbers.First(num => num % 2 == 0);
            Console.WriteLine(MethodSyntax1);
            Console.ReadLine();
            
            //Specified condition doesnot return any element
           // int MethodSyntax2 = numbers.First(num => num > 50);
            Console.ReadLine();

            //Empty Data Source
            List<int> numbersEmpty = new List<int>() { };
            //int MethodSyntax3 = numbersEmpty.First();
            Console.ReadLine();


            //If you don’t want that Invalid Operation Exception, instead you want a default value based on
            //the data type then you need to use the FirstOrDefault method.

            //return the first value
            int MethodSyntax4 = numbers.FirstOrDefault();
            Console.WriteLine(MethodSyntax4);
            Console.ReadLine();

            //return the first matching value
            int MethodSyntax5 = numbers.FirstOrDefault(num => num > 5);
            Console.WriteLine(MethodSyntax5);
            Console.ReadLine();

            //return default value if data source is empty
            int MethodSyntax6 = numbersEmpty.FirstOrDefault();
            Console.WriteLine(MethodSyntax6);



            // First and FirstOrDefault method Using Query Syntax

            int QuerySyntax1 = (from num in numbers
                                select num).First();
            int QuerySyntax2 = (from num in numbers
                                select num).FirstOrDefault();
            Console.WriteLine(QuerySyntax1);
            Console.WriteLine(QuerySyntax2);
            Console.ReadLine();
        }

        public static void GroupByMethod()
        {

        }
    }

}
