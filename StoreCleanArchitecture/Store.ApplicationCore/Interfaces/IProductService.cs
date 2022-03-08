using Store.ApplicationCore.CustomEntities;
using Store.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.ApplicationCore.Interfaces
{
    public interface IProductService
    {
        PagedList<ProductResponse> GetProductsService(ProductSearch filters);

        ProductResponse GetProductByIdService(int productId);

        void DeleteProductByIdService(int productId);

        ProductResponse CreateProductService(CreateProductRequest request);

        ProductResponse UpdateProductService(int productId, UpdateProductRequest request);

    }
}
