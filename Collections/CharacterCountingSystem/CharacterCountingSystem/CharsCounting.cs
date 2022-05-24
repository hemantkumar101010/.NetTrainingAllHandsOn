using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCountingSystem
{
    internal class CharsCounting
    {
        /*
       * L:1  o:15  r:9  e:26  m:11   :50  i:27  p:7  s:29  u:28  d:4  l:17  t:29  a:22  ,:4  c:17  n:14  g:7  .:8  N:1  q:3  U:1  P:1  h:1  
       * j:1  A:1  v:4  D:2  b:3  V:1  x:1  f:2
       * 
      L: 1 o: 15 r: 9 e: 26 m: 11  : 50 i: 27 p: 7 s: 29 u: 28 d: 4 l: 17 t: 29 a: 22/371 ,: 4 c: 17 n: 14 g: 7 .: 8 N: 1 q: 3 U: 1 P: 1 h: 1 
      j: 1 A: 1 v: 4 D: 2 b: 3 V: 1 x: 1 f: 2
     */
        public static bool isAlphaNumeric(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') ||
                    (c >= '0' && c <= '9');
        }

        //method return a collection of char-frequency pairs in a string
        public Dictionary<char,int> CountFrequencyOfEachString(string myString)
        {
            //string myString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.";
              //{L o r e m  i p s u m  d o l o r s i t a m e t}
            
            //excluding all non-alphabetes from the string 
            myString = String.Concat(Array.FindAll(myString.ToCharArray(), isAlphaNumeric));
            
            char[] charactersInString = myString.ToCharArray();

            //create a dictionary to store character-frequency-pairs in the input string
            Dictionary<char, int> charCountPairs = new Dictionary<char, int>();
            
            //var used for whether a character's frequency checked or not 
            string checkedCharacters = "-1";

            for (int i = 0; i < charactersInString.Length; i++)
            {
                //filter for already checked characters
                if (!checkedCharacters.Contains(charactersInString[i]))
                {
                    int counter = 1;
                    for (int j = i + 1; j < charactersInString.Length; j++)
                    {
                        //comparing one char to remaining chars and according that incrementing counter values
                        if (charactersInString[i] == charactersInString[j])
                            counter++;
                    }
                    //adding a char and total frequency in dectionay
                    charCountPairs.Add(charactersInString[i], counter);

                    //after counting frequency of a char putting that in a string var. for filter purpose
                    checkedCharacters += charactersInString[i];
                }
            }
            return charCountPairs;
        }
    }
}