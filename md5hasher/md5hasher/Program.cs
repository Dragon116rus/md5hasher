using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace md5hasher
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePhrase = Console.ReadLine();
            Md5hasher md5hasher = new Md5hasher();
            string result = md5hasher().hash(sourcePhrase);
            Console.WriteLine(result);
        }
    }
}
