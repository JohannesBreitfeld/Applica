using Applica.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;

namespace Applica.Presentation.ViewModels.Models;

public partial class ActivityVM : ObservableObject
{
    public ObjectId Id { get; set; }

    [ObservableProperty]
    private string? _category = string.Empty;

    [ObservableProperty]
    private string? _description;

    [ObservableProperty]
    private DateOnly _date;

    [ObservableProperty]
    private DateOnly? _followUpDate;

    private bool _hasNotification = false;

    public bool HasNotification
    {
        get
        {
            return FollowUpDate <= DateOnly.FromDateTime(DateTime.Now) ? true : false;
        }
        set => _hasNotification = value;
    }


}
