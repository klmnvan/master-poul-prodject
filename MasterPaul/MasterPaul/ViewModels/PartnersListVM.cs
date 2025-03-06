using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterPaul.Models;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;

namespace MasterPaul.ViewModels
{
    public partial class PartnersListVM : ViewModelBase
    {
        [ObservableProperty]
        List<Partner> _partners = new();

        public PartnersListVM()
        {
            Partners = MainWindowViewModel.Context.Partners
                .Include(it => it.IdTypeCompanyNavigation)
                .Include(it => it.PartnerProducts)
                .ToList();
        }

        [RelayCommand]
        public void CreatePartner()
        {
            MainWindowViewModel.Instance.CurrentPage = new PartnerEditorView();
        }

        [RelayCommand]
        public void EditPartner(Partner partner)
        {
            MainWindowViewModel.Instance.CurrentPage = new PartnerEditorView(partner.IdPartner);
        }

        [RelayCommand]
        public void OpenHistory(Partner partner)
        {
            MainWindowViewModel.Instance.CurrentPage = new HistoryPartnerView(partner.IdPartner);
        }

        [RelayCommand]
        public void OpenCalculation()
        {
            MainWindowViewModel.Instance.CurrentPage = new CalculationMaterialView();
        }

        [RelayCommand]
        public async void DeletePartner(Partner partner)
        {
            try
            {
                var answer = await MessageBoxManager.GetMessageBoxStandard("Предупреждение", $"Вы действительно хотите удалить партнёра '{partner.NameCompany}'?", MsBox.Avalonia.Enums.ButtonEnum.YesNo).ShowAsync();
                if(answer == MsBox.Avalonia.Enums.ButtonResult.Yes)
                {
                    MainWindowViewModel.Context.Partners.Remove(partner);
                    MainWindowViewModel.Context.SaveChanges();
                    MainWindowViewModel.Instance.CurrentPage = new PartnersListView();
                    await MessageBoxManager.GetMessageBoxStandard("Сообщение", $"Партнёр '{partner.NameCompany}' был успешно удалён", MsBox.Avalonia.Enums.ButtonEnum.Ok).ShowAsync();
                }
            } 
            catch (Exception ex)
            {
                await MessageBoxManager.GetMessageBoxStandard("Ошибка при удалении", $"{ex.Message}", MsBox.Avalonia.Enums.ButtonEnum.Ok).ShowAsync();
            }
        }
    }
}
