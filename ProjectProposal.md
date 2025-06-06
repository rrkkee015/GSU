# Gun Shot University (GSU) - Game Design Document

## 1. Game Overview

- **Title**: Gun Shot University (GSU)
- **Genre**: Action, Roguelike
- **Platform**: PC (Steam), with potential expansion to mobile/console
- **Target Users/Age Group**: Ages 15 and up, users who enjoy action and roguelike games

---

## 2. Core Concept

- **Reverse Growth**: The player controls a character who becomes weaker as the game progresses. (Starts with all abilities/skills/items → gradually loses them one by one over time)
- **Final Boss is Your Past Self**: The final boss is "your strongest self" from the beginning of the game. The player must defeat their powerful past self in a weakened state.
- **Self-Overcoming/Reflection**: Instead of simple power-ups, the game requires creative and strategic play as resources and abilities decrease.

---

## 3. Theme/Atmosphere

- **Paradox of Strength**: The message is, "True strength is revealed not when you have everything, but when you have lost everything."
- **Intense and Stylish Action**: Fast-paced, flashy combat and impactful visual effects

---

## 4. Example Gameplay Flow

1. **Game Start**: Begin with all skills, items, health, and stats at max level
2. **Stage Progression**: As you clear stages, you lose one ability/skill/item at a time
3. **Final Boss**: In your weakest state, you fight "yourself at the beginning" (the strongest version of yourself as the final boss)
4. **Ending**: Overcoming your past, stronger self in a weakened state symbolizes true growth and independence

---

## 5. Key Systems (Draft)

- **Real-Time Action Combat**: Battles utilizing various skills and items
- **Roguelike Structure**: Randomized maps and events each run
- **Ability/Skill Removal System**: Lose stats, skills, and items one by one as stages progress
- **Final Boss System**: The player's initial state (the strongest self) appears as the final boss
- **Strategic Choices**: Players must decide which abilities to give up first and how to overcome challenges with what remains

## 5-1. Protagonist's Basic Movement

The protagonist moves using directional keys by default. Pressing the spacebar allows the protagonist to dash.

- **Dash**: The protagonist quickly moves a short distance in the current movement direction, leaving behind an afterimage effect.

## 5-2. Protagonist's Elemental Abilities

The protagonist can wield various elemental powers, each with unique attack patterns and status effects.

- **Fire**: Deals powerful damage in a narrow cone in front of the player and inflicts Burn on enemies.
  - _Burn_: Deals damage over 4 seconds equal to 5% of the enemy's max HP
- **Ice**: Creates four spiraling ice storms centered on the player, dealing low damage and inflicting Freeze on enemies.
  - _Freeze_: Reduces enemy movement speed by 60% for 4 seconds
- **Earth**: Deals moderate damage in a wide circular area around the player, knocks enemies back, and grants the player Shell.
  - _Shell_: Grants a shield that blocks enemy attacks for 4 seconds
- **Lightning**: Deals moderate damage in a small area, strikes lightning at the enemy's position, and inflicts Shock.
  - _Shock_: Increases damage the enemy takes by 1.5x
- **Light**: Deals damage in a wide straight line, with damage ranging from very low to very high depending on charge time

**Elemental Ability Leveling System**

- Each elemental ability can be leveled up.
- However, every time the player levels up an elemental ability, they must lose or weaken another elemental ability.
- When one elemental ability reaches its maximum level, the protagonist can only use that element and becomes a character who has awakened mastery over that element.

**Aging & Ability Loss System**

- As the player repels enemies, their age gradually increases.
- At certain age milestones, the player loses a random ability.

Each elemental ability can be used strategically depending on the situation, and the player will lose these abilities one by one as the stages progress.

## 5-3. Enemy Concepts

1. Enemies continuously pursue the player.
2. Each time the player levels up, new types of enemies are introduced.
3. Types of enemies:
   - **3-1. Minions**: Basic enemies that appear in large numbers.
   - **3-2. Molotov Thrower**: Throws firebombs at the player from a distance.
   - **3-3. Fast Chaser**: Approaches the player much faster than other enemies.
   - **3-4. Mine Layer**: Lays mines on the field that explode when the player gets close.
   - **3-5. Splitter**: When killed, splits into two enemies, up to three times (max 8 total from one).
   - **3-6. Mid-bosses**: Stronger enemies with unique attack patterns or abilities.
   - **3-7. Boss (Phase 1)**: A boss character that possesses all the abilities the player had at the start. When its HP drops to 1%, it fully restores HP and enters phase 2.
   - **3-8. Boss (Phase 2)**: The boss has mastered a single random element, representing an awakened character with ultimate proficiency in that element. The game screen dramatically shifts to black and white during this phase.

## 5-4. Map Design

- The map is an infinitely large open field, allowing for free movement and large-scale enemy encounters.

---

## 6. Art/Sound Direction (Draft)

- **Graphic Style**: 3D or 2.5D, with stylish and intense action effects
- **Music/Sound Atmosphere**: Energetic and immersive BGM, impactful sound effects

---

## 7. References

- Hades (Roguelike structure)
- Dead Cells (Action/Growth)
- Katana ZERO (Stylish action)
- Skul: The Hero Slayer (Action/Growth)

---

## 8. Other/Notes

- Story, detailed systems, characters, and map design will be further developed
- Additional ideas and feedback are welcome
