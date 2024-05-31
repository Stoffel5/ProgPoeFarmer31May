namespace ProgPoeFarmer31May.Models
{
    public class User
    {
        public static List<User> users = new List<User>();

        string Username;
        string Password;
        string Admin;

        public User() { }
        public User(string username, string password, string admin)
        {

            Username1 = username;
            Password1 = password;
            Admin1 = admin;
        }

        public string Username1 { get => Username; set => Username = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string Admin1 { get => Admin; set => Admin = value; }
    }
}
