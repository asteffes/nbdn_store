using System;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.web
{
    public interface FactoryRegistry
    {
        DependencyFactory return_requested_factory(Type type);
    }
}