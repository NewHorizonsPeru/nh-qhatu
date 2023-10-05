using nh.qhatu.customer.domain.entities;

namespace nh.qhatu.customer.domain.interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> GetAllCustomersWithAddressPaymentMethods();
    }
}
