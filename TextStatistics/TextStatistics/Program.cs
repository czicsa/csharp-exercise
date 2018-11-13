using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextStatistics.Classes;

namespace TextStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                throw new Exception("Kérem adja meg a fájl elérési útvonalát!");
            }

            Console.WriteLine(@"  _________    __ __ _____   ____________ ");
            Console.WriteLine(@" /_  __/   |  / //_//  _/ | / / ____/ __ \");
            Console.WriteLine(@"  / / / /| | / ,<   / //  |/ / /_  / / / /");
            Console.WriteLine(@" / / / ___ |/ /| |_/ // /|  / __/ / /_/ / ");
            Console.WriteLine(@"/_/ /_/  |_/_/ |_/___/_/ |_/_/    \____/  ");
            Console.WriteLine();
            Console.WriteLine("Feldolgozás.");

            var sentences = FileReader.GetSentencesFromFile(args[0]);

            Console.WriteLine("Mondatok felolvasva.");

            var sentenceStatistics = SentenceStatisticsSolver.GetSentenceStatistics(sentences);

            Console.WriteLine("Statisztikák kiszámolva.");

            HtmlGenerator.GenerateHtmlFromSentenceCounts(sentenceStatistics.WordCountList);

            Console.WriteLine("HTML fájl elkészült.");

            Console.WriteLine("{0} db olyan szó van, amit nem tartalmaz másik szó.", sentenceStatistics.CountOfWordsNotContainedInOtherWords);


            Console.ReadKey();
        }
    }
}
