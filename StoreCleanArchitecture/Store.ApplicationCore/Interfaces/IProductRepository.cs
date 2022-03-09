﻿using Store.ApplicationCore.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.ApplicationCore.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductResponse>> GetProducts();

        ProductResponse GetProductById(int productId);

        void DeleteProductById(int productId);

        ProductResponse CreateProduct(CreateProductRequest request);

        ProductResponse UpdateProduct(int productId, UpdateProductRequest request);

    }
}
