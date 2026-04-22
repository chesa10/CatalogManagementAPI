using CatalogManagement.Application.Product.Commands.AddProduct;
using CatalogManagement.Application.Product.Commands.DeleteProductById;
using CatalogManagement.Application.Product.Commands.PutProduct;
using CatalogManagement.Application.Product.DTOs;
using CatalogManagement.Application.Product.Queries.GetAllProducts;
using CatalogManagement.Application.Product.Queries.GetProductById;
using CatalogManagementAPI.Extension;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogManagementAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]GetAllProductsQuery query)
        {
            var products = await mediator.Send(query);
            Response.AddPaginationHeader(products);

            var ps =new List<AllProductDTO>();
            //manual mapping
            foreach (var item in products)
            {
                ps.Add(new AllProductDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    SKU = item.SKU,
                });
            }

            return Ok(ps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllById([FromRoute] int id)
        {
            var query = new GetProductByIdQuery() { Id = id };
            var products = await mediator.Send(query);
            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var query = new DeleteProductByIdQuery() { Id = id };
            var delete = await mediator.Send(query);
            if (delete)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] PutProductQuery query)
        {
            if (id != query.Id)
                return BadRequest("Product Id mismatch");

            var put = await mediator.Send(query);
            if (put)
            {
                return Ok(true);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductQuery([FromBody] AddProductQuery query)
        {
            if (query == null)
                return BadRequest("Product can't be null");

            var added = await mediator.Send(query);
            if (added)
            {
                return Ok(true);
            }
            return BadRequest("Something went wrong");
        }

    }
}
