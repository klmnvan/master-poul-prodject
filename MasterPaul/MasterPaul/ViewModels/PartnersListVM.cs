using CommunityToolkit.Mvvm.ComponentModel;
using MasterPaul.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPaul.ViewModels
{
    public partial class PartnersListVM : ViewModelBase
    {
        [ObservableProperty]
        List<Partner> _partners = new List<Partner>();

        public PartnersListVM()
        {
            Partners = MainWindowViewModel.Context.Partners
                .Include(it => it.IdTypeCompanyNavigation)
                .ToList();
            var listProductPartners = MainWindowViewModel.Context.PartnerProducts.ToList();
            Partners.ForEach(it =>
            {
                it.QuantityProductsSold = (int)listProductPartners
                .Where(list => list.IdPartner == it.IdPartner)
                .Sum(list => list.CountProduct);
            });
        }
    }
}
