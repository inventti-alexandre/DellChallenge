namespace DellChallenge.Domain.EnititiesViewModel
{
    public class UserLoginViewModel
    {
        public UserLoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
