using Applica.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using Applica.Presentation.ViewModels;
using System.ComponentModel;

namespace Applica.Presentation.ViewModels.Models;

public partial class CompanyVM :ObservableObject
{
    public ObjectId Id { get; set; }

    [ObservableProperty]
    private ContactPersonVM? _selectedContactPerson;

    [ObservableProperty]
    private ActivityVM? _selectedActivity;

    [ObservableProperty]
    private CommentVM? _selectedComment;

    [ObservableProperty]
    private string _name = null!;

    [ObservableProperty]
    private string? _url;

    [ObservableProperty]
    private ObservableCollection<ActivityVM> _activities = new ObservableCollection<ActivityVM>();

    [ObservableProperty]
    private ObservableCollection<CommentVM> _comments = new ObservableCollection<CommentVM>();

    [ObservableProperty]
    private ObservableCollection<ContactPersonVM> _contactPeople = new ObservableCollection<ContactPersonVM>();

    private string? _activitiesString;
    public string? ActivitiesString
    {
        get
        {
            string activities = string.Empty;

            foreach (var activity in Activities)
            {
                if (Activities.Count() == 1 || activity == Activities.LastOrDefault())
                {
                    activities += activity.Category;
                }
                else
                {
                    activities += $"{activity.Category} - ";
                }
            }

            ActivitiesString = activities;
            return activities;
        }
        set
        {
          SetProperty(ref _activitiesString, value);
        }
    }

    //public event Action? CompanyInfoChanged;

    //public CompanyVM()
    //{

    //    _activities.CollectionChanged += (s, e) => SubscribeToChangesInCollection(_activities);
    //    _comments.CollectionChanged += (s, e) => SubscribeToChangesInCollection(_comments);
    //    _contactPeople.CollectionChanged += (s, e) => SubscribeToChangesInCollection(_contactPeople);

    //    SubscribeToChangesInCollection(_activities);
    //    SubscribeToChangesInCollection(_comments);
    //    SubscribeToChangesInCollection(_contactPeople);
    //}

    //private void SubscribeToChangesInCollection<T>(ObservableCollection<T> collection) where T : ObservableObject
    //{
    //    foreach (var item in collection)
    //    {
    //        if (item is INotifyPropertyChanged observableItem)
    //        {
    //            observableItem.PropertyChanged += Item_PropertyChangedExternally;
    //        }
    //    }
    //}

    //private void Item_PropertyChangedExternally(object? sender, PropertyChangedEventArgs e)
    //{
    //     CompanyInfoChanged?.Invoke();
    //}

    //public void AddActivity(ActivityVM activity)
    //{
    //    Activities.Add(activity);
    //    activity.PropertyChanged += Item_PropertyChangedExternally;
    //}

    //partial void OnNameChanged(string value)
    //{
    //    CompanyInfoChanged?.Invoke();
    //}

    //partial void OnUrlChanged(string? value)
    //{
    //    CompanyInfoChanged?.Invoke();
    //}
}
