using Applica.Presentation.Services;
using Applica.Presentation.ViewModels;
using System.Windows;

namespace Applica.Presentation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CompanyService companyService;
        private readonly MainViewModel mainViewModel;

        
        public MainWindow()
        {
            companyService = new CompanyService();
            mainViewModel = new MainViewModel(companyService);
            InitializeComponent();
            DataContext = mainViewModel;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(mainViewModel.CompaniesViewModel.SelectedCompany is not null)
            {
                
                await companyService.UpdateAsync(mainViewModel.CompaniesViewModel.SelectedCompany);

            }
        }
    }
}