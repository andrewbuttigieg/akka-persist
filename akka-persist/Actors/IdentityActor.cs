using Akka.Actor;
using Akka_NChild_Pattern.Messages;

namespace Akka_NChild_Pattern.Actors
{
    public class IdentityActor: ReceiveActor
    {
        public IdentityActor()
        {
            Receive<LoginMessage>(login =>
            {
                if (login.Username == "andrew" && login.Password == "password")
                    Sender.Tell(true, Self);
                else
                    Sender.Tell(false, Self);
            });
        }
    }
}
