namespace Akka_NChild_Pattern.Messages
{
    public class LoginMessage
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public LoginMessage(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
