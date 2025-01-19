using Applica.Presentation.ViewModels.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Windows.Input;

namespace Applica.Presentation.ViewModels
{
    public partial class CompanyDetailedViewModel : ObservableObject
    {
        public ObservableObject MainViewModel { get; }
        public CompaniesViewModel CompaniesViewModel { get; }

        public ICommand OpenLinkCommand { get; }
        public ICommand AddNewContactPersonCommand { get; }
        public ICommand DeleteContactPersonCommand { get; }
        public ICommand AddNewActivityCommand { get; }

        public CompanyDetailedViewModel(MainViewModel mainViewModel, CompaniesViewModel companiesViewModel)
        {
            MainViewModel = mainViewModel;
            CompaniesViewModel = companiesViewModel;
     
            OpenLinkCommand = new RelayCommand(OpenLink);
            AddNewContactPersonCommand = new RelayCommand(AddNewContactPerson);
            DeleteContactPersonCommand = new RelayCommand<ContactPersonVM>(cp => CompaniesViewModel?.SelectedCompany?.ContactPeople.Remove(cp!), cp=> cp != null);
            AddNewActivityCommand = new RelayCommand(AddNewActivity);
        }

        private void AddNewActivity()
        {
            CompaniesViewModel!.SelectedCompany!.SelectedActivity = new ActivityVM() { Category = new ActivityCategoryVM() { Description = "Application" }, Date = DateOnly.FromDateTime(DateTime.Now) };
            CompaniesViewModel?.SelectedCompany?.Activities!.Add(CompaniesViewModel.SelectedCompany.SelectedActivity);
        }

        private void AddNewContactPerson()
        {
            CompaniesViewModel!.SelectedCompany!.SelectedContactPerson = new ContactPersonVM() { Name = "New contact" };
            CompaniesViewModel.SelectedCompany!.ContactPeople.Add(CompaniesViewModel.SelectedCompany.SelectedContactPerson);
        }
       
        private void OpenLink()
        {
            string url = CompaniesViewModel?.SelectedCompany?.Url!;
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
