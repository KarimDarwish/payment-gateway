﻿using PaymentGateway.MockBank.Exceptions;
using PaymentGateway.MockBank.Model;
using PaymentGateway.MockBank.Services.RandomNumber;

namespace PaymentGateway.MockBank.Services;

public class PaymentService : IPaymentService
{
    private readonly IRandomNumberGenerator _randomNumberGenerator;

    public PaymentService(IRandomNumberGenerator randomNumberGenerator)
    {
        _randomNumberGenerator = randomNumberGenerator;
    }

    public BankPaymentResponse ProcessPayment(BankPaymentRequest bankPaymentRequest)
    {
        //Assumption: Our Bank rate limits us sometimes and our payment gateway needs to handle that
        if (_randomNumberGenerator.GenerateRandomNumber(0, 2) == 1) throw new BankRateLimitException();

        //Assumption: Our Bank declines payments if made by an American Express Card (4 digit CVV)
        if (IsAmericanExpress(bankPaymentRequest.BankCreditCard)) return new BankPaymentResponse(false);
        
        return new BankPaymentResponse(true);
    }

    private bool IsAmericanExpress(BankCreditCard bankCreditCard)
    {
        return bankCreditCard.Cvv.ToString().Length == 4;
    }
}