namespace FluentValidation.Sample.Service
{
    public interface IValidatorService
    {
        void EnsureValid<T>(T model);
    }
}