using FluentValidation.Sample.Controllers;
using FluentValidation.Sample.Validators;

namespace FluentValidation.Sample.Service
{
    public class ValidatorService : IValidatorService
    {
        private readonly IDictionary<Type, Type> _validators;
        private readonly IServiceProvider _serviceProvider;


        public ValidatorService(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
            this._validators = new Dictionary<Type, Type>
            {
                { typeof(CreateOrderModel), typeof(CreateOrderValidator) },
                 { typeof(Product), typeof(ProductValidator) },
            };

        }



        private AbstractValidator<T> GetValidator<T>()
        {
            var modelType = typeof(T);
            var hasValidator = this._validators.ContainsKey(modelType);
            if (hasValidator == false)
            {
                throw new Exception("Missing validator");
            }

            var validatorType = this._validators[modelType];
            var validator = _serviceProvider.GetService(validatorType) as AbstractValidator<T>;
            return validator;
        }

        public void EnsureValid<T>(T model)
        {
            var validator = this.GetValidator<T>();
            var result = validator.Validate(model);
            if (result.IsValid == false)
            {
                throw new Exception(result.ToString());
            }
        }
    }
}
