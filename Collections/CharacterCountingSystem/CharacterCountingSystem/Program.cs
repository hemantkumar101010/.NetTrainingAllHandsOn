using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCountingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CharsCounting charsCounting = new CharsCounting();
            charsCounting.CountFrequencyOfEachString();

        }
    }
}
