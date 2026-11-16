using UnityEngine;
using Zenject;

namespace ToolsCore.ZenjectAdapter
{
    /// <summary>
    /// Connects Zenject (Extenject) to the packages that use Tools Core. Add <see cref="ToolsCoreInstaller"/> to your
    /// ProjectContext, or call <see cref="Use"/> from your own installer:
    /// <code>
    /// public override void InstallBindings() => ZenjectToolsCore.Use(Container);
    /// </code>
    /// Use the project container: it can't see a SceneContext's bindings, and it lives for the whole session.
    /// </summary>
    public static class ZenjectToolsCore
    {
        /// <summary>Makes <paramref name="container"/> the injector and instantiator for Tools Core.</summary>
        public static void Use(DiContainer container)
        {
            ToolInjectionServices.MonoBehaviourInjector = new ZenjectMonoBehaviourInjector(container);
            ToolInjectionServices.PrefabInstantiator = new ZenjectPrefabInstantiator(container);
        }
    }

    /// <summary>Registers Zenject with Tools Core. Add it to the ProjectContext's installers.</summary>
    public sealed class ToolsCoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
            => ZenjectToolsCore.Use(Container);
    }

    /// <summary>Injects a component with a Zenject container.</summary>
    public sealed class ZenjectMonoBehaviourInjector : IMonoBehaviourInjector
    {
        private readonly DiContainer container;

        public ZenjectMonoBehaviourInjector(DiContainer container)
            => this.container = container;

        public void InjectIfNeeded(MonoBehaviour component)
        {
            if (component != null)
                container.Inject(component);
        }
    }

    /// <summary>Instantiates with Zenject, which injects the copy, so tools don't inject it again.</summary>
    public sealed class ZenjectPrefabInstantiator : IInjectingPrefabInstantiator
    {
        private readonly DiContainer container;

        public ZenjectPrefabInstantiator(DiContainer container)
            => this.container = container;

        public GameObject Instantiate(GameObject prefab, Transform parent = null)
            => container.InstantiatePrefab(prefab, parent);

        // Zenject has no equivalent of the data argument, so it's ignored.
        public GameObject Instantiate(GameObject prefab, Transform parent, object data)
            => container.InstantiatePrefab(prefab, parent);

        public T Instantiate<T>(GameObject prefab, Transform parent = null) where T : Component
            => container.InstantiatePrefabForComponent<T>(prefab, parent);

        public T Instantiate<T>(GameObject prefab, Transform parent, object data) where T : Component
            => container.InstantiatePrefabForComponent<T>(prefab, parent);
    }
}
