using Applica.Presentation.ViewModels;
using System.Windows;

namespace Applica.Presentation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            DataContext = new MainViewModel(new HomeViewModel(), new CompaniesViewModel());
        }
    }
}