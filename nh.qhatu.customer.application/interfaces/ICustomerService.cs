using nh.qhatu.customer.application.dto;

namespace nh.qhatu.customer.application.interfaces
{
    public interface ICustomerService
    {
        ICollection<CustomerDto> GetAllCustomers();
    }
}
