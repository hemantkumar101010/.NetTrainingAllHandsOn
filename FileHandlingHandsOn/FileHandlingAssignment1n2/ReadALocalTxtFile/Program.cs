using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadALocalTxtFile
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //First Assignment
            ReadFromTxtFile readFromTxtFile = new ReadFromTxtFile();
            readFromTxtFile.ReadFile(); 


            //Second assignment
            ReadAllMatchingStatus readAllMatchingStatus = new ReadAllMatchingStatus();

            readAllMatchingStatus.Success();
            //readAllMatchingStatus.Failed();
            //readAllMatchingStatus.Dialled();
            //readAllMatchingStatus.Missed();


        }
    }
}
