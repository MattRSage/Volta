﻿using Volta.BuildingBlocks.Domain;
using Volta.Customers.Domain.CustomerRegistrations;
using Volta.Customers.Domain.Customers.Events;

namespace Volta.Customers.Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        public CustomerId Id { get; private set; }

        private string _email;

        private string _password;

        private bool _isActive;

        private string _firstName;

        private string _lastName;

        private Customer()
        {
        }

        private Customer(CustomerRegistrationId customerRegistrationId, string email, string password, string firstName, string lastName)
        {
            this.Id = new CustomerId(customerRegistrationId.Value);
            _email = email;
            _password = password;
            _firstName = firstName;
            _lastName = lastName;

            _isActive = true;

            AddDomainEvent(new CustomerCreatedDomainEvent(this.Id));
        }

        internal static Customer CreateFromCustomerRegistration(
            CustomerRegistrationId customerRegistrationId,
            string email,
            string password,
            string firstName,
            string lastName)
        {
            return new Customer(customerRegistrationId, email, password, firstName, lastName);
        }
    }
}