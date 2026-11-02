using UnityEngine;

namespace ToolsCore
{
    /// <summary>
    /// Default implementation of IPrefabInstantiator for projects without IoC.
    /// Uses standard Unity Object.Instantiate().
    /// </summary>
    public class NullPrefabInstantiator : IPrefabInstantiator
    {
        public GameObject Instantiate(GameObject prefab, Transform parent = null)
        {
            return Object.Instantiate(prefab, parent);
        }

        public GameObject Instantiate(GameObject prefab, Transform parent, object data)
        {
            return Object.Instantiate(prefab, parent);
        }

        public T Instantiate<T>(GameObject prefab, Transform parent = null) where T : Component
        {
            return Object.Instantiate(prefab, parent)?.GetComponent<T>();
        }

        public T Instantiate<T>(GameObject prefab, Transform parent, object data) where T : Component
        {
            return Object.Instantiate(prefab, parent)?.GetComponent<T>();
        }
    }
}

