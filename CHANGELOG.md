# Changelog

All notable changes to this package are documented in this file.

## [Unreleased]

## [0.4.3] - 2026-11-19

### Changed

- `package.json` lists the author's email, santiago.gonzalezrozo@outlook.com, next to the name and GitHub URL.

## [0.4.2] - 2026-11-18

### Documentation

- The README's description is plain text instead of a quote, and short enough for two lines.

## [0.4.1] - 2026-11-18

### Documentation

- The README is now a short overview with installation, a quickstart and links. Its content moved into guides in `Documentation~/`: Containers, API Reference, FAQ and Project Status.
- Installation instructions no longer pin a release tag.

## [0.4.0] - 2026-11-16

### Added

- `IInjectingPrefabInstantiator`: marks an instantiator that already injects what it creates, and `ToolInjectionServices.InstantiatorInjects` to check it. Tools that instantiate through such an instantiator don't inject the copy a second time.
- VContainer adapter (`ToolsCore.VContainer`, `builder.UseToolsCore()`) and Zenject adapter (`ToolsCore.Zenject`, `ToolsCoreInstaller` or `ZenjectToolsCore.Use(Container)`). Each compiles only when its container is in the project, and registers an injector and an injecting instantiator. Compiled against VContainer 1.19.0 and Extenject's `master`.

### Documentation

- The README's hand-written Zenject example, which registered an instantiator that injected without saying so, is replaced by the adapters and a section on not injecting twice.
- The package description, `llms.txt` and README tagline no longer name packages that aren't published yet.

## [0.3.1] - 2026-11-10

### Documentation

- An FAQ, `llms.txt` and more package keywords.
- Said that the package isn't used in production or in a shipped game yet, and described it as shared code required by Fast IoC, Screen System and Recyclable Scroller.
- Removed links to packages that aren't published yet. Screen System and Recyclable Scroller are named as unpublished.

## [0.3.0] - 2026-11-03

### Removed

- **Breaking:** Removed `IMaskSource`. It wasn't part of the injection API.

### Documentation

- Added a package diagram, a Zenject example and the versioning policy.
- Added contributing, security and issue template files.
- Added XML documentation to the remaining public APIs.

## [0.2.0] - Unreleased

### Changed

- **Breaking:** Renamed the namespace from `Tools.Core` to `ToolsCore`.
- **Breaking:** Renamed the assembly from `tools.Core` to `ToolsCore`.
- **Breaking:** Moved `IMaskSource` into the `ToolsCore` namespace.

## [0.1.0] - Unreleased

First pre-release for private testing.
