# X-Flow Test Project

This repository contains a test project developed for **X-Flow Studio**.

All required features have been implemented according to the provided specifications.

## 🏗 Architecture Overview

The Shop feature is built using the Model–View–Presenter (MVP) pattern with elements inspired by Clean Architecture.

For simplicity (as allowed by the task requirements):

- Data services and several supporting components are implemented as singletons.
- Shop configuration is done via ScriptableObject assets.
- UI was implemented without advanced canvas optimizations.
- PlayerData is implemented as a singleton with generic constraints to avoid unnecessary boxing of struct types.

### ✨ Simplifications / Intentional Omissions

To keep the project concise, several non-essential production features were intentionally left out:

- No event unsubscriptions for most cases
- No logging system
- No advanced error handling
- No dependency injection framework
- Only a small set of sample unit tests
- No separate “Model” layer for presenters
- Interfaces are defined only for Shop views
- Bundle details scene uses a lightweight setup
- Shop card state refreshes in Update() for simplicity

## Project Structure

All game-specific files are located in the `_Project` folder.

### 🔧 Configuration Assets

All configuration data is placed under the `_Project/ScriptableObjects` folder.

### ActionSo

Use Create → Action to create a new `ActionSo` asset.
It represents an operation that adds or removes resources.
To subtract a resource, simply provide a negative value.

### BundleSo

Allows combining multiple `ActionSo` assets into a single bundle.

### ShopConfigSo

Defines the overall Shop configuration.

Here you can:
- Assign bundles
- Add debug actions
- Configure initial resource states

### 🛠 Shop Initialization

`ShopService` is the entry point for initializing the Shop.
Assign your `ShopConfigSo` to it.
It also functions as a lightweight service locator for Shop-related systems.

### 🎮 Scenes

`DetailCardScene` is intended to be loaded additively, not as a starting scene.
If the game is launched directly from this scene, an error message will be displayed to indicate misconfiguration.

## 🎯 Final Notes
The general approach was to focus on core functionality while keeping the codebase manageable and easy to understand.

Developed by [@Arikaton](https://github.com/arikaton) for X-Flow Studio. 

_Readme was generated with the help of AI._