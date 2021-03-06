﻿using Akka.Actor;
using CleanArchitecture.AkkaNET.Actors;
using CleanArchitecture.AkkaNET.Interfaces;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.AkkaNET.Providers
{
    public class CustomerActorProvider : ICustomerActorProvider
    {
        private IActorRef CustomersActor { get; set; }

        public CustomerActorProvider(IActorRefFactory actorSystem, ICustomerRepository repo)
        {
            CustomersActor = actorSystem.ActorOf(Props.Create<CustomersActor>(repo), "customers");
        }

        public IActorRef Get()
        {
            return CustomersActor;
        }
    }
}
