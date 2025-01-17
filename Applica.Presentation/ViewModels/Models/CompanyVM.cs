using Applica.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;

namespace Applica.Presentation.ViewModels.Models
{
    public partial class CompanyVM :ObservableObject
    {
        public ObjectId Id { get; set; }

        [ObservableProperty]
        private string _name = null!;

        [ObservableProperty]
        private string? _url;

        [ObservableProperty]
        private List<Activity>? _activities;

        [ObservableProperty]
        private List<Comment>? _comments;

        [ObservableProperty]
        private List<ContactPerson>? _contactPeople;
    }
}
