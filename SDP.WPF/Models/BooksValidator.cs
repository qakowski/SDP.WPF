using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.WPF.Models
{
    class BooksValidator : AbstractValidator<Book>
    {
        public BooksValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(b => b.InventoryNumber).NotEmpty().WithMessage("Nie moze byc puste").GreaterThan(9999).WithMessage("Musi miec 5 cyfr").LessThan(100000).WithMessage("Musi miec 5 cyfr");
            RuleFor(b => b.Author).NotEmpty().WithMessage("Autor nie moze byc pusty");
            RuleFor(b => b.Title).NotEmpty().WithMessage("Tytul nie moze byc pusty");
            RuleFor(b => b.Price).NotEmpty().WithMessage("Cena nie moze byc pusty").GreaterThan(0).WithMessage("Cena nie moze byc mniejsza od 0");
            RuleFor(b => b.YearPublisher).NotEmpty().WithMessage("Rok/Wydawca nie moze byc pusty");

        }
    }
}
