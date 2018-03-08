using DellChallenge.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DellChallenge.Repository.Context
{
    public static class FakeContextSingleton
    {
        private static List<Classification> _classifications;
        private static List<User> _users;
        private static List<Gender> _genders;
        private static List<Region> _regions;
        private static List<Role> _roles;
        private static List<Client> _clients;

        public static List<Classification> DbClassification()
        {
            if (_classifications != null)
            {
                return _classifications;
            }

            _classifications = new List<Classification>()
            {
                new Classification(1, "Gold"),
                new Classification(2, "Silver"),
                new Classification(3, "Bronze"),

            };

            return _classifications;
        }

        public static List<Client> DbClient()
        {
            if (_clients != null)
                return _clients;

            var users = DbUser();
            var genders = DbGender();
            var classifications = DbClassification();
            var regions = DbRegion();

            _clients = new List<Client>()
            {
                new Client(1, "Kelly", "55995599", genders[1], classifications[0], "NY", regions[0], DateTime.Now.AddDays(-2), users[1]),
                new Client(1, "Brian", "55886677", genders[0], classifications[1], "NY", regions[1], DateTime.Now.AddDays(-1), users[1]),
                new Client(1, "Brown", "44556677", genders[0], classifications[2], "NY", regions[1], DateTime.Now.AddDays(0), users[1]),
                new Client(1, "Katy", "88113344", genders[1], classifications[1], "NY", regions[2], DateTime.Now.AddDays(2), users[2]),
                new Client(1, "Kelly", "99557777", genders[1], classifications[0], "NY", regions[3], DateTime.Now.AddDays(3), users[2])

            };

            return _clients;
        }

        public static List<User> DbUser()
        {
            if (_users != null)
                return _users;

            var roles = DbRole();

            _users = new List<User>()
            {
                new User(1, "admin@sellseverything.com", roles[0], "admin123"),
                new User(2, "seller1@sellseverything.com", roles[1], "seller1123"),
                new User(3, "seller2@sellseverything.com", roles[1], "seller2123"),
            };

            return _users;
        }

        public static List<Role> DbRole()
        {
            if (_roles != null)
                return _roles;

            _roles = new List<Role>()
            {
                new Role(1, "Administrator"),
                new Role(2, "Seller"),
                new Role(2, "Seller")
            };

            return _roles;
        }

        public static List<Region> DbRegion()
        {
            if (_regions != null)
                return _regions;

            _regions = new List<Region>()
            {
                new Region(1, "North"),
                new Region(2, "South"),
                new Region(3, "Weast"),
                new Region(4, "East"),
            };

            return _regions;
        }

        public static List<Gender> DbGender()
        {
            _genders = new List<Gender>()
            {
                new Gender(1, "Male"),
                new Gender(2, "Female"),

            };

            return _genders;
        }
    }
}
