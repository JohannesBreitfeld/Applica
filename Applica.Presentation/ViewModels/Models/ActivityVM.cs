using Applica.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;

namespace Applica.Presentation.ViewModels.Models;

public partial class ActivityVM : ObservableObject
{
    public ObjectId Id { get; set; }

    [ObservableProperty]
    private ActivityCategory _category = null!;

    [ObservableProperty]
    private Comment? _comments;

    [ObservableProperty]
    private List<ContactPerson>? _contactPeople;

    [ObservableProperty]
    private DateOnly _date;

    [ObservableProperty]
    private DateOnly? _followUpDate;
}
