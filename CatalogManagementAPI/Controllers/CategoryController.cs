using CatalogManagement.Application.Category.Commands.AddCategory;
using CatalogManagement.Application.Category.Queries.GetAllCategories;
using CatalogManagement.Application.Category.Queries.GetAllCategoriesTree;
using CatalogManagement.Application.Product.Queries.GetAllProducts;
using CatalogManagement.Domain.Entities;
using CatalogManagement.Domain.Repositories;
using CatalogManagement.Infrastructure.Repositories;
using CatalogManagementAPI.Extension;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CatalogManagementAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("tree")]
        public async Task<IActionResult> GetAllCategoriesTree()
        {
            var categories = await mediator.Send(new GetAllCategoriesTreeQuery());

            //Manual Serialization
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(categories, options);
            return Content(jsonString, "application/json"); ;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryQuery query)
        {
            var category = await mediator.Send(query);
            return Ok(category);
        }
    }
}
