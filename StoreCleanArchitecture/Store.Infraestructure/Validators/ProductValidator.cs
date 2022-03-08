using FluentValidation;
using Store.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("El nombre no puede ser nulo");

            RuleFor(x => x.Name)
                .Length(3, 30)
                .WithMessage("La longitud del la descripcion debe estar entre 10 y 500 caracteres");

            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula");

            RuleFor(x => x.Price)
               .ExclusiveBetween(0.01, 1000)
               .WithMessage("El valor debe estar entre 0.01 y 1,000");
        }
    }
}
