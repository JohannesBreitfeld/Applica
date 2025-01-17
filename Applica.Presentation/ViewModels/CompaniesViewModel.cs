using Applica.Presentation.ViewModels.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace Applica.Presentation.ViewModels;

internal partial class CompaniesViewModel : ObservableObject
{
    [ObservableProperty]
    private CompanyVM? _selectedCompany;

    public ICommand OpenCompanyDetailsCommand { get; }

    
    public CompaniesViewModel()
    {
       
    }
}
