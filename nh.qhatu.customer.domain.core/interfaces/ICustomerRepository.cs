using nh.qhatu.customer.domain.core.entities;

namespace nh.qhatu.customer.domain.core.interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> GetAllCustomersWithAddressPaymentMethods();
    }
}
