# HeadRush

A single-player FPS, with a single arena, single weapon, and single enemy type. HP can be regained from perfect headshots.

---

## Current Status

- **Core Systems (Complete)**
    - **Movement:** Responsive WASD movement and smooth mouse look using CharacterController.
    - **Shooting:** Raycast-based weapon system with LayerMask filtering (ignores player body so the gunshots reach the enemy).
    - **Enemy AI:** NavMesh-driven cube enemies (with spherical heads) that chase the player and deal contact damage.
    - **Game Loop:** Victory/Death states with restart functionality.
- **Combat Mechanics**
    - **Headshot:** Head collider detection that deals 2x damage and heals the player.
    - **Feedback:**
        - **Visual:** Muzzle flashes, camera recoil, and enemy hit-flashing (red).
        - **Audio:** Triggered weapon sound effects.
        - **UI:** Central crosshair and OnGUI end-screens.
- The project is currently a fully playable (minimal) vertical slice.
- Currently working on creating assets & refining the in-game world.

---

## Asset Sources

- **Gun Audio:** [Mixkit](https://mixkit.co/free-sound-effects/gun)

---

## Author

Saptaparno Chakraborty

---