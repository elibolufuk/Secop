using Secop.Core.Application.Constants;

namespace Secop.Core.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ServiceHandlerAttribute : Attribute
    {
        public ServiceHandlerType ServiceType { get; }

        public ServiceHandlerAttribute(ServiceHandlerType serviceType)
        {
            ServiceType = serviceType;
        }
    }
}