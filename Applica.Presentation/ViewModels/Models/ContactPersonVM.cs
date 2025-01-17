using CommunityToolkit.Mvvm.ComponentModel;

namespace Applica.Presentation.ViewModels.Models
{
    public partial class ContactPersonVM : ObservableObject
    {
        [ObservableProperty]
        private string _name = null!;

        [ObservableProperty]
        private string? _phone;

        [ObservableProperty]
        private string? _email;
    }
}
