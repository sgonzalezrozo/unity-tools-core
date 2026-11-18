# Containers

[← Back to README](../README.md)

- [No container](#no-container)
- [Fast IoC](#fast-ioc)
- [Use VContainer](#use-vcontainer)
- [Use Zenject (Extenject)](#use-zenject-extenject)
- [Use your own container](#use-your-own-container)
- [Don't inject twice](#dont-inject-twice)

---

## No container

The defaults use `Object.Instantiate` and inject nothing. `NullMonoBehaviourInjector` and `NullPrefabInstantiator` are registered until something replaces them.

## Fast IoC

[Fast IoC](https://github.com/sgonzalezrozo/unity-fast-ioc) registers itself automatically. There's nothing to set up.

## Use VContainer

With [VContainer](https://github.com/hadashiA/VContainer) in the project, the `ToolsCore.VContainer` assembly compiles by itself. Register it in your root `LifetimeScope`:

```csharp
using ToolsCore.VContainerAdapter;
using VContainer;
using VContainer.Unity;

public class RootLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.UseToolsCore();
    }
}
```

It sets an injector (`IObjectResolver.Inject`) and an instantiator (`IObjectResolver.Instantiate`, marked as injecting). Use the project-wide scope: a scope that's destroyed takes its resolver with it.

## Use Zenject (Extenject)

With [Extenject](https://github.com/Mathijs-Bakker/Extenject) installed as a package (`com.svermeulen.extenject`), the `ToolsCore.Zenject` assembly compiles by itself. If you imported it from the Asset Store instead, add `TOOLSCORE_ZENJECT` to **Scripting Define Symbols**.

Add `ToolsCoreInstaller` to your `ProjectContext`'s installers, or call it from your own:

```csharp
using ToolsCore.ZenjectAdapter;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        ZenjectToolsCore.Use(Container);
    }
}
```

It sets an injector (`DiContainer.Inject`) and an instantiator (`DiContainer.InstantiatePrefab`, marked as injecting). Use the project container: it lives for the whole session, and it can't see a `SceneContext`'s bindings.

Both adapters are compiled against VContainer 1.19.0 and Extenject's current `master`. They haven't been run in a shipped game yet.

## Use your own container

Implement `IMonoBehaviourInjector` and register it before the first scene loads:

```csharp
using ToolsCore;
using UnityEngine;

public sealed class MyContainerInjector : IMonoBehaviourInjector
{
    public void InjectIfNeeded(MonoBehaviour component)
    {
        // Call your container's injection method here.
    }
}

public static class MyContainerBootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Register()
    {
        ToolInjectionServices.MonoBehaviourInjector = new MyContainerInjector();
    }
}
```

Passing `null` restores the default injector.

To control prefab instantiation too, implement `IPrefabInstantiator` and assign it to `ToolInjectionServices.PrefabInstantiator`.

## Don't inject twice

An instantiator built on a container's `InstantiatePrefab` already injects the copy. Mark it with `IInjectingPrefabInstantiator`, and tools that instantiate through it (Screen System) skip their own injection pass:

```csharp
public sealed class MyContainerInstantiator : IInjectingPrefabInstantiator
{
    // Instantiate methods that create and inject the copy.
}
```

Tools check `ToolInjectionServices.InstantiatorInjects`. An instantiator without the marker creates the copy, and the tool injects it with `MonoBehaviourInjector`.
