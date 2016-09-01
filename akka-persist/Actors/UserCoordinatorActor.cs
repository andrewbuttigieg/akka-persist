using Akka.Actor;
using Akka_Persist.Messages;
using System;

namespace Akka_Persist.Actors
{
    public class UserCoordinatorActor: ReceiveActor
    {
        public UserCoordinatorActor()
        {
            ReceiveAsync<LoginMessage>(login =>
            {
                IActorRef identityActor = Context.ActorOf<IdentityActor>();
                var valid = await identityActor.Ask<bool>(login);

                if (valid)
                {
                    Console.WriteLine($"User \"{login.Username}\" is valid and logging in.");
                    Login(login);
                }
                else
                {
                    Console.WriteLine($"User \"{login.Username}\" is not valid.");
                }
            });
            
        }

        private void Login(LoginMessage login)
        {
            var child = Context.Child(login.Username);
            if (child.IsNobody())
            {
                Context.ActorOf<UserActor>(login.Username);
            }
        }
    }
}
