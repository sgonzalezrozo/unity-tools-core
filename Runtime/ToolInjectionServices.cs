namespace Tools.Core
{
    /// <summary>
    /// Shared service registry for cross-tool runtime injection abstractions.
    /// FastIoC or other IoC integrations can register implementations at bootstrap.
    /// </summary>
    public static class ToolInjectionServices
    {
        private static IMonoBehaviourInjector monoBehaviourInjector = new NullMonoBehaviourInjector();

        public static IMonoBehaviourInjector MonoBehaviourInjector
        {
            get => monoBehaviourInjector;
            set => monoBehaviourInjector = value ?? new NullMonoBehaviourInjector();
        }
    }
}
