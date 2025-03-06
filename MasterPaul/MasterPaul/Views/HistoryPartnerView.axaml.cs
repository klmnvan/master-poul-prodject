using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterPaul.ViewModels;

namespace MasterPaul;

public partial class HistoryPartnerView : UserControl
{
    public HistoryPartnerView(int id)
    {
        DataContext = new HistoryPartnerVM(id);
        InitializeComponent();
    }
}