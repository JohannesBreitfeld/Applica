﻿using Applica.Presentation.ViewModels;
using Applica.Presentation.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Applica.Presentation.Views
{
    /// <summary>
    /// Interaction logic for CompaniesView.xaml
    /// </summary>
    public partial class CompaniesView : UserControl
    {
        public CompaniesView()
        {
            InitializeComponent();
          
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is CompaniesViewModel viewModel)
            {
                if (viewModel.Companies is null)
                {
                    await viewModel.LoadCompaniesAsync(); 
                }
            }
        }
    }
}
