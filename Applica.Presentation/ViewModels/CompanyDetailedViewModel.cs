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
        private readonly CategoryService categoryService;
        private string? oldCategoryValue;
        
        public MainViewModel MainViewModel { get; }
        public CompaniesViewModel CompaniesViewModel { get; }

        [ObservableProperty]
        private bool _isEditingCategory;

        [ObservableProperty]
        private ObservableCollection<ActivityCategoryVM> _categories = new ObservableCollection<ActivityCategoryVM>();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(EditCategoryCommand))]
        private ActivityCategoryVM? _selectedCategory;

        [ObservableProperty]
        private bool _isEditingWebsite; 

        public ICommand OpenLinkCommand { get; }
        public ICommand AddNewContactPersonCommand { get; }
        public ICommand DeleteContactPersonCommand { get; }
        public ICommand AddNewActivityCommand { get; }
        public ICommand DeleteActivityCommand { get; }
        public ICommand AddNewCommentCommand { get; }
        public ICommand DeleteCommentCommand { get; }
        public ICommand ReturnCommand { get; }
        public ICommand EditWebsiteCommand { get; }
        public ICommand AddNewCategoryCommand { get; }
        public IRelayCommand EditCategoryCommand { get; }
        public ICommand SaveCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }

        public CompanyDetailedViewModel(MainViewModel mainViewModel, CompaniesViewModel companiesViewModel, CompanyService companyService)
        {
            MainViewModel = mainViewModel;
            CompaniesViewModel = companiesViewModel;
            this.companyService = companyService;
            categoryService = new CategoryService();
     
            OpenLinkCommand = new RelayCommand(OpenLink);
            AddNewContactPersonCommand = new RelayCommand(AddNewContactPerson);
            DeleteContactPersonCommand = new RelayCommand<ContactPersonVM>(scp => CompaniesViewModel?.SelectedCompany?.ContactPeople.Remove(scp!), scp => scp is not null);
            AddNewActivityCommand = new RelayCommand(AddNewActivity);
            DeleteActivityCommand = new RelayCommand<ActivityVM>(sa => CompaniesViewModel?.SelectedCompany?.Activities?.Remove(sa!), sa => sa is not null);
            AddNewCommentCommand = new RelayCommand(AddNewComment);
            DeleteCommentCommand = new RelayCommand<CommentVM>(sc => CompaniesViewModel?.SelectedCompany?.Comments?.Remove(sc!), sc => sc is not null);
            ReturnCommand = new AsyncRelayCommand(Return);
            EditWebsiteCommand = new RelayCommand<string>(ChangeEditWebiste);
            AddNewCategoryCommand = new RelayCommand(AddNewCategory);
            EditCategoryCommand = new RelayCommand(EditCategory, CanEditCategory);
            SaveCategoryCommand = new AsyncRelayCommand(SaveCategory);
            DeleteCategoryCommand = new AsyncRelayCommand(DeleteCategory);
        }

        private bool CanEditCategory()
        {
            return SelectedCategory != null;
        }

        partial void OnSelectedCategoryChanged(ActivityCategoryVM? value)
        {
            if (CompaniesViewModel!.SelectedCompany!.SelectedActivity is not null && value is not null)
            {
                CompaniesViewModel.SelectedCompany.SelectedActivity.Category = value.Description;
            }
        }

        partial void OnIsEditingCategoryChanged(bool oldValue, bool newValue)
        {
            if (newValue is false)
            {
                return;
            }
            if (CompaniesViewModel?.SelectedCompany?.SelectedActivity is not null)
            {
                oldCategoryValue = CompaniesViewModel?.SelectedCompany?.SelectedActivity?.Category!;
            }
        }

        private async Task DeleteCategory()
        {
            if(SelectedCategory is not null)
            {
                IsEditingCategory = false;
                await categoryService.DeleteAsync(SelectedCategory);

                await LoadCategoriesAsync();
            }
        }

        private async Task SaveCategory()
        {
            if(SelectedCategory is null)
            {
                return;
            }

            IsEditingCategory = false;

            var index = Categories.IndexOf(SelectedCategory);

            await categoryService.UpdateAsync(SelectedCategory, oldCategoryValue);
                 
            await LoadCategoriesAsync();

            if(index > 0 && index < Categories.Count)
            {
                SelectedCategory = Categories[index];

            }

        }

        private void EditCategory()
        {

           IsEditingCategory = true;
       
        }

        private void AddNewCategory()
        {
            SelectedCategory = new ActivityCategoryVM();
            IsEditingCategory = true;
        }

        private void ChangeEditWebiste(string? command)
        {
            IsEditingWebsite = command == "True" ? true : false;
        }

        private async Task Return()
        {
            if(CompaniesViewModel.SelectedCompany is not null)
            {
                await companyService.UpdateAsync(CompaniesViewModel.SelectedCompany);
            }
            
            MainViewModel.SelectedViewModel = CompaniesViewModel;
            await MainViewModel.CompaniesViewModel.LoadAllCompaniesAsync();
        }

        private void AddNewComment()
        {
            CompaniesViewModel!.SelectedCompany!.SelectedComment = new CommentVM() { Label = "New comment", Date = DateOnly.FromDateTime(DateTime.Now) };
            CompaniesViewModel?.SelectedCompany?.Comments?.Add(CompaniesViewModel.SelectedCompany.SelectedComment);
        }

        private void AddNewActivity()
        {
            CompaniesViewModel!.SelectedCompany!.SelectedActivity = new ActivityVM() { Category =  "Application" , Date = DateOnly.FromDateTime(DateTime.Now) };
            CompaniesViewModel?.SelectedCompany?.Activities.Add(CompaniesViewModel.SelectedCompany.SelectedActivity);
        }

        private void AddNewContactPerson()
        {
            CompaniesViewModel!.SelectedCompany!.SelectedContactPerson = new ContactPersonVM() { Name = "New contact" };
            CompaniesViewModel.SelectedCompany!.ContactPeople.Add(CompaniesViewModel.SelectedCompany.SelectedContactPerson);
        }

        public async Task LoadCategoriesAsync()
        {
            Categories = await categoryService.GetAllAsync();

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
