﻿using Applica.Presentation.Resources;
using Applica.Presentation.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Windows.Input;

namespace Applica.Presentation.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly CompanyService companyService;
        private readonly MainViewModel mainViewModel;

        [ObservableProperty]
        private int _numberOfApplications = 0;
        
        [ObservableProperty]
        private int _numberOfOffers = 0;
        
        [ObservableProperty]
        private int _numberOfRejections = 0;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(NotificationButtonCommmand))]
        private int _numberOfNotifications = 0;

        [ObservableProperty]
        private bool _canLoadSampleData = false;

        public ICommand LoadSampleDataCommand { get; }
        public IRelayCommand NotificationButtonCommmand { get; }

        public HomeViewModel(MainViewModel mainViewModel, CompanyService companyService)
        {
            this.companyService = companyService;
            this.mainViewModel = mainViewModel;

            LoadSampleDataCommand = new AsyncRelayCommand(LoadSampleData);
            NotificationButtonCommmand = new AsyncRelayCommand(OpenNotification, CanExcecuteNotificationCommand);
        }

        private bool CanExcecuteNotificationCommand()
        {
            return NumberOfNotifications > 0;
        }

        private async Task OpenNotification()
        {
            mainViewModel.SelectedViewModel = mainViewModel.CompaniesViewModel;

            mainViewModel.CompaniesViewModel.Companies = await companyService
                .FindAsync(company => company.Activities!
                .Any(activity => activity.FollowUpDate <= DateOnly.FromDateTime(DateTime.Now) && activity.FollowUpDate != null));
        }

        private async Task LoadSampleData()
        {
            var sampleData = SampleDataGenerator.GenerateSampleData();

            await companyService.AddRangeAsync(sampleData);

            await LoadData();

            await mainViewModel.CompaniesViewModel.LoadAllCompaniesAsync();
        }

        public async Task LoadData()
        {
            var data = await companyService.GetAllAsync();

            mainViewModel.CompaniesViewModel.Companies = data;

            CanLoadSampleData = data.Count < 5 ? true : false;
        
            NumberOfApplications = data.Where(company => company.Activities
                        .Any(activity => activity.Category == "Application"))
                        .Count();

            NumberOfOffers = data.Where(company => company.Activities
                        .Any(activity => activity.Category == "Offer"))
                        .Count();

            NumberOfRejections = data.Where(company => company.Activities
                        .Any(activity => activity.Category == "Rejection"))
                        .Count();

            NumberOfNotifications = data.Where(company => company.HasNotification).Count();
        }

    }
}
