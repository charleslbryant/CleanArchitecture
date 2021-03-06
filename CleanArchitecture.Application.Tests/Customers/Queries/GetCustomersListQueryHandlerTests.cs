﻿using CleanArchitecture.Application.Customers.Queries.GetCustomersList;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.Tests.Customers.Queries
{
    public class GetCustomersListQueryHandlerTests
    {
        [Fact]
        public async Task ItShouldGetCustomerList()
        {
            var customers = new List<Customer> {
                new Customer { CustomerId = 1, CustomerName = "first last" },
                new Customer { CustomerId = 2, CustomerName = "test test" },
            };

            var context = new Mock<ICustomerRepository>();
            context.Setup(_ => _.GetCustomers()).ReturnsAsync(customers);

            var sut = new GetCustomersListQueryHandler(context.Object);
            var result = await sut.Handle(new GetCustomersListQuery(), CancellationToken.None);

            result.ShouldBeOfType<GetCustomersListQueryViewModel>();
            result.Customers.ShouldBe(customers);
        }
    }
}
