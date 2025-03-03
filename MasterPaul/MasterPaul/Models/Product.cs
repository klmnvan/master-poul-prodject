﻿using System;
using System.Collections.Generic;

namespace MasterPaul.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public int? IdProductType { get; set; }

    public string? ProductName { get; set; }

    public string? ArticleNumber { get; set; }

    public decimal? MinimumPrice { get; set; }

    public decimal? Length { get; set; }

    public decimal? Width { get; set; }

    public decimal? Height { get; set; }

    public decimal? WeightWithoutPack { get; set; }

    public decimal? WeightWithPack { get; set; }

    public virtual ProductType? IdProductTypeNavigation { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();
}
