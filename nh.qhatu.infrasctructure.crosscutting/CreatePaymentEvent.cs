namespace nh.qhatu.infrasctructure.crosscutting;

public record CreatePaymentEvent(string OrderId, string CustomerId, decimal Total);