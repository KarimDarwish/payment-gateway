using System;
using FluentAssertions;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Exceptions;
using PaymentGateway.Domain.Repositories;
using PaymentGateway.Domain.ValueObjects;
using PaymentGateway.Infrastructure.Repositories;
using Xunit;

namespace Infrastructure.UnitTests.Repositories;

public class PaymentRepositoryTests
{
    private readonly IPaymentRepository _repository;

    public PaymentRepositoryTests()
    {
        _repository = new PaymentRepository();
    }

    [Fact]
    public void InsertPayment_ifValid_persistsPayment()
    {
        //Arrange
        var creditCard = new CreditCard("2222420000001113", new CardExpiry(12, 25), new CardVerificationValue(123));
        var amount = new PaymentAmount(9.99m, Currencies.Euro);
        var payment = new Payment(creditCard, amount);

        //Act
        _repository.Insert(payment);

        //Assert
        var persistedPayment = _repository.Get(payment.Id);
        persistedPayment.Should().BeEquivalentTo(payment);
    }

    [Fact]
    public void InsertPayment_ifAlreadyExists_throws()
    {
        //Arrange
        var creditCard = new CreditCard("2222420000001113", new CardExpiry(12, 25), new CardVerificationValue(123));
        var amount = new PaymentAmount(9.99m, Currencies.Euro);
        var payment = new Payment(creditCard, amount);

        _repository.Insert(payment);

        //Act
        var action = () => _repository.Insert(payment);

        //Assert
        action.Should().Throw<PaymentAlreadyExistsException>();
    }

    [Fact]
    public void GetPayment_ifItDoesNotExist_returnsNull()
    {
        //Act
        var payment = _repository.Get(Guid.NewGuid());

        //Assert
        payment.Should().BeNull();
    }
}