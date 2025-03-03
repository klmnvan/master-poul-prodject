using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPaul.Models
{
    public partial class Partner
    {
        //Общее количество реализованной партнером продукции
        int quantityProductsSold = 0;

        //Скидка
        public int Sale 
        {
            get
            {
                if (quantityProductsSold < 10000 && quantityProductsSold > 0) return 0;
                if (quantityProductsSold >= 10000 && quantityProductsSold < 50000) return 5;
                if (quantityProductsSold >= 50000 && quantityProductsSold < 300000) return 10;
                if (quantityProductsSold >= 300000) return 15;
                return 0;
            }
        }

        [NotMapped]
        public int QuantityProductsSold { get => quantityProductsSold; set => quantityProductsSold = value; }
    }
}
