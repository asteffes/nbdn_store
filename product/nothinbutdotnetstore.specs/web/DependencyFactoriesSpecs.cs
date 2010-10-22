using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers.basic;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class DependencyFactoriesSpecs
    {
        public abstract class concern : Observes<DependencyFactories>
        {
        }

        [Subject(typeof(DependencyFactories))]
        public class when_asked_to_get_a_factory_that_can_create_a_dependency_type: concern
        {
            Establish c = () =>
            {
                the_dependency_factory_i_need = an<DependencyFactory>();
                my_factory_registry = the_dependency<FactoryRegistry>();
                my_factory_registry.Stub(x => x.return_requested_factory(typeof (MyDependency))).Return(
                    the_dependency_factory_i_need);
            };

            Because b = () =>
                result = sut.get_factory_that_can_create(typeof(MyDependency));

            It should_return_a_dependency_factory_for_the_dependency_type = () =>
                result.ShouldEqual(the_dependency_factory_i_need);

            static DependencyFactory result;
            private static DependencyFactory the_dependency_factory_i_need;
            private static FactoryRegistry my_factory_registry;
        }

    }

    internal class MyDependency
    {
    }
}