using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextStatistics.Data;

namespace TextStatistics.Classes
{
    public static class SentenceStatisticsSolver
    {
        /// <summary>
        /// Visszaadja a mondatok a statisztikáját
        /// </summary>
        /// <param name="sentences"></param>
        /// <returns></returns>
        public static SentenceStatisticsData GetSentenceStatistics(List<SentenceData> sentences)
        {
            var result = new SentenceStatisticsData();

            // --- kigyűjtjük a szavakat a mondatokból
            var distinctWords = new List<string>();

            // --- végigmegyünk a mondatokon, hogy előállítsuk a mondatokban szereplő szavak számának statisztikáját
            foreach (var sentence in sentences)
            {
                // --- elkérjük, hogy hány darab szó van a mondatban
                var wordCountInSentence = sentence.Words.Count;

                // --- megnézzük, hogy volt-e már olyan mondat, amiben ugyanennyi szó van, ha volt, akkor növeljük a darabszámát
                if (result.WordCountList.Any(x => x.CountOfWords == wordCountInSentence))
                {
                    result.WordCountList.FirstOrDefault(x => x.CountOfWords == wordCountInSentence).SentenceCount++;
                }
                // --- ha nem volt, létrehozunk egy ennyi darab szóval rendelkező mondat számlálót
                else
                {
                    result.WordCountList.Add(new WordCountData()
                    {
                        CountOfWords = wordCountInSentence,
                        SentenceCount = 1
                    });
                }

                // --- elrakjuk a szavakat
                foreach (var word in sentence.Words)
                {
                    distinctWords.Add(word.ToLower());
                }
            }

            // --- ne legyenek szóismétlések
            distinctWords = distinctWords.Distinct().ToList();
            var distinctWordCount = distinctWords.Count;

            // --- összeszedjük, hogy hány darab olyan szó van, amit nem tartalmaz más szó
            var sourceDistinctWordIndex = 0;
            do
            {
                // --- kivesszük a vizsgált szót
                var sourceDistinctWord = distinctWords[sourceDistinctWordIndex];
                var isSourceContainedByTarget = false;
                var targetDistinctWordIndex = 1;

                do
                {
                    // --- kivesszük a tartalmazó szót
                    var targetDistinctWord = distinctWords[targetDistinctWordIndex];

                    // --- akkor érdemes megnézni, hogy benne van-e egyik a másikban, ha nem ugyanaz, és a tartalmazó szó hosszabb, mint a vizsgált szó
                    if (sourceDistinctWordIndex != targetDistinctWordIndex && sourceDistinctWord.Length < targetDistinctWord.Length)
                    {
                        // --- ha benne van a vizsgált szó a tartalmazóban, akkor ez a szó nem számolható bele a végeredménybe
                        if (targetDistinctWord.IndexOf(sourceDistinctWord) != -1)
                        {
                            isSourceContainedByTarget = true;
                        }
                    }

                    // --- léptetjük a tartalmazó szó számlálót
                    targetDistinctWordIndex++;
                // --- addig lépkedünk, míg nincs olyan szó, ami tartalmazná a vizsgált szót, vagy elfogynak a tartalmazó szavak
                } while (!isSourceContainedByTarget && targetDistinctWordIndex < distinctWordCount);

                // --- ha nem találtunk tartalmazó szót, akkor növeljük a számlálót
                if (!isSourceContainedByTarget)
                {
                    result.CountOfWordsNotContainedInOtherWords++;
                }

                // --- növeljük a vizsgált szó számlálót
                sourceDistinctWordIndex++;
            // --- addig lépkedünk, míg el nem fogynak a vizsgált szavak
            } while (sourceDistinctWordIndex < distinctWordCount);

            return result;
        }
    }
}
