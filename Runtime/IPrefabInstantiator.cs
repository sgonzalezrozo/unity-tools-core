using UnityEngine;

namespace ToolsCore
{
    /// <summary>
    /// Abstraction for instantiating prefabs with optional dependency injection support.
    /// Allows plugins to work with any IoC container (FastIoC) or without IoC at all.
    /// </summary>
    public interface IPrefabInstantiator
    {
        /// <summary>
        /// Instantiate a prefab with optional dependency injection.
        /// </summary>
        /// <param name="prefab">The prefab to instantiate</param>
        /// <param name="parent">Parent transform (optional)</param>
        /// <returns>The instantiated GameObject</returns>
        GameObject Instantiate(GameObject prefab, Transform parent = null);

        /// <summary>
        /// Instantiate a prefab with optional dependency injection and data binding.
        /// </summary>
        /// <param name="prefab">The prefab to instantiate</param>
        /// <param name="parent">Parent transform (optional)</param>
        /// <param name="data">Data to inject into IInjectableForChildren components</param>
        /// <returns>The instantiated GameObject</returns>
        GameObject Instantiate(GameObject prefab, Transform parent, object data);

        /// <summary>
        /// Instantiate a prefab and get a typed component with optional dependency injection.
        /// </summary>
        /// <typeparam name="T">Component type to retrieve from instantiated prefab</typeparam>
        /// <param name="prefab">The prefab to instantiate</param>
        /// <param name="parent">Parent transform (optional)</param>
        /// <returns>The component of type T from the instantiated prefab</returns>
        T Instantiate<T>(GameObject prefab, Transform parent = null) where T : Component;

        /// <summary>
        /// Instantiate a prefab and get a typed component with optional dependency injection and data binding.
        /// </summary>
        /// <typeparam name="T">Component type to retrieve from instantiated prefab</typeparam>
        /// <param name="prefab">The prefab to instantiate</param>
        /// <param name="parent">Parent transform (optional)</param>
        /// <param name="data">Data to inject into IInjectableForChildren components</param>
        /// <returns>The component of type T from the instantiated prefab</returns>
        T Instantiate<T>(GameObject prefab, Transform parent, object data) where T : Component;
    }
}

