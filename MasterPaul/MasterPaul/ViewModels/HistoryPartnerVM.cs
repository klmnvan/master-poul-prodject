using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterPaul.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPaul.ViewModels
{
    internal partial class HistoryPartnerVM: ViewModelBase
    {
        public string NameScreen { get; set; } = "История";
        [ObservableProperty]
        private List<PartnerProduct> _listPartProds = new();

        public HistoryPartnerVM(int id)
        {
            ListPartProds = MainWindowViewModel.Context.PartnerProducts
                .Where(it => it.IdPartner == id)
                .Include(it => it.IdProductNavigation)
                .ToList();
            NameScreen = $"История реализации продукции партнёра \"{MainWindowViewModel.Context.Partners.FirstOrDefault(it => it.IdPartner == id).NameCompany}\"";
        }

        [RelayCommand]
        public void GoBack()
        {
            MainWindowViewModel.Instance.CurrentPage = new PartnersListView();
        }
    }
}
