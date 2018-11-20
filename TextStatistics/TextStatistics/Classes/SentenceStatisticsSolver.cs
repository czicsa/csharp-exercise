using System;
using System.Collections.Generic;
using System.Linq;
using TextStatistics.Data;

namespace TextStatistics.Classes
{
    /// <summary>
    /// Statisztikákat készítő osztály
    /// </summary>
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

            var words = new List<string>();

            //végigmegyünk a mondatokon, hogy előállítsuk a mondatokban szereplő szavak számának statisztikáját
            foreach (var sentence in sentences)
            {
                var wordCountInSentence = sentence.Words.Count;

                //megnézzük, hogy volt-e már olyan mondat, amiben ugyanennyi szó van, ha volt, akkor növeljük a darabszámát
                if (result.WordCountList.Any(x => x.CountOfWords == wordCountInSentence))
                {
                    result.WordCountList.FirstOrDefault(x => x.CountOfWords == wordCountInSentence).SentenceCount++;
                }
                //ha nem volt, létrehozunk egy ennyi darab szóval rendelkező mondat számlálót
                else
                {
                    result.WordCountList.Add(new WordCountData()
                    {
                        CountOfWords = wordCountInSentence,
                        SentenceCount = 1
                    });
                }

                //elrakjuk a szavakat
                foreach (var word in sentence.Words)
                {
                    words.Add(word);
                }
            }

            //összeszedjük, hogy hány darab olyan szó van, amit nem tartalmaz más szó
            var sourceWordIndex = 0;
            do
            {
                //kivesszük a vizsgált szót
                var sourceWord = words[sourceWordIndex];
                var isSourceContainedByTarget = false;
                var targetWordIndex = 0;

                do
                {
                    //kivesszük a tartalmazó szót
                    var targetWord = words[targetWordIndex];

                    //akkor érdemes megnézni, hogy benne van-e egyik a másikban, ha nem ugyanaz, és a tartalmazó szó legalább olyan hosszú, mint a vizsgált szó
                    //a részhalmaz definíciója szerint minden halmaz önmagának is részhalmaza, ezért a szóismétlések is tartalmazzák egymást
                    if (sourceWordIndex != targetWordIndex && sourceWord.Length <= targetWord.Length)
                    {
                        //ha benne van a vizsgált szó a tartalmazóban, akkor ez a szó nem számolható bele a végeredménybe
                        //ékezetes betűk miatt szükség van az ordinális string összehasonlításra
                        if (targetWord.IndexOf(sourceWord, StringComparison.Ordinal) != -1)
                        {
                            isSourceContainedByTarget = true;
                        }
                    }

                    targetWordIndex++;
                //addig lépkedünk, míg nincs olyan szó, ami tartalmazná a vizsgált szót, vagy elfogynak a tartalmazó szavak
                } while (!isSourceContainedByTarget && targetWordIndex < words.Count);

                //ha nem találtunk tartalmazó szót, akkor növeljük a számlálót
                if (!isSourceContainedByTarget)
                {
                    result.CountOfWordsNotContainedInOtherWords++;
                }

                sourceWordIndex++;
            } while (sourceWordIndex < words.Count);

            return result;
        }
    }
}
