using CommunityToolkit.Mvvm.ComponentModel;
using System.IO;

namespace Applica.Presentation.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject _selectedViewModel;

        public MainViewModel(ObservableObject homeViewModel)
        {
            _selectedViewModel = homeViewModel;
        }
    }
}
