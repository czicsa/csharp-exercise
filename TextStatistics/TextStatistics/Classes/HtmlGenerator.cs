using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextStatistics.Data;

namespace TextStatistics.Classes
{
    /// <summary>
    /// Html generáló osztály
    /// </summary>
    public static class HtmlGenerator
    {
        /// <summary>
        /// Html generálása
        /// </summary>
        /// <param name="wordCountDataList"></param>
        public static void GenerateHtmlFromSentenceCounts(List<WordCountData> wordCountDataList)
        {
            //létrehozzuk, vagy ha már létezik, felülírjuk a fájlt
            using (StreamWriter writer = new StreamWriter("wordcount.html", false))
            {
                var sampleHtml = Properties.Resources.sample;

                var tableContentHtml = "";
                foreach (var wordCountData in wordCountDataList.OrderBy(x => x.CountOfWords).ToList())
                {
                    tableContentHtml += string.Format("<tr><td>{0}</td><td>{1}</td></tr>", wordCountData.CountOfWords, wordCountData.SentenceCount);
                }

                //beillesztjük a táblázatot a sablonba
                writer.WriteLine(sampleHtml.Replace("{{tableContent}}", tableContentHtml));

                writer.Close();
            }

            //megnyitjuk az elkészült fájlt
            System.Diagnostics.Process.Start("wordcount.html");
        }
    }
}
