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
        public void CountFrequencyOfEachString()
        {
            string myString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.";
            char[] charactersInString = myString.ToCharArray();  //{L o r e m  i p s u m  d o l o r s i t a m e t}

            //var used for weathe a character's frequency checked or not 
            string updateString = "2";

            for (int i = 0; i < charactersInString.Length; i++)
            {
                //filter for already checked characters
                if (!updateString.Contains(charactersInString[i]))
                {
                    int counter = 1;
                    for (int j = i + 1; j < charactersInString.Length; j++)
                    {
                        //comparing one char to remaining chars and acrding that incrementing counter values
                        if (charactersInString[i] == charactersInString[j])
                            counter++;

                    }
                    Console.WriteLine(charactersInString[i] + ":" + " " + counter);
                    //if a chars gets all frequency then at last store it to updateString 
                    updateString += charactersInString[i];
                }
            }
        }
    }
}