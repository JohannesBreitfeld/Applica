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
                    activities += $"{activity.Category} {activity.Date}";
                }
                else
                {
                    activities += $"{activity.Category} {activity.Date}  -  ";
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

    private bool _hasNotification = false;

    public bool HasNotification
    {
        get
        {
            var returnValue = false;
            foreach (var activity in Activities)
            {
                if (activity.FollowUpDate <= DateOnly.FromDateTime(DateTime.Now))
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }
        set => _hasNotification = value;

    }
    private DateOnly? _closestFollowUp = null;

    public DateOnly? ClosestFollowUp
    {
        get
        {
          var nearestFollowUp = Activities
                .Where(a => a.FollowUpDate.HasValue)
                .OrderBy(a => a.FollowUpDate)
                .FirstOrDefault();

            return nearestFollowUp?.FollowUpDate;
        }
        set => _closestFollowUp = value;

    }


    public event Action? SelectedActivityChanged;

    partial void OnSelectedActivityChanged(ActivityVM? value)
    {
        SelectedActivityChanged?.Invoke();
    }
}
