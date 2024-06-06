using Microsoft.Extensions.DependencyInjection;

namespace LucasHelper.Framework
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;

    }
}
