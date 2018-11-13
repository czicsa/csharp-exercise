using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatistics.Data
{
    public class SentenceStatisticsData
    {
        public int CountOfWordsNotContainedInOtherWords { get; set; }

        public List<WordCountData> WordCountList { get; set; }

        public SentenceStatisticsData()
        {
            WordCountList = new List<WordCountData>();
        }
    }
}
