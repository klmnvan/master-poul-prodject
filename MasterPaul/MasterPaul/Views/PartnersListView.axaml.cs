using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterPaul.ViewModels;

namespace MasterPaul;

public partial class PartnersListView : UserControl
{
    public PartnersListView()
    {
        InitializeComponent();
        DataContext = new PartnersListVM();
    }
}