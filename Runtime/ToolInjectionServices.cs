namespace ToolsCore
{
    /// <summary>
    /// Shared service registry for cross-tool runtime injection abstractions.
    /// FastIoC or other IoC integrations can register implementations at bootstrap.
    /// </summary>
    public static class ToolInjectionServices
    {
        private static IMonoBehaviourInjector monoBehaviourInjector = new NullMonoBehaviourInjector();

        /// <summary>The current injector. Assigning null restores the default, which does nothing.</summary>
        public static IMonoBehaviourInjector MonoBehaviourInjector
        {
            get => monoBehaviourInjector;
            set => monoBehaviourInjector = value ?? new NullMonoBehaviourInjector();
        }

        private static IPrefabInstantiator prefabInstantiator = new NullPrefabInstantiator();

        /// <summary>The current prefab instantiator. Assigning null restores the default, which uses Object.Instantiate.</summary>
        public static IPrefabInstantiator PrefabInstantiator
        {
            get => prefabInstantiator;
            set => prefabInstantiator = value ?? new NullPrefabInstantiator();
        }

        /// <summary>
        /// True when the registered instantiator injects what it creates (<see cref="IInjectingPrefabInstantiator"/>).
        /// Tools that instantiate through it must not inject the copy again.
        /// </summary>
        public static bool InstantiatorInjects
            => prefabInstantiator is IInjectingPrefabInstantiator;
    }
}
