using Ninject;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// Inversion of Control container for the application.
    /// </summary>
    public static class IocContainer
    {
        /// <summary>
        /// IoC <see cref="StandardKernel"/> for the application.
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// Configures the IoC container by binding the required classes for the application.
        /// <para>Note: Must be called on application startup.</para>
        /// </summary>
        public static void Configure()
        {
            BindViewModels();
        }

        /// <summary>
        /// Get's a service from the IoC, of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to get.</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        /// <summary>
        /// Binds the view models to the IoC container kernal.
        /// </summary>
        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
    }
}
