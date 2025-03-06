using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MasterPaul.ViewModels;

namespace MasterPaul;

public partial class CalculationMaterialView : UserControl
{
    public CalculationMaterialView()
    {
        DataContext = new CalculationMaterialVM();
        InitializeComponent();
    }

    private async void CopyButton_OnClick(object? sender, RoutedEventArgs args)
    {
        var clipboard = TopLevel.GetTopLevel(this)?.Clipboard;
        var dataObject = new DataObject();
        dataObject.Set(DataFormats.Text, "Hello World");
        await clipboard.SetDataObjectAsync(dataObject);
    }
}