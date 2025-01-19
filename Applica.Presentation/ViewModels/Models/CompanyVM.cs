using Applica.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using Applica.Presentation.ViewModels;

namespace Applica.Presentation.ViewModels.Models
{
    public partial class CompanyVM :ObservableObject
    {
        public ObjectId Id { get; set; }

        [ObservableProperty]
        private ContactPersonVM? _selectedContactPerson;

        [ObservableProperty]
        private ActivityVM? _selectedActivity;

        [ObservableProperty]
        private string _name = null!;

        [ObservableProperty]
        private string? _url;

        [ObservableProperty]
        private ObservableCollection<ActivityVM>? _activities = new ObservableCollection<ActivityVM>();

        [ObservableProperty]
        private ObservableCollection<CommentVM>? _comments = new ObservableCollection<CommentVM>();

        [ObservableProperty]
        private ObservableCollection<ContactPersonVM> _contactPeople = new ObservableCollection<ContactPersonVM>();
    }
}
