using CommunityToolkit.Mvvm.ComponentModel;

namespace Applica.Presentation.ViewModels
{
    internal partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _numberOfApplications = 0;
        [ObservableProperty]
        private int _numberOfOffers = 0;
        [ObservableProperty]
        private int _numberOfRejections = 0;

    }
}
