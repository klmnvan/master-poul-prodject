using MasterPaul.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using Calculation;
using Microsoft.EntityFrameworkCore;
using Avalonia.Input;
using Avalonia.Controls;

namespace MasterPaul.ViewModels
{
    internal partial class CalculationMaterialVM: ViewModelBase
    {
        [ObservableProperty]
        private int _quantityProduct = 0;
        [ObservableProperty]
        private List<MaterialType> _materialTypes = new();
        [ObservableProperty]
        private List<Product> _products = new();
        [ObservableProperty]
        private MaterialType _materialType = new();
        [ObservableProperty]
        private Product _product = new();
        [ObservableProperty]
        private int _result = 0;
        private CalculationClass _calculation = new();
        public CalculationMaterialVM()
        {
            MaterialTypes = MainWindowViewModel.Context.MaterialTypes.ToList();
            Products = MainWindowViewModel.Context.Products.Include(it => it.IdProductTypeNavigation).ToList();
            MaterialType = MaterialTypes.FirstOrDefault();
            Product = Products.FirstOrDefault();
        }

        [RelayCommand]
        public void GoBack()
        {
            MainWindowViewModel.Instance.CurrentPage = new PartnersListView();
        }

        [RelayCommand]
        public void Calculate()
        {
            Result = _calculation.GetQuantityForProduct((int)Product.IdProductType, MaterialType.IdType, QuantityProduct, (double)Product.Height, (double)Product.Width);
        }
    }
}
