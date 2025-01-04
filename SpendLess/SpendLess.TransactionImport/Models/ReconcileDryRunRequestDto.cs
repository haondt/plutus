﻿using Microsoft.AspNetCore.Mvc;
using SpendLess.Web.Core.ModelBinders;

namespace SpendLess.TransactionImport.Models
{
    public class ReconcileDryRunRequestDto
    {
        [BindProperty(Name = "filters")]
        public List<string> Filters { get; set; } = [];

        [BindProperty(Name = "transactions")]
        public string Transactions { get; set; } = "";

        [BindProperty(Name = "pair-match-description"), ModelBinder(typeof(CheckboxModelBinder))]
        public required bool PairingMatchDescription { get; set; }

        [BindProperty(Name = "pair-match-date"), ModelBinder(typeof(CheckboxModelBinder))]
        public required bool PairingMatchDate { get; set; }

        [BindProperty(Name = "pair-date-tol")]
        public required int PairingDateToleranceInDays { get; set; }

        [BindProperty(Name = "join-description")]
        public required DescriptionJoiningStrategy JoinDescriptionStrategy { get; set; }

        [BindProperty(Name = "join-date")]
        public required DateJoiningStrategy JoinDateStrategy { get; set; }

        [BindProperty(Name = "join-category")]
        public required CategoryJoiningStrategy JoinCategoryStrategy { get; set; }
    }
}
