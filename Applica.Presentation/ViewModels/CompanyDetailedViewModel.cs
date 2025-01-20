using Applica.Presentation.Services;
using Applica.Presentation.ViewModels.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Applica.Presentation.ViewModels
{
    public partial class CompanyDetailedViewModel : ObservableObject
    {
        private readonly CompanyService companyService;
        public MainViewModel MainViewModel { get; }
        public CompaniesViewModel CompaniesViewModel { get; }

        [ObservableProperty]
        private ObservableCollection<ActivityCategoryVM> _categories = new ObservableCollection<ActivityCategoryVM>() { new ActivityCategoryVM() { Description = "Loading.."} };

        public ICommand OpenLinkCommand { get; }
        public ICommand AddNewContactPersonCommand { get; }
        public ICommand DeleteContactPersonCommand { get; }
        public ICommand AddNewActivityCommand { get; }
        public ICommand DeleteActivityCommand { get; }
        public ICommand AddNewCommentCommand { get; }
        public ICommand DeleteCommentCommand { get; }
        public ICommand ReturnCommand { get; }

        public CompanyDetailedViewModel(MainViewModel mainViewModel, CompaniesViewModel companiesViewModel, CompanyService companyService)
        {
            MainViewModel = mainViewModel;
            CompaniesViewModel = companiesViewModel;
            this.companyService = companyService;
     
            OpenLinkCommand = new RelayCommand(OpenLink);
            AddNewContactPersonCommand = new RelayCommand(AddNewContactPerson);
            DeleteContactPersonCommand = new RelayCommand<ContactPersonVM>(scp => CompaniesViewModel?.SelectedCompany?.ContactPeople.Remove(scp!), scp => scp is not null);
            AddNewActivityCommand = new RelayCommand(AddNewActivity);
            DeleteActivityCommand = new RelayCommand<ActivityVM>(sa => CompaniesViewModel?.SelectedCompany?.Activities?.Remove(sa!), sa => sa is not null);
            AddNewCommentCommand = new RelayCommand(AddNewComment);
            DeleteCommentCommand = new RelayCommand<CommentVM>(sc => CompaniesViewModel?.SelectedCompany?.Comments?.Remove(sc!), sc => sc is not null);
            ReturnCommand = new RelayCommand(Return);
        }

        private void Return()
        {
            MainViewModel.SelectedViewModel = CompaniesViewModel;
        }

        private void AddNewComment()
        {
            CompaniesViewModel!.SelectedCompany!.SelectedComment = new CommentVM() { Label = "New comment", Date = DateOnly.FromDateTime(DateTime.Now) };
            CompaniesViewModel?.SelectedCompany?.Comments?.Add(CompaniesViewModel.SelectedCompany.SelectedComment);
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
