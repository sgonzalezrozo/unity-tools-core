# Tools Core

**Shared injection interfaces for Screen System, Recyclable Scroller and Fast IoC.**

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

Tools Core lets these packages work with dependency injection without depending on one container. Screen System and Recyclable Scroller use the interfaces here, and Fast IoC implements them. Without a container, the defaults fall back to standard Unity instantiation.

## Do I need to install this myself?

Yes, if you use Fast IoC, Screen System or Recyclable Scroller. Install Tools Core first, because Unity doesn't install Git dependencies automatically. UI Tweens and Enhanced Console don't need it.

## What's included

| Type | Purpose |
|---|---|
| `IMonoBehaviourInjector` | Injects dependencies into a MonoBehaviour |
| `NullMonoBehaviourInjector` | Does nothing. It's the default when no container is registered. |
| `IPrefabInstantiator` | Instantiates a prefab, optionally with injection and data |
| `NullPrefabInstantiator` | Uses `Object.Instantiate`. It ignores any data passed to it. |
| `IInstantiable` | Marks a component for container-aware instantiation |
| `ToolInjectionServices` | Holds the current `IMonoBehaviourInjector` |
| `IMaskSource` | Provides mask shape data to UI components |

## Compatibility

| Requirement | Supported |
|---|---|
| Unity | 2022.3 or newer. **TODO:** add tested versions. |
| Scripting backend | **TODO:** confirm Mono and IL2CPP |
| Platforms | **TODO:** list tested platforms |
| Dependencies | None |

## Installation

Git must be installed on your machine.

1. In Unity, open **Window > Package Manager**.
2. Select **+ > Add package from git URL**.
3. Enter:

```text
https://github.com/sgonzalezrozo/unity-tools-core.git
```

To pin a release, add its tag:

```text
https://github.com/sgonzalezrozo/unity-tools-core.git#v0.1.0
```

## Use your own container

Fast IoC registers itself automatically. To use another container, implement `IMonoBehaviourInjector` and register it before the first scene loads:

```csharp
using Tools.Core;
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

## Limitations

- `ToolInjectionServices` only holds the MonoBehaviour injector. There's no public way yet to register a custom `IPrefabInstantiator`, so other containers can't fully replace Fast IoC.

## Project status

This is a pre-release package at version `0.1.0`. Its API and behavior may change before `1.0.0`.

> **TODO:** Add a roadmap link and breaking-change policy.

## Contributing

Bug reports and pull requests are welcome. Please open an issue before starting a large change.

## Related packages

| Package | Purpose |
|---|---|
| [Fast IoC](https://github.com/sgonzalezrozo/unity-fast-ioc) | Code-generated dependency injection |
| [Screen System](https://github.com/sgonzalezrozo/unity-screen-system) | Declarative UI navigation |
| [UI Tweens](https://github.com/sgonzalezrozo/unity-ui-tweens) | ECS-based UI animation |
| [Recyclable Scroller](https://github.com/sgonzalezrozo/unity-recyclable-scroller) | Virtualized lists |
| [Enhanced Console](https://github.com/sgonzalezrozo/unity-enhanced-console) | Unity Editor log triage |

## License

Released under the [MIT License](LICENSE).
