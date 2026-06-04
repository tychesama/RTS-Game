# RTS Game

RTS Game is an unfinished Unity project exploring the core controls and systems for a real-time strategy game prototype.

This repository is currently paused/in progress. It is being documented now so the project can be picked up again later without losing the original intent or the current implementation state.

## Current idea

The goal is to build a small RTS-style prototype where the player can control units, move the camera around a 3D map, select one or more units, issue movement commands, and eventually fight enemies.

The project currently focuses on the foundation rather than a complete game loop.

## Current status

Status: unfinished / paused

What already exists:

- Unity project setup
- Sample scene
- Basic terrain asset
- Unit prefab/resources
- Unit selection system
- Drag selection box
- Multi-select support with Shift
- Right-click ground movement commands
- NavMeshAgent-based unit movement
- RTS-style camera controller
- Keyboard camera movement
- Edge-scrolling support with custom cursor arrows
- Middle-mouse camera dragging support
- Basic enemy/attack targeting scripts
- Attack/follow/idle material state hooks
- Health tracker and unit UI prefab files
- Unity Input System package setup

What still likely needs work:

- Complete combat and damage logic
- Finish `Unit.TakeDamage` behavior
- Refine enemy AI and patrol behavior
- Add production/building/resource mechanics if this becomes a fuller RTS
- Improve unit command feedback and UI
- Add health bars and combat VFX/SFX polish
- Add win/loss conditions or a playable objective
- Balance camera speed, selection behavior, and unit movement
- Test NavMesh baking/setup inside Unity
- Clean up duplicate or root-level scripts if they are no longer needed
- Add screenshots or gameplay clips once the prototype is running again

## Tech stack

- Unity 6
- C#
- Unity Input System
- Unity AI Navigation / NavMesh
- Unity UI / UGUI
- TextMesh Pro

Unity editor version recorded in the project:

```text
6000.3.2f1
```

## Project structure

```text
Assets/
  Scripts/
    AttackController.cs
    RTSCameraController.cs
    SimplePatrol.cs
    Unit.cs
    UnitMovement.cs
    UnitSelectionBox.cs
    UnitSelectionManager.cs
  Resources/
    Unit.prefab
  Scenes/
    SampleScene.unity
  Terrain/
    New Terrain.asset
  UI/
    cursor.png
    Scroll_UP.png
    Scroll_DOWN.png
    Scroll_LEFT.png
    Scroll_RIGHT.png
  Animation/
    UnitController.controller
Packages/
  manifest.json
ProjectSettings/
  ProjectVersion.txt
```

## Controls currently implied by the scripts

| Action | Control |
| --- | --- |
| Select unit | Left click |
| Multi-select/toggle unit | Shift + left click |
| Drag select | Hold/drag left mouse button |
| Move selected unit(s) | Right click ground |
| Attack target | Right click enemy while an offensive unit is selected |
| Camera movement | WASD or arrow keys, if enabled in the camera component |
| Faster camera movement | Left Ctrl, if keyboard movement is enabled |
| Camera drag | Middle mouse drag, if enabled in the camera component |
| Edge scroll | Move cursor near screen edge, if enabled in the camera component |
| Stop following target | Escape |

Some of these features depend on inspector toggles, scene references, layers, prefabs, and cursor textures being assigned correctly in Unity.

## How to open later

1. Install Unity Hub.
2. Install Unity `6000.3.2f1` or the closest compatible Unity 6 editor.
3. Clone this repository.
4. In Unity Hub, choose **Add project from disk** and select this folder.
5. Open `Assets/Scenes/SampleScene.unity`.
6. Let Unity restore packages from `Packages/manifest.json`.
7. Check scene references, layers, NavMesh setup, and serialized fields before entering Play Mode.

## Development notes

Important systems to inspect first when resuming:

- `UnitSelectionManager.cs` handles selecting units, deselecting them, toggling multi-select, showing the ground marker, and assigning attack targets.
- `UnitSelectionBox.cs` handles drag-selection using a screen-space selection rectangle.
- `UnitMovement.cs` sends selected units to right-clicked ground positions using `NavMeshAgent`.
- `RTSCameraController.cs` contains RTS camera movement, optional keyboard movement, edge scrolling, middle-mouse dragging, custom cursor arrows, and follow-target behavior.
- `AttackController.cs` currently stores attack target/material state hooks and draws debug gizmos for range visualization.
- `Unit.cs` registers units with the selection manager, but damage behavior is still unfinished.

## Suggested next steps

A practical restart plan:

1. Open the scene in Unity and verify there are no missing script references.
2. Confirm the project layers used by `clickable`, `ground`, and `attackable` are set correctly.
3. Re-bake or verify the NavMesh for the terrain.
4. Enter Play Mode and test selecting, drag-selecting, and moving units.
5. Finish health/damage behavior in `Unit.cs` and `HealthTracker.cs`.
6. Connect attack logic to actual damage over time or attack cooldowns.
7. Add simple objective text, enemy spawns, and a basic win/loss condition.
8. Capture screenshots or a short demo GIF for this README.

## Repository note

This is not a finished released game yet. It is a prototype/foundation repo intended to preserve the work so development can continue later.
