namespace ProgPoeFarmer31May.Models
{
    public class User
    {
        int FarmerID;
        string Username;
        string Password;
        bool Active;
        bool Admin;

        public User(int farmerID, string username, string password, bool active, bool admin)
        {
            FarmerID1 = farmerID;
            Username1 = username;
            Password1 = password;
            Active1 = active;
            Admin1 = admin;
        }

        public int FarmerID1 { get => FarmerID; set => FarmerID = value; }
        public string Username1 { get => Username; set => Username = value; }
        public string Password1 { get => Password; set => Password = value; }
        public bool Active1 { get => Active; set => Active = value; }
        public bool Admin1 { get => Admin; set => Admin = value; }
    }
}
