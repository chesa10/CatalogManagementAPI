using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Product.Commands.DeleteProductById
{
    public class DeleteProductByIdQuery : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
