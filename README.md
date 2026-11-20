<div align="center">

# Unity Tools Core

<sub>DESIGNED & BUILT BY</sub><br>
**✦ [`SANTIAGO GONZÁLEZ ROZO (@sgonzalezrozo)`](https://github.com/sgonzalezrozo) ✦**

Shared dependency injection interfaces for Unity packages. Lets Screen System and UI Scroller work with Fast IoC, VContainer, Zenject or no container at all, without depending on any of them.

[![Unity](https://img.shields.io/badge/Unity-6000.3%20tested-black?style=for-the-badge&logo=unity)](Documentation~/api-reference.md#requirements)
[![Version](https://img.shields.io/badge/version-0.4.3-blue?style=for-the-badge)](CHANGELOG.md)
[![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](LICENSE)

[**Installation**](#installation) • [**Key Features**](#key-features) • [**Quickstart**](#quickstart) • [**Containers**](Documentation~/containers.md) • [**API Reference**](Documentation~/api-reference.md) • [**FAQ**](Documentation~/faq.md)

<sub>[Project Status](Documentation~/project-status.md)</sub>

</div>

---

## Installation

You need Tools Core if you use [Fast IoC](https://github.com/sgonzalezrozo/unity-fast-ioc), [Screen System](https://github.com/sgonzalezrozo/unity-screen-system) or [UI Scroller](https://github.com/sgonzalezrozo/unity-ui-scroller). Unity doesn't install Git dependencies automatically, so add it before them, and let Unity finish importing and compiling it before you add the next package. Adding a package while Unity is still importing another can log `ScriptableSingleton already exists` and `assets located in immutable packages were unexpectedly altered`: nothing is broken, so clear the Console and continue.

1. Open **Window > Package Manager** in Unity.
2. Click **`+`** in the top-left corner and select **Add package from git URL...**
3. Paste the URL below and click **Add**:

```text
https://github.com/sgonzalezrozo/unity-tools-core.git
```

---

## Key Features

* **[No container lock-in](Documentation~/api-reference.md#how-the-packages-connect)**: packages ask Tools Core for injection, never a specific container.
  Screen System and UI Scroller don't depend on Fast IoC, so you can swap in another container or use none.
* **[Works without a container](Documentation~/containers.md#no-container)**: the defaults use `Object.Instantiate` and inject nothing.
* **[VContainer and Zenject adapters](Documentation~/containers.md#use-vcontainer)**: one line to connect either.
  They compile only when that container is in the project.
* **[No double injection](Documentation~/containers.md#dont-inject-twice)**: an instantiator marked `IInjectingPrefabInstantiator` tells tools to skip their own pass.
* **[Tiny and dependency-free](Documentation~/api-reference.md)**: a handful of interfaces and no reflection.

---

## Quickstart

Pick the line for your container:

```csharp
// Fast IoC: nothing to do, it registers itself.

// VContainer: in your root LifetimeScope.Configure
builder.UseToolsCore();

// Zenject (Extenject): in a ProjectContext installer
ZenjectToolsCore.Use(Container);

// Any other container: before the first scene loads
ToolInjectionServices.MonoBehaviourInjector = new MyContainerInjector();
```

<details>
<summary><strong>View full sample script</strong></summary>

```csharp
using ToolsCore;
using UnityEngine;

// Connect a container that has no adapter.
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

</details>

Every option, including prefab instantiation, is in [Containers](Documentation~/containers.md).
