using nh.qhatu.customer.application.core.dto;

namespace nh.qhatu.customer.application.core.interfaces
{
    public interface ICustomerService
    {
        ICollection<CustomerDto> GetAllCustomers();
    }
}
