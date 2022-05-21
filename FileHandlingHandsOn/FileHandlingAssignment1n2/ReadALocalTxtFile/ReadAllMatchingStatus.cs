using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadALocalTxtFile
{
    internal class ReadAllMatchingStatus
    {
        public void WriteFile()
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\networkLogs1.txt", FileMode.Create, FileAccess.Write);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
        }

       public void Success()
        {
            ReadAllMatchingStatus readAllMatchingStatusObj = new ReadAllMatchingStatus();
            readAllMatchingStatusObj.ReadFile("Success");
        }
       public void Failed()
        {
            ReadAllMatchingStatus readAllMatchingStatusObj = new ReadAllMatchingStatus();
            readAllMatchingStatusObj.ReadFile("Failed");
        }
        public void Dialled()
        {
            ReadAllMatchingStatus readAllMatchingStatusObj = new ReadAllMatchingStatus();
            readAllMatchingStatusObj.ReadFile("Dialled");
        }
       public void Missed()
        {
            ReadAllMatchingStatus readAllMatchingStatusObj = new ReadAllMatchingStatus();
            readAllMatchingStatusObj.ReadFile("Missed");
        }

        //ReadFile method Takes Status as a input and print all records of same status  
        public void ReadFile(String status)
        {
            FileStream fileStreamObj = new FileStream(@"C:\Users\iamte\Desktop\networkLogs1.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReaderObj = new StreamReader(fileStreamObj);
            Console.WriteLine("Id\tSource\t\tDestination\tDate\t    Time\tStatus\t   Network");
            
            //declaring a empty string for concatanate line between empty lines and then search for desired status records
            
            string result = "";
            while (streamReaderObj.Peek() > 0)
            {
                string line = streamReaderObj.ReadLine();
                if (line != "")
                {                
                        if (line.StartsWith("Date"))
                        {
                            string[] dateNTimeArr = line.Split(' ');
                            string[] dateArr = dateNTimeArr[0].Split(':');
                            result = result + dateArr[1]+"   ";
                            result  = result + dateNTimeArr[1]+"\t";
                        }
                        else
                        {
                            string[] myValues = line.Split(':');
                            if (myValues[0] == "Network")
                            {
                                result += "   "+myValues[1];
                                if (result.Contains(status))
                                {
                                    Console.WriteLine(result);
                                }
                                result = "";
                            }
                            else
                            {
                                result =result + myValues[1] +"\t";
                            }
                        }              
                }
            }

        
        }
    }
}