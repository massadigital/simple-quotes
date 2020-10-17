using SimpleQuotes.Data.Contract.Repository;
using SimpleQuotes.Domain.Contract.Service;
using SimpleQuotes.Domain.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleQuotes.Domain.Service
{
    public class ProductService : BaseService<Product, long>, IProductService
    {
        protected IProductRepository ProductRepository { get; }

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            ProductRepository = productRepository;
        }

        protected override async Task Trim(Product model)
        {
            await Task.Yield();

            model.ProductName ??= string.Empty;
        }

        protected override async Task Merge(Product to, Product from)
        {
            await Task.Yield();

            to.ProductName = from.ProductName;
        }

        protected override async Task<IEnumerable<ApplicationException>> Validate(Product model)
        {
            await Task.Yield();

            var result = new List<ApplicationException>();

            if (model.ProductName.Length > 256)
            {
                result.Add(new ApplicationException("Nome deve ser menor que 256 caracteres"));
            }

            if (model.ProductName.Length < 2)
            {
                result.Add(new ApplicationException("Nome deve ser maior que 2 caracteres"));
            }

            return result;
        }

    }
}
