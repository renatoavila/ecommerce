using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Domain.Enum;
using Ecommerce.Integration.Inferface;
using Ecommerce.Integration.Model;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Ecommerce.Service
{
    public class PaymentService : IPaymentServices
    {
        private readonly IPaymentBusiness _paymentBusiness;
        private readonly IOrdersBusiness _ordersBusiness;
        private readonly IShopCartBusiness _shopCartBusiness;
        private readonly IBilletIntegration _billetIntegration;
        private readonly ICredCardIntegration _credCardIntegration;

        public PaymentService(IPaymentBusiness paymentBusiness,
                                IOrdersBusiness ordersBusiness,
                                IShopCartBusiness shopCartBusiness,
                                IBilletIntegration billetIntegration,
                                ICredCardIntegration credCardIntegration)
        {
            _paymentBusiness = paymentBusiness;
            _ordersBusiness = ordersBusiness;
            _shopCartBusiness = shopCartBusiness;
            _billetIntegration = billetIntegration;
            _credCardIntegration = credCardIntegration;
        }

        public Payment Execute(Payment payment)
        {
            payment.Order = _ordersBusiness.Get(payment.Order.Key);
            payment.OrderId = payment.Order.Id;
            long idPayment = _paymentBusiness.Insert((Payment)payment);
            if (payment.Valid)
            {
                if (payment is Billet)
                {
                    ResponsePaymentSlipTransation response =
                        _billetIntegration.Execute(
                            new RequestPaymentSlipTransaction()
                                {

                                }
                            );
                    payment.State = "ok";
                    payment.PaymentType = PaymentType.Billet;
                    //todo: (Billet)payment.code = response.paymentSlipTransaction.paymentSlip.barCode;
                }
                else if (payment is CredCard)
                {
                    ResponseCreditCardTransaction response =
                       _credCardIntegration.Execute(
                           new RequestCreditCardTransation()
                           {

                           }
                           );
                    payment.State = "ok";  
                    payment.PaymentType = PaymentType.CredCard;
                    // response.creditCardTransaction.affiliationKey;
                    //insert CredCard
                }
                payment.Id = idPayment;
                _paymentBusiness.Update((Payment)payment);
            }
            return payment;
        }
    }
}
