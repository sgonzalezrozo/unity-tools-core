using UnityEngine;

namespace Tools.Core
{
    /// <summary>
    /// Generic hook for IoC-backed MonoBehaviour injection.
    /// Tool code should depend on this abstraction, not a concrete IoC framework.
    /// </summary>
    public interface IMonoBehaviourInjector
    {
        void InjectIfNeeded(MonoBehaviour component);
    }

    /// <summary>
    /// Default no-op injector used when no IoC integration is registered.
    /// </summary>
    public sealed class NullMonoBehaviourInjector : IMonoBehaviourInjector
    {
        public void InjectIfNeeded(MonoBehaviour component)
        {
        }
    }
}
