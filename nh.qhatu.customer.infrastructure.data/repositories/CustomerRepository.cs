using Microsoft.EntityFrameworkCore;
using nh.qhatu.customer.domain.core.entities;
using nh.qhatu.customer.domain.core.interfaces;
using nh.qhatu.customer.infrastructure.data.context;

namespace nh.qhatu.customer.infrastructure.data.repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(QhatuContext context) : base(context) { }

        public IEnumerable<Customer> GetAllCustomersWithAddressPaymentMethods()
        {
            return _context.Customers.Include(i => i.Addresses).Include(j => j.PaymentMethods);
        }
    }
}
