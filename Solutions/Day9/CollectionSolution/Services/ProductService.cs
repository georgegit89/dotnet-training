﻿
namespace Services
{
    using Entities;
    using Repositories;

    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {

            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product AddProduct(Product product)
        {
            // you can add business validations here
            if (string.IsNullOrWhiteSpace(product.Title))
                throw new ArgumentException("Product titl is required");

            if (product.Price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            return _productRepository.AddProduct(product);
        }

        public bool UpdateProduct(int id, Product updatedProduct)
        {
            return _productRepository.UpdateProduct(id, updatedProduct);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
    }
}