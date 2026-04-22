using CatalogManagement.Application.Product.Commands.AddProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Product.Validators
{
    public class AddProductQueryValidator : AbstractValidator<AddProductQuery>
    {
        public AddProductQueryValidator()
        {
            RuleFor(dto => dto.Name)
                .Length(3, 100);

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Please add description");

            RuleFor(dto => dto.CategoryId)
                .NotEmpty().WithMessage("Please add category");

            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(1);
            RuleFor(r => r.CategoryId)
                .GreaterThanOrEqualTo(0);
            RuleFor(r => r.Quantity)
                .GreaterThanOrEqualTo(0);
        }
    }
}
