using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using ZZZ_Prydwen_Helper.Controllers;

namespace ZZZ_Prydwen_Helper.Models
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string characterInfoText;
        private string initializeButtonContent = "Initialize Data";
        private bool initializeButtonEnabled = true;
        private bool isDropdownEnabled = false;
        private CharacterInfo selectedCharacter;
        public readonly string FilePath;

        public ObservableCollection<CharacterInfo> Characters { get; } = new ObservableCollection<CharacterInfo>();

        public string CharacterInfoText { get => characterInfoText; set { characterInfoText = value; OnPropertyChanged(); } }
        public string ButtonContent { get => initializeButtonContent; set { initializeButtonContent = value; OnPropertyChanged(); } }
        public bool IsDropdownEnabled { get => isDropdownEnabled; set { isDropdownEnabled = value; OnPropertyChanged(); } }
        public bool ButtonEnabled { get => initializeButtonEnabled; set { initializeButtonEnabled = value; OnPropertyChanged(); } }

        public CharacterInfo SelectedCharacter
        {
            get => selectedCharacter;
            set
            {
                selectedCharacter = value;
                OnPropertyChanged();
                UpdateCharacterInfo();
            }
        }

        public MainWindowViewModel()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            FilePath = Path.Combine(folderPath, "characters.json");
        }

        public async Task InitializeData(bool forceUpdate)
        {
            IsDropdownEnabled = false;
            selectedCharacter = null;
            UpdateCharacterInfo();
            ButtonContent = "Loading data... Please wait!";
            ButtonEnabled = false;

            string json;
            if (!File.Exists(FilePath) || forceUpdate)
            {
                var fetcher = new GitHubFetcher();
                json = await fetcher.FetchCharactersDataAsync();
                File.WriteAllText(FilePath, json);
            }
            else json = File.ReadAllText(FilePath);

            var data = JsonParser.ParseCharacters(json);
            Characters.Clear();
            foreach (var character in data) Characters.Add(character);

            ButtonEnabled = true;
            IsDropdownEnabled = true;
            ButtonContent = "Loaded!";
        }


        private void UpdateCharacterInfo()
        {
            if (SelectedCharacter == null) 
                CharacterInfoText = string.Empty;
            else 
                CharacterInfoText = $"{SelectedCharacter.Name} | {SelectedCharacter.Rarity}\n" +
                               $"Attribute: {SelectedCharacter.Element}\n" +
                               $"Role: {SelectedCharacter.Style}\n" +
                               $"Faction: {SelectedCharacter.Faction}";
        }
    }
}
