using Microsoft.EntityFrameworkCore;
using nh.qhatu.customer.domain.entities;
using nh.qhatu.customer.domain.interfaces;
using nh.qhatu.customer.infrastructure.context;

namespace nh.qhatu.customer.infrastructure.repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext context) : base(context) { }

        public IEnumerable<Customer> GetAllCustomersWithAddressPaymentMethods()
        {
            return _context.Customers.Include(i => i.Addresses).Include(j => j.PaymentMethods);
        }
    }
}
