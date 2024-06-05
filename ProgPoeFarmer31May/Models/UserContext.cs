namespace ProgPoeFarmer31May.Models
{
    public class UserContext
    {
        public static List<User> users = new List<User>();

        public UserContext() 
        {
            if (users.Count == 0)
            {
                users.Add(new User("CP", "Kruger", "Y"));
                users.Add(new User("Birdfeeder29", "TweetTw1t55", "N"));
                users.Add(new User("Peace4Reece", "T@styCh1ckenBurger27", "Y"));
                users.Add(new User("StephanDaCleana", "1MrCle@n1", "N"));
            }
        }
    }
}
