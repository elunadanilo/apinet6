using Microsoft.Extensions.Options;
using Store.ApplicationCore.CustomEntities;
using Store.ApplicationCore.DTOs;
using Store.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly PaginationOptions _paginationOptions;

        public ProductService(IProductRepository productRepository, IOptions<PaginationOptions> options) 
        {
            this.productRepository = productRepository;
            _paginationOptions = options.Value;
        }
        public ProductResponse CreateProductService(CreateProductRequest request)
        {
            return this.productRepository.CreateProduct(request);
        }

        public void DeleteProductByIdService(int productId)
        {
            this.productRepository.DeleteProductById(productId);
        }

        public ProductResponse GetProductByIdService(int productId)
        {
            return this.productRepository.GetProductById(productId);
        }

        public PagedList<ProductResponse> GetProductsService(ProductSearch filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var product =  this.productRepository.GetProducts();

            var pagedProduct = PagedList<ProductResponse>.Create(product,filters.PageNumber, filters.PageSize);

            return pagedProduct;
        }

        public ProductResponse UpdateProductService(int productId, UpdateProductRequest request)
        {
            return this.productRepository.UpdateProduct(productId,request);
        }
    }
}
