# FAQ

[← Back to README](../README.md)

- [Do I need Tools Core?](#do-i-need-tools-core)
- [Can I use Screen System or UI Scroller with Zenject or VContainer?](#can-i-use-screen-system-or-ui-scroller-with-zenject-or-vcontainer)
- [What happens without a container?](#what-happens-without-a-container)
- [Why is it a separate package?](#why-is-it-a-separate-package)
- [Is it production-ready? Does anyone use it?](#is-it-production-ready-does-anyone-use-it)
- [Is it free for commercial use?](#is-it-free-for-commercial-use)

---

### Do I need Tools Core?

Yes, if you use Fast IoC, Screen System or UI Scroller. Install it first, because Unity doesn't install Git dependencies automatically. UI Tweens and UI Foundations don't need it.

### Can I use Screen System or UI Scroller with Zenject or VContainer?

Yes. Call `builder.UseToolsCore()` in a VContainer `LifetimeScope`, or add `ToolsCoreInstaller` to Zenject's `ProjectContext`. See [Use VContainer](containers.md#use-vcontainer) and [Use Zenject](containers.md#use-zenject-extenject). For another container, implement `IMonoBehaviourInjector` and `IPrefabInstantiator` yourself; see [Use your own container](containers.md#use-your-own-container).

### What happens without a container?

The defaults use `Object.Instantiate` and inject nothing.

### Why is it a separate package?

Tools Core is shared code, not a standalone tool. It lets Screen System and UI Scroller work with dependency injection without depending on one container: they use the interfaces here, and Fast IoC implements them.

Like the packages that use it, it comes from tools I built on my own time in personal projects. I extracted it into this standalone package in November 2026. Earlier history lives in a private repository.

### Is it production-ready? Does anyone use it?

Not yet. Tools Core is a pre-release package (`0.x`) by a single author. It isn't used in a shipped game, and it has no other users yet, so expect rough edges and API changes before `1.0.0`. Bug reports are very welcome. See [Project Status](project-status.md).

### Is it free for commercial use?

Yes. It's MIT licensed.
