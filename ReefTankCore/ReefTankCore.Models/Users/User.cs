using Microsoft.AspNetCore.Identity;
using ReefTankCore.Core;

namespace ReefTankCore.Models.Users
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }

        public string Preposition { get; set; }

        public string Surname { get; set; }

        //public string Password { get; private set; }

        //public void SetPassword(string password)
        //{
        //    string passwordKey = EncryptionUtilities.GenerateKey(password, out var salt);

        //    Salt = salt;
        //    Password = passwordKey;
        //}

        //public string Salt { get; private set; }

        public bool IsActive { get; set; }

        public IdentityRole Role { get; set; }
    }
}