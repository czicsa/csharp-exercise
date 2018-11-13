using System.Collections.Generic;

namespace TextStatistics.Data
{
    public class SentenceData
    {
        public List<string> Words { get; set; }

        public SentenceData()
        {
            Words = new List<string>();
        }
    }
}
