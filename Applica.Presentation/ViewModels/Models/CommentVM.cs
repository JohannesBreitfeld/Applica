using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;

namespace Applica.Presentation.ViewModels.Models
{
    public partial class CommentVM : ObservableObject
    {
        public ObjectId Id { get; set; }

        [ObservableProperty]
        private string _label = null!;

        [ObservableProperty]
        private DateOnly _date;

        [ObservableProperty]
        private string? _content;

    }
}
