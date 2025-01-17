using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;

namespace Applica.Presentation.ViewModels.Models
{
    public partial class ActivityCategoryVM : ObservableObject
    {
        public ObjectId Id { get; set; }

        [ObservableProperty]
        private string _description = null!;
    }
}
