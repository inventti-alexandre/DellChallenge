
using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace DellChallenge.Domain.EntitiesViewModel
{
    public class ClientFilterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? GenderId { get; set; }
        public int? ClassificationId { get; set; }
        public int? SellerId { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime? LastPurchase { get; set; }
        public DateTime? LastPurchaseUntil { get; set; }
        public List<ClientResultViewModel> Clients { get; set; }
        public int? RegionId { get; set; }
        public int RoleId { get; set; }

        public int? UserLoggedId { get; set; }

        public List<SelectListItem> Genders { get; set; }
        public List<SelectListItem> Classifications { get; set; }
        public List<SelectListItem> Regions { get; set; }
        public List<SelectListItem> Sellers { get; set; }

        public int? GetSellerId()
        {
            if (RoleId == (int)RoleEnum.Seller)
            {
                return UserLoggedId;
            }
            else
            {
                return SellerId;
            }
        }
    }
}
