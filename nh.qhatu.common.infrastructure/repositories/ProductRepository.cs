﻿using Microsoft.EntityFrameworkCore;
using nh.qhatu.common.domain.entities;
using nh.qhatu.common.domain.interfaces;
using nh.qhatu.common.infrastructure.context;

namespace nh.qhatu.common.infrastructure.repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CommonContext context) : base(context) { }

        public IEnumerable<Product> ListProductsWithCategoryAndBrand() 
        {
            return _context.Products.Include(x => x.Brand).Include(y => y.Category);
        }
    }
}
