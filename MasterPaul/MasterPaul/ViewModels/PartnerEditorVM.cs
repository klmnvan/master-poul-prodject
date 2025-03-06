using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterPaul.Models;
using MsBox.Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPaul.ViewModels
{
    internal partial class PartnerEditorVM : ViewModelBase
    {
        public string NameScreen { get; set; } = "Добавление партнёра";
        public string NameButton { get; set; } = "Добавить";
        [ObservableProperty]
        private Partner _partner = new Partner();
        [ObservableProperty]
        private List<PartnerType> _partnerTypes = new();
        [ObservableProperty]
        private PartnerType _selPartnerType = new();

        public PartnerEditorVM()
        {
            InitData();
            SelPartnerType = PartnerTypes.FirstOrDefault();
        }

        public PartnerEditorVM(int idPartner)
        {
            NameScreen = "Редактирование партнёра";
            NameButton = "Редактировать";
            InitData();
            Partner = MainWindowViewModel.Context.Partners.First(it => it.IdPartner == idPartner);
            SelPartnerType = Partner.IdTypeCompanyNavigation;
        }

        private void InitData()
        {
            PartnerTypes = MainWindowViewModel.Context.PartnerTypes.ToList();
        }

        [RelayCommand]
        public async void Save()
        {
            try
            {
                Partner.IdTypeCompanyNavigation = SelPartnerType;
                if (Partner.IdPartner == 0)
                {
                    MainWindowViewModel.Context.Partners.Add(Partner);
                    MainWindowViewModel.Context.SaveChanges();
                    MainWindowViewModel.Instance.CurrentPage = new PartnersListView();
                    await MessageBoxManager.GetMessageBoxStandard("Сообщение", $"Партнёр '{Partner.NameCompany}' был успешно добавлен", MsBox.Avalonia.Enums.ButtonEnum.Ok).ShowAsync();
                }
                else
                {
                    MainWindowViewModel.Context.SaveChanges();
                    MainWindowViewModel.Instance.CurrentPage = new PartnersListView();
                    await MessageBoxManager.GetMessageBoxStandard("Сообщение", $"Партнёр '{Partner.NameCompany}' был изменён", MsBox.Avalonia.Enums.ButtonEnum.Ok).ShowAsync();
                }
            }
            catch (Exception ex)
            {
                await MessageBoxManager.GetMessageBoxStandard("Ошибка", $"{ex.Message}", MsBox.Avalonia.Enums.ButtonEnum.Ok).ShowAsync();
            }
        }

        [RelayCommand]
        public void GoBack()
        {
            MainWindowViewModel.Instance.CurrentPage = new PartnersListView();
        }
    }
}
