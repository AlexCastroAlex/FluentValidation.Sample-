using FluentValidation.Sample.Controllers;

namespace FluentValidation.Sample.Validators
{

        public class CreateOrderValidator : AbstractValidator<CreateOrderModel>
        {
            public CreateOrderValidator()
            {
                RuleFor(r => r.OrderId).GreaterThan(0);
                RuleFor(r => r.Products.Count).GreaterThan(0);
                RuleForEach(r => r.Products).SetValidator(new ProductValidator());
            }
        }

        public class ProductValidator : AbstractValidator<Product>
        {
            public ProductValidator()
            {
                RuleFor(r => r.ProductId).GreaterThan(0);
                RuleFor(r => r.ProductPrice).GreaterThan(0);
                RuleFor(r => r.ProductLabel).NotNull();
                RuleFor(r => r.ProductLabel).NotEmpty();
                RuleFor(r => r.ProductLabel).Length(2,30);

            }
        }

}
