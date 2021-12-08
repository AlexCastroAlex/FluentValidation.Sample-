using FluentValidation.Sample.Controllers;

namespace FluentValidation.Sample.Service
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(CreateOrderModel model);
    }
}