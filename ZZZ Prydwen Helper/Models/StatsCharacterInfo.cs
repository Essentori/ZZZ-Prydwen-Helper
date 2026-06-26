using System.Collections.Generic;

namespace ZZZ_Prydwen_Helper.Models
{
    public struct StatInfo
    {
        string Object;
        string Value;
    }
    public class StatsCharacterInfo
    {
        public List<StatInfo> BestWEngines { get; set; } = new List<StatInfo>();
        public List<StatInfo> BestDiskSets { get; set; } = new List<StatInfo>();
        public List<StatInfo> MainStats { get; set; } = new List<StatInfo>();
        public List<string> SubStatsOrder { get; set; } = new List<string>();
        public List<StatInfo> EndgameStats { get; set; } = new List<StatInfo>();
    }
}
