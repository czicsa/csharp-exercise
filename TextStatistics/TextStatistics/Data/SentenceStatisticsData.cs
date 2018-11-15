using System.Collections.Generic;

namespace TextStatistics.Data
{
    /// <summary>
    /// Mondatok alapján készített statisztika osztálya
    /// </summary>
    public class SentenceStatisticsData
    {
        /// <summary>
        /// Azons szavak száma, amelyeket nem tartalmaz másik szó
        /// </summary>
        public int CountOfWordsNotContainedInOtherWords { get; set; }

        /// <summary>
        /// Olyan osztályok listája, amelyek megmutatják, hogy adott darabszámú mondatból hány darab van
        /// </summary>
        public List<WordCountData> WordCountList { get; set; }

        /// <summary>
        /// Statisztika konstruktora
        /// </summary>
        public SentenceStatisticsData()
        {
            WordCountList = new List<WordCountData>();
        }
    }
}
