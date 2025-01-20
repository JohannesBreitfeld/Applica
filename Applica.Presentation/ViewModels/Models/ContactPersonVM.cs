using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;

namespace Applica.Presentation.ViewModels.Models
{
    public partial class ContactPersonVM : ObservableObject
    {
        public ObjectId Id { get; set; }

        [ObservableProperty]
        private string _name = null!;

        [ObservableProperty]
        private string? _phone;

        [ObservableProperty]
        private string? _email;
    }
}
