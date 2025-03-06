using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterPaul.ViewModels;

namespace MasterPaul;

public partial class PartnerEditorView : UserControl
{
    public PartnerEditorView()
    {
        InitializeComponent();
        DataContext = new PartnerEditorVM();
    }

    public PartnerEditorView(int id)
    {
        InitializeComponent();
        DataContext = new PartnerEditorVM(id);
    }
}