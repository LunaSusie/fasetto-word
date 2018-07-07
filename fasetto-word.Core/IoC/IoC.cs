using System;
using System.Configuration;
using System.Runtime.InteropServices;
using fasetto_word.Core.ViewModel;
using Ninject;

namespace fasetto_word.Core.IoC
{
    /// <summary>
    /// IoC cantainer
    /// </summary>
    public static class IoC
    {
        public static IKernel Kernel { get; }=new StandardKernel();

        public static void Setup()
        {
            BindViewModels();
        }
        /// <summary>
        /// Binds all singletion view model.
        /// </summary>
        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
        /// <summary>
        /// Get a service form ioc container.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}