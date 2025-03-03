using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MasterPaul.Models;

namespace MasterPaul.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Instance;
        public static MasterPaulContext Context = new MasterPaulContext();

        [ObservableProperty]
        private UserControl _currentPage;
        public MainWindowViewModel()
        {
            Instance = this;
            CurrentPage = new PartnersListView();
        }
        
    }
}
