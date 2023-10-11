namespace nh.qhatu.omnichannel.application.commands
{
    public class CreatePaymentCommand : PaymentCommand
    {
        public CreatePaymentCommand(string orderId, string customerId, decimal total) 
        {
            OrderId = orderId;
            CustomerId = customerId;
            Total = total;
        }
    }
}
