using System.Collections.Generic;

namespace TextStatistics.Data
{
    /// <summary>
    /// Egy mondat osztálya
    /// </summary>
    public class SentenceData
    {
        /// <summary>
        /// Szavak a mondatban
        /// </summary>
        public List<string> Words { get; set; }

        /// <summary>
        /// Mondat konstruktora
        /// </summary>
        public SentenceData()
        {
            Words = new List<string>();
        }
    }
}
