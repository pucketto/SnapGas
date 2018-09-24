using Xamarin.Forms;

namespace SnapGas.Services
{
    public class DependencyServiceWrapper : IDependencyService
    {
        public void Register<T>(object impl) where T : class
        {
            DependencyService.Register<T>();
        }

        public T Get<T>() where T : class
        {
            return DependencyService.Get<T>();
        }
    }
}
