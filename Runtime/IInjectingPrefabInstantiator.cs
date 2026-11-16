namespace ToolsCore
{
    /// <summary>
    /// An <see cref="IPrefabInstantiator"/> whose Instantiate methods already inject the new copy, such as one built
    /// on a container's InstantiatePrefab. Tools check <see cref="ToolInjectionServices.InstantiatorInjects"/> and
    /// don't inject the copy a second time.
    /// </summary>
    public interface IInjectingPrefabInstantiator : IPrefabInstantiator
    {
    }
}
