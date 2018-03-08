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
        private static List<City> _cities;

        public static List<Classification> DbClassification()
        {
            if (_classifications != null)
            {
                return _classifications;
            }

            _classifications = new List<Classification>()
            {
                new Classification(1, "VIP"),
                new Classification(2, "Regular"),
                new Classification(3, "Sporadic"),

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
                new Client(1, "Kelly", "55995599", genders[1], classifications[0], regions[0], DateTime.Now.AddDays(-2), users[1]),
                new Client(1, "Brian", "55886677", genders[0], classifications[1], regions[1], DateTime.Now.AddDays(-1), users[1]),
                new Client(1, "Brown", "44556677", genders[0], classifications[2], regions[1], DateTime.Now.AddDays(0), users[1]),
                new Client(1, "Katy", "88113344", genders[1], classifications[1], regions[2], DateTime.Now.AddDays(2), users[2]),
                new Client(1, "Kelly", "99557777", genders[1], classifications[0], regions[3], DateTime.Now.AddDays(3), users[2])

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

            var cities = DbCicty();

            _regions = new List<Region>()
            {
                new Region(1, "North", cities[0]),
                new Region(2, "South", cities[1]),
                new Region(3, "Weast", cities[2]),
                new Region(4, "East", cities[3]),
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

        public static List<City> DbCicty()
        {
            if (_cities != null)
            {
                return _cities;
            }

            _cities = new List<City>()
            {
                new City(1, "Natal"),
                new City(2, "Porto Alegre"),
                new City(3, "Sao Paulo"),
                new City(4, "Manaus"),
                new City(5, "Recife"),

            };

            return _cities;
        }
    }
}
