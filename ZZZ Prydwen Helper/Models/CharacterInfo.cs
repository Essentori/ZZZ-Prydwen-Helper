using System.Collections.Generic;

namespace ZZZ_Prydwen_Helper.Models
{
    public class CharacterInfo
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Rarity { get; set; }
        public string Element { get; set; } //Attribute
        public string Style { get; set; } //Role
        public string Faction { get; set; }
        public string SmallImage { get; set; }
        public StatsCharacterInfo StatsInfo { get; set; } = new StatsCharacterInfo();
    }
    public class CharactersFileDTO
    {
        public string Version { get; set; }
        public List<CharacterInfoDTO> Characters { get; set; }
    }

    public class CharacterInfoDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Rarity { get; set; }
        public string Element { get; set; }
        public string Style { get; set; }
        public string Faction { get; set; }
        public string SmallImage { get; set; }
        public string LastUpdated { get; set; }
    }
}
