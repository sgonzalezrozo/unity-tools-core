using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ToolsCore.VContainerAdapter
{
    /// <summary>
    /// Connects VContainer to the packages that use Tools Core. In your root LifetimeScope:
    /// <code>
    /// protected override void Configure(IContainerBuilder builder)
    /// {
    ///     builder.UseToolsCore();
    /// }
    /// </code>
    /// Use the project-wide scope: a scope that's destroyed takes its resolver with it.
    /// </summary>
    public static class VContainerToolsCore
    {
        /// <summary>Registers VContainer with Tools Core once the container is built.</summary>
        public static void UseToolsCore(this IContainerBuilder builder)
            => builder.RegisterBuildCallback(Use);

        /// <summary>Makes <paramref name="resolver"/> the injector and instantiator for Tools Core.</summary>
        public static void Use(IObjectResolver resolver)
        {
            ToolInjectionServices.MonoBehaviourInjector = new VContainerMonoBehaviourInjector(resolver);
            ToolInjectionServices.PrefabInstantiator = new VContainerPrefabInstantiator(resolver);
        }
    }

    /// <summary>Injects a component with a VContainer resolver.</summary>
    public sealed class VContainerMonoBehaviourInjector : IMonoBehaviourInjector
    {
        private readonly IObjectResolver resolver;

        public VContainerMonoBehaviourInjector(IObjectResolver resolver)
            => this.resolver = resolver;

        public void InjectIfNeeded(MonoBehaviour component)
        {
            if (component != null)
                resolver.Inject(component);
        }
    }

    /// <summary>Instantiates with VContainer, which injects the copy, so tools don't inject it again.</summary>
    public sealed class VContainerPrefabInstantiator : IInjectingPrefabInstantiator
    {
        private readonly IObjectResolver resolver;

        public VContainerPrefabInstantiator(IObjectResolver resolver)
            => this.resolver = resolver;

        public GameObject Instantiate(GameObject prefab, Transform parent = null)
            => parent != null ? resolver.Instantiate(prefab, parent) : resolver.Instantiate(prefab);

        // VContainer has no equivalent of the data argument, so it's ignored.
        public GameObject Instantiate(GameObject prefab, Transform parent, object data)
            => Instantiate(prefab, parent);

        public T Instantiate<T>(GameObject prefab, Transform parent = null) where T : Component
            => Instantiate(prefab, parent).GetComponent<T>();

        public T Instantiate<T>(GameObject prefab, Transform parent, object data) where T : Component
            => Instantiate<T>(prefab, parent);
    }
}
