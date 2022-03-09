using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.ApplicationCore.CustomEntities;
using Store.ApplicationCore.DTOs;
using Store.ApplicationCore.Interfaces;
using Store.WebApi.Responses;
using System.Net;

namespace Store.WebApi.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsServiceController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsServiceController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = nameof(GetProducts))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductResponse>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProducts([FromQuery]ProductSearch filter) 
        {
            var products = await _productService.GetProductsService(filter);

            var metadata = new Metadata
            {
                TotalCount = products.TotalCount,
                PageSize = products.PageSize,
                CurrentPage = products.CurrentPage,
                TotalPages = products.TotalPages,
                HasNextPage = products.HasNextPage,
                HasPreviousPage = products.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<ProductResponse>>(products)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
    }
}
