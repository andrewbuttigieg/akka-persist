using Akka.Actor;
using Akka_NChild_Pattern.Actors;
using Akka_NChild_Pattern.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka_NChild_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("PubSubActorSystem");
            Console.WriteLine("Created System.");

            IActorRef identityActor = system.ActorOf(Props.Create(typeof(IdentityActor)), "IdentityActor");
            IActorRef userCoordinatorActor = system.ActorOf(Props.Create(typeof(UserCoordinatorActor)), "UserCoordinatorActor");

            userCoordinatorActor.Tell(new LoginMessage("andrew", "password"));
            userCoordinatorActor.Tell(new LoginMessage("leet user", "bad password"));

            Console.ReadLine();
            system.Terminate();
        }
    }
}
