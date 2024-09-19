using Secop.Core.Application.Constants;

namespace Secop.Core.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ServiceHandlerAttribute(ServiceHandlerType serviceType) : Attribute
    {
        public ServiceHandlerType ServiceType { get; } = serviceType;
    }
}