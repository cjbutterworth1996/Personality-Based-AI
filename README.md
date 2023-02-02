# COMP250 Proposal: Nightmare Labyrinth

## Introduction
Nightmare Labyrinth is a game with a procedurally generated maze which players have to navigate while avoiding enemies. Players will use a pulse monitor which will allow the AI director to detect when variable conditions and combinations result in an increased heartrate. Based on these findings, the AI will then alter the generation of the maze and enemy spawning to continuosly attempt to increase the player's heartrate. My chosen specialism is artificial intelligence in games programming. This project is in alignment with that specialization because the AI director will handle procedurally spawning a labyrinth and the enemies within using machine learning. This artefact could be used in several different fields. An AI that can recognize emotional arousal states and then effectively respond to influence said arousal states could have many different applications including optimizing emotional responses in video games, strengthening lie detector equipment, and optimizing anxiety-reduction software.

## Project Scope

The artefact will use a type of pattern recognition method called reinforcement learning in order to train an AI to successfully and consistently generate higher arousal responses. The artefact will consist of a procedurally generated maze and 3 types of AI controlled enemies: spiders, clowns, and demons. The player will be hooked up to a finger-strap style pulse monitor which will let the AI determine the player's current arousal state.

## Software Architecture

Reinforcement learning trains AI by programming it to maximize a reward function. It is used to "automatically evaluate the optimal behavior in a particular context or environment to improve its efficiency," (Sarker 2021). This makes it an ideal candidate for this project, as it aims to optimize the AI's efficiency of heigtening arousal in players. Unsupervised learning is a close runner-up candidate as it allows the AI to freely associate data patterns without labels. It is used for "extracting generative features, identifying meaningful trends and structures, groupings in results, and exploratory purposes," (Sarker 2021). This would work quite well as the AI will need to identify meaningful trends in inducing arousal in players to properly maximize arousal output. Given the time limitations of this project, the artefact will only use reinforcement learning.

Using practice-based research, this artefact will determine if the AI is more effective at producing a higher arousal response in players than a similar, scripted experience. This practice-based research will determine output effectiveness primarily and objectively via arousal scores (heartbeats per minute) as well as secondarily and subjectively via player questionnaires. Additional testing methods such as an increased number of physiological inputs, simulations of different types of fear, and varying recognition pattern testing would all increase the relevancy and validity of the project's data, but fall outside the current scope due to time limitations.

## Scope Feasibility
Given that there are only 3 different options of enemies to choose from, the parameters that the AI must optimize are:

1. How long should it wait between enemy spawns
2. What kind of enemy should it spawn
3. How many branching paths should it generate

Everything else such as sound effects, environmental scares and monster AI will be scripted and not editable by the AI controller.

As for coding complexity and the time it takes to learn how to code a complex machine learning algorithm such as reinforcement learning, this artefact will use PyTorch, which provides "scalable distributed training and performance optimization in research and production," and integrates directly into Unity (PyTorch). Additionally, I will be using a standardized library that uses PyTorch called Stable-Baselines3, which is "a set of reliable implementations of reinforcement learning algorithms in PyTorch," (Stable-Baselines3 2022). Using these two tools will allow me to produce an effective AI using reinforcement learning within the time scope of this project.

## Production Timeline

There are 6 weeks of production time pending the approval of this proposal. Using AGILE as a development life cycle model, the 1st week will consist of research and planning the software's architecture. Weeks 2, 3 and 4 will be spent developing and testing the software using user feedback along the way to optimize the experience. Weeks 5 and 6 will consist of training the AI and polishing to assure the AI has enough training time to produce meaningful results. The AI will be completed as soon as possible with the navigable game world and game elements following thereafter.

## Similar Projects

There are a number of horror games that utilize procedurally generated maps and enemy spawning. The most similar to this project's aim and scope is *VANISH* (2013). *VANISH* (2013) is "dynamically generated at run-time and continues to change while the player plays it. Each hall piece dynamically spawns with certain objects and events that dynamically spawn as well," (GameJolt 2014). The game developers for *VANISH* (2013) also ran a study using the game that attempted to determine if "biofeedback-enabled adaptive methods have a significant impact on any specific aspect of the players' gameplay experience," (Nogueira et al. 2016).  The study had two biofeedback-enabled inputs that adapted the player experience: arousal and valence. Arousal was determined through an increase/decrease in skin conductivity and heart rate, while valence was determined via facial EMG (electromyography) at the cheek and brow muscles. The development team then used this data to affect the gaming experience in various different ways. 

This artefact is much more limited in scope than the Vanish team's study, so only the relevant gaming experience alterations will be detailed here. In one of these alterations "the player's arousal level was inversely correlated with the probability of generating a creature encounter." Additionally, "valence was inversely correlated with the generation of rooms associated with goal completion," as well as inversely correlated with the "number of possible escape routes for use in subsequent creature encounter events." 

One of the biggest issues with this study is that they do not explain why they chose arousal or valence to affect specific aspects of gameplay. There seems to be no logical explanation for why valence was attached to monster generations instead of arousal or vice-versa. Additionally, they have three physiological inputs, but no control groups for determining the effect of using one physiological input or the other. All of their results use a combination of three seemingly disconnected inputs. In this artefact, there will only be one physiological input, which will provide a more definitive look at how heartrate can affect AI decision making in video games. 

This artefact will differ from the Vanish development team's study in a number of ways. First, they used 3 different physiological inputs, whereas this study will only use one: heartrate. Another difference will be in the overall aim of the study. The physiological inputs for arousal meant that "the player's arousal ratings mapped to increases in the avatar's adrenaline levels, which translated into higher running speeds. This was actually detrimental to the player, because "stealthy, paced exploration is the optimal game strategy," so as not to alert any nearby monsters. This resulted in players purposefully remaining calmer, therefore making the game easier. As a result, their study's conclusions reflect a decrease in arousal states from their control group. (insert image here).

Conversely, in this artefact, the AI will experiment and catalog different ways of scaring users, theoretically becoming more effective at eliciting more intense arousal responses over time.

# Bibliography

GAMEJOLT. 2014.'VANISH by 3DrunkMen'. Available at: https://gamejolt.com/games/vanish/29440 [accessed 2 February 2023].

NOGUEIRA, Pedro A., Torres VASCO, Rui RODRIGUES, Eugénio OLIVEIRA and Lennart E. NACKE. 2016. 'Vanishing scares: biofeedback modulation of affective player experiences in a procedural horror game'. *Journal on Multimodal User Interfaces*, 10, 31-62.

PYTORCH. 'Home page'. Available at: https://pytorch.org/ [accessed 2 February 2023].

SARKER, I.H. 2021. 'Machine Learning: Algorithms, Real-World Applications and Research Directions'. *SN Computer Science*, 2(160).

STABLE-BASELINES3. 'Stable-Baselines3 Docs - Reliable Reinforcement Learning Implementations'. Available at: https://stable-baselines3.readthedocs.io/en/master/ [accessed 2 February 2023].

*VANISH*. 2014. 3DrunkMen.
