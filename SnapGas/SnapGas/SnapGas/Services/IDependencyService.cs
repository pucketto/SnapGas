namespace SnapGas.Services
{
    public interface IDependencyService
    {
        void Register<T>(object impl) where T : class;

        T Get<T>() where T : class;
    }
}
