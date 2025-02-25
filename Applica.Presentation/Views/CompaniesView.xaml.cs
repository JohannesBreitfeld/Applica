using Applica.Presentation.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(DataContext is CompaniesViewModel vm)
            {
                if(vm.SelectedCompany is not null)
                {
                     vm.OpenCommand.Execute(null);
                }
            }
        }
    }
}
