using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZZZ_Prydwen_Helper.Models;

namespace ZZZ_Prydwen_Helper
{
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; } = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private async void InitializeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ButtonContent == "Loaded!")
            {
                var result = MessageBox.Show(
                    $"Data is saved localy on {ViewModel.FilePath}. Do you want to update it?",
                    "Data update confirm",
                    MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) await ViewModel.InitializeData(true);
            }
            else
            {
                await ViewModel.InitializeData(false);
            }
        }
    }
}