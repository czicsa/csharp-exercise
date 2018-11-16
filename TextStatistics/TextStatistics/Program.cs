using System;
using System.IO;
using TextStatistics.Classes;

namespace TextStatistics
{
    /// <summary>
    /// A futtatandó program
    /// </summary>
    class Program
    {
        //az igen konstans
        const string YES = "y";
        //a nem konstans
        const string NO = "n";

        /// <summary>
        /// A program belépési pontja
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Console.WriteLine(@"Csapat neve: Andrássy-10.D\n");

            var fileSource = "";
            do
            {
                Console.WriteLine("Saját fájlt szeretne beolvasni ({0}) vagy a mellékelt teszt fájlt ({1})?", YES, NO);
                fileSource = Console.ReadLine().ToLower();

            } while (!fileSource.Equals(YES) && !fileSource.Equals(NO));

            var filePath = "../../sample.txt";
            do
            {
                if (fileSource.Equals(YES))
                {
                    Console.WriteLine("Kérem adja meg a fájl elérési útvonalát:");
                    filePath = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(filePath))
                    {
                        //megvizsgáljuk, hogy létezik-e a fájl, ha nem értesítjük a felhasználót
                        if (!File.Exists(filePath))
                        {
                            Console.WriteLine("A fájl nem található!");
                            filePath = "";
                        }
                    }
                }

            } while (string.IsNullOrWhiteSpace(filePath));
            
            Console.WriteLine("Feldolgozás.");

            var sentences = FileReader.GetSentencesFromFile(filePath);

            Console.WriteLine("Mondatok felolvasva.");

            var sentenceStatistics = SentenceStatisticsSolver.GetSentenceStatistics(sentences);

            Console.WriteLine("Statisztikák kiszámolva.");

            HtmlGenerator.GenerateHtmlFromSentenceCounts(filePath, sentenceStatistics.WordCountList);

            Console.WriteLine("HTML fájl elkészült.");

            Console.WriteLine("{0} db olyan szó van, amit nem tartalmaz másik szó.", sentenceStatistics.CountOfWordsNotContainedInOtherWords);

            Console.ReadKey();
        }
    }
}
