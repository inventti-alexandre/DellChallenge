
using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DellChallenge.Domain.EntitiesViewModel
{
    public class ClientFilterViewModel
    {
        public ClientFilterViewModel()
        {
        }

        public ClientFilterViewModel(string name, string phone, int? genderId, int? classificationId, int? sellerId, string city, string region, int? regionId, int userLoggedId, int roleId, string lastPurchase, string lastPurchaseUntil)
        {
            Name = name;
            Phone = phone;
            GenderId = genderId;
            ClassificationId = classificationId;
            SellerId = sellerId;
            City = city;
            Region = region;
            RegionId = regionId;
            UserLoggedId = userLoggedId;
            RoleId = roleId;

            ValidateData(lastPurchase, lastPurchaseUntil);
        }

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

        public bool ValidateData(string lastPurchaseString, string lastPurchaseUntilString)
        {
            StringBuilder notifications = new StringBuilder();
            DateTime lastPurchConverted = new DateTime();
            DateTime lastPurchUntilConverted = new DateTime();

            if (!string.IsNullOrEmpty(lastPurchaseString))
            {
                if (!DateTime.TryParse(lastPurchaseString, out lastPurchConverted))
                {
                    notifications.AppendLine("Last purchcase is invalid.");
                }
                else
                {
                    LastPurchase = lastPurchConverted;
                }
            }

            if (!string.IsNullOrEmpty(lastPurchaseUntilString))
            {
                if (!DateTime.TryParse(lastPurchaseUntilString, out lastPurchUntilConverted))
                {
                    notifications.AppendLine("Last purchcase Until is invalid.");
                }
                else
                {
                    LastPurchaseUntil = lastPurchUntilConverted;
                }
            }


            if (notifications.Length > 0)
                throw new Exception(notifications.ToString());

            return true;
        }
    }
}
