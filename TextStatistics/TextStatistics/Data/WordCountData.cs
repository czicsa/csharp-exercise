namespace TextStatistics.Data
{
    /// <summary>
    /// Egy olyan osztály, ami megmutatja, hogy adott darabszámú mondatból hány darab van
    /// </summary>
    public class WordCountData
    {
        /// <summary>
        /// Szavak száma a mondatban
        /// </summary>
        public int CountOfWords { get; set; }

        /// <summary>
        /// Hány darab adott szószámú mondat van
        /// </summary>
        public int SentenceCount { get; set; }
    }
}
