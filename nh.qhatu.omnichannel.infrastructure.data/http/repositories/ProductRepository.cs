using Microsoft.Extensions.Logging;
using nh.qhatu.omnichannel.domain.core.entities;
using nh.qhatu.omnichannel.domain.core.interfaces;
using System.Text.Json;

namespace nh.qhatu.omnichannel.infrastructure.data.http.repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(IHttpClientFactory httpClientFactory, ILogger<ProductRepository> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<Product> ValidateProductExistence(string productId)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("CommonService");
                var response = await httpClient.GetAsync($"api/common/validateProductExistence/{productId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var objectResult = JsonSerializer.Deserialize<Product>(content, options);

                    return objectResult;
                }

                return null;
            }catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
