using CatalogManagement.Application.Product.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDTO?>
    {
        public int Id { get; set; }
    }
}
