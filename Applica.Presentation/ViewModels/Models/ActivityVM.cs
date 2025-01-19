using Applica.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;

namespace Applica.Presentation.ViewModels.Models;

public partial class ActivityVM : ObservableObject
{
    public ObjectId Id { get; set; }

    [ObservableProperty]
    private ActivityCategoryVM _category = null!;

    [ObservableProperty]
    private string? _description;

    [ObservableProperty]
    private DateOnly _date;

    [ObservableProperty]
    private DateOnly? _followUpDate;
}
