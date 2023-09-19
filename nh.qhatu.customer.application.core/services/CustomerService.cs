using AutoMapper;
using nh.qhatu.customer.application.core.dto;
using nh.qhatu.customer.application.core.interfaces;
using nh.qhatu.customer.domain.core.interfaces;

namespace nh.qhatu.customer.application.core.services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public ICollection<CustomerDto> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomersWithAddressPaymentMethods();
            var customersDto = _mapper.Map<ICollection<CustomerDto>>(customers);
            return customersDto;
        }
    }
}
