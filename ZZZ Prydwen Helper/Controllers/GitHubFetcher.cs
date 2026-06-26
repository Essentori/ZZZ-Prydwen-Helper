using System.Net.Http;

namespace ZZZ_Prydwen_Helper.Controllers
{
    public class GitHubFetcher
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string GitHubCacheBaseUrl = 
                            "https://raw.githubusercontent.com/Essentori/ZZZ-Prydwen-Helper-Cache/refs/heads/main/";

        public async Task<string> FetchCharactersDataAsync()
        {
            return await TryFetchElseReturnNull(GitHubCacheBaseUrl + "characters.json");
        }

        public async Task<string> FetchCharacterStatsDataAsync(string characterName)
        {
            return await TryFetchElseReturnNull($"{GitHubCacheBaseUrl}characters/{characterName}.json");
        }

        private async Task<string> TryFetchElseReturnNull(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
