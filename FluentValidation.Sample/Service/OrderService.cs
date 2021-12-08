using FluentValidation.Sample.Controllers;

namespace FluentValidation.Sample.Service
{
    public class OrderService : IOrderService
    {
        private readonly IValidatorService _validatorService;
        public OrderService(IValidatorService validatorService)
        {
            _validatorService = validatorService;
        }

        public async Task<bool> CreateOrderAsync(CreateOrderModel model)
        {
            try
            {
                _validatorService.EnsureValid(model);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
