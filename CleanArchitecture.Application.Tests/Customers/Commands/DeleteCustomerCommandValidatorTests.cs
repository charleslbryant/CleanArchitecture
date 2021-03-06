﻿using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Entities;
using Moq;
using Xunit;
using Shouldly;
using CleanArchitecture.Application.Customers.Commands.DeleteCustomer;

namespace CleanArchitecture.Application.Tests.Customers.Commands
{
    public class DeleteCustomerCommandValidatorTests
    {
        [Fact]
        public void ItShouldDeleteIfExistingCustomer()
        {
            var customer = new Customer { CustomerId = 1 };
            var readStore = new Mock<ICustomerRepository>();
            readStore.Setup(_ => _.GetCustomerById(It.IsAny<int>())).ReturnsAsync(customer);

            var sut = new DeleteCustomerCommandValidator(readStore.Object);
            var result = sut.Validate(new DeleteCustomerCommand { Id = 1 });

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void ItShouldFailIfCustomerDoesNotExist()
        {
            Customer customer = null;
            var readStore = new Mock<ICustomerRepository>();
            readStore.Setup(_ => _.GetCustomerById(It.IsAny<int>())).ReturnsAsync(customer);

            var sut = new DeleteCustomerCommandValidator(readStore.Object);
            var result = sut.Validate(new DeleteCustomerCommand { Id = 1 });

            result.IsValid.ShouldBe(false);
            result.Errors[0].ErrorMessage.ShouldBe("Customer must exist to delete");
        }
    }
}
