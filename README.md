# COMP250 Proposal: Nightmare Labyrinth

## Introduction
Nightmare Labyrinth is a procedurally generated labyrinth which players have to navigate while avoiding enemies and traps along the way. This project would focus on using a heartbeat sensor to detect when variable conditions and combinations result in an increased heartrate. Based on these findings, the AI controller could then alter the generation of the maze and enemy spawning to continuosly scare the player. My chosen specialism is artificial intelligence in games programming. This project is in alignment with that specialization because the AI will be in control of procedurally spawning a labyrinth and the enemies within. This artefact is needed to prove that AI-controlled horror games can procedurally generate terror.

## Project Scope

This project will use two different types of pattern recognition methods in combination with a singular application approach to generating arousal responses. The demo itself will consist of a procedurally generated maze and 3 types of AI controlled enemies: spiders, clowns, and demons. The player will be hooked up to a finger-strap style pulse monitor which will let the AI determine the player's current arousal/fear state.

The first pattern recognition method will be reinforcement learning. Reinforcement learning teaches AI by programming it to maximize a reward function. The second pattern recognition method will be supervised learning, which teaches AI by giving it a default target outcome. These two pattern recognition algorithms then iteratively test inputs to determine the best way to achieve their respective objectives.

Using practice-based research, this artefact will determine which recognition pattern is more effective at producing a higher arousal response in players.

## Similar Projects

There are a number of horror games that utilize procedurally generated maps and enemy spawning. The most similar to this project's aim and scope is Vanish. According to the game's listing on gamejolt.com, Vanish is "dynamically generated at run-time and continues to change while the player plays it. Each hall piece dynamically spawns with certain objects and events that dynamically spawn as well, which creates an ever changing game that no two players will ever experience exactly the same." In an article published in 2015, the game developers for Vanish ran a study for the game that attempted to determine if "biofeedback-enabled adaptive methods have a significant impact on any specific aspect of the players' gameplay experience." The study had two biofeedback-enabled inputs that adapted the player experience: arousal and valence. Arousal was determined through an increase/decrease in skin conductivity and heart rate, while valence was determined via facial EMG (electromyography) at the cheek and brow muscles. The development team then used this data to affect the gaming experience in various different ways. 

This artefact is much more limited in scope than the Vanish team's study, so only the relevant gaming experience alterations will be detailed here. In one of these alterations "the player's arousal level was inversely correlated with the probability of generating a creature encounter." Additionally, "valence was inversely correlated with the generation of rooms associated with goal completion," as well as inversely correlated with the "number of possible escape routes for use in subsequent creature encounter events." 

One of the biggest issues with this study is that they do not explain why they chose arousal or valence to affect specific aspects of gameplay. There seems to be no logical explanation for why valence was attached to monster generations instead of arousal or vice-versa. Additionally, they have three physiological inputs, but no control groups for determining the effect of using one physiological input or the other. All of their results use a combination of three seemingly disconnected inputs. In this artefact, there will only be one physiological input, which will provide a more definitive look at how heartrate can affect AI decision making in video games. 

This artefact will differ from the Vanish development team's study in a number of ways. First, they used 3 different physiological inputs, whereas this study will only use one: heartrate. Another difference will be in the overall aim of the study. The physiological inputs for arousal meant that "the player's arousal ratings mapped to increases in the avatar's adrenaline levels, which translated into higher running speeds. This was actually detrimental to the player, because "stealthy, paced exploration is the optimal game strategy," so as not to alert any nearby monsters. This resulted in players purposefully remaining calmer, therefore making the game easier. As a result, their study's conclusions reflect a decrease in arousal states from their control group. (insert image here).

Conversely, in this artefact, the AI will experiment and catalog different ways of scaring users, theoretically becoming more effective at eliciting more intense arousal responses over time.

## Software Architecture and Design

