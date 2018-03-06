using DellChallenge.Domain2.Enitities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DellChallenge.Domain.Enitities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public IEnumerable<Client> Clients { get; set; }

        public User(string email, string password)
        {
            Email = email;
            //Password = EncryptPassword(password);
            Password = password;
        }

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return string.Empty;
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
