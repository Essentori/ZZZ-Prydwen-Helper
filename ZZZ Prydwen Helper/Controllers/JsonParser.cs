using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using ZZZ_Prydwen_Helper.Models;

namespace ZZZ_Prydwen_Helper.Controllers
{
    public static class JsonParser
    {
        public static List<CharacterInfo> ParseCharacters(string jsonString)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var root = JsonSerializer.Deserialize<CharactersFileDTO>(jsonString, options);

            if (root?.Characters == null) return new List<CharacterInfo>();

            return root.Characters.Select(dto => new CharacterInfo
            {
                Name = dto.Name,
                Link = dto.Link,
                Rarity = dto.Rarity,
                Element = dto.Element,
                Style = dto.Style,
                Faction = dto.Faction,
                SmallImage = dto.SmallImage
            }).ToList();
        }
    }
}
