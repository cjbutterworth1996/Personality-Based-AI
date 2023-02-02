# COMP250 Proposal: Nightmare Labyrinth

## Introduction
This game is a procedurally generated maze which players have to navigate while avoiding enemies. Players will use a pulse monitor that allows the AI director to detect gameplay patterns that result in fluctuations in heartrate. Based on these findings, the AI will alter the generation of the maze and enemy spawning to attempt to increase the player's heartrate. My chosen specialism is artificial intelligence in games programming. This project is in alignment with that specialization because the AI director will use machine learning to optimize procedural generation. This artefact could be used in several different fields. An AI that can recognize emotional arousal states and then effectively respond to influence those states could optimize emotional responses in video games, strengthen lie detector equipment, and optimize anxiety-reduction software among other things.

## Project Scope

The artefact will use reinforcement learning to train an AI to consistently generate higher arousal responses. The artefact will consist of a procedurally generated maze and 3 types of AI controlled enemies. The player will be hooked up to a finger-strap style pulse monitor to let the AI determine the player's heartrate. 

## Software Architecture

Reinforcement learning trains AI by programming it to maximize a reward function. It is used to "automatically evaluate the optimal behavior in a particular context or environment to improve its efficiency," (Sarker 2021). This makes it an ideal candidate for this project, as it aims to optimize the AI's efficiency of heigtening  the player's heartrate. Unsupervised learning is another option as it allows the AI to freely associate data patterns without labels. It is used for "extracting generative features, identifying meaningful trends and structures, groupings in results, and exploratory purposes," (Sarker 2021). This would work well as the AI aims  to identify meaningful trends in increasing heartrate in players. Given the time limitations of this project, the artefact will only use reinforcement learning.

Using practice-based research, this artefact will determine if the AI is more effective at producing a higher arousal response in players than a similar, scripted experience. This research will determine output effectiveness primarily and objectively via heartrate fluctuations as well as secondarily and subjectively via player questionnaires. Additional testing methods such as an increased number of physiological inputs, simulations of different types of fear, and varying recognition pattern testing would all increase the relevancy and validity of the project's data, but fall outside the current scope due to time limitations.

## Scope Feasibility
Given that there are only 3 different options of enemies to choose from, the parameters that the AI must optimize are:

1. How long should it wait between enemy spawns
2. What kind of enemy should it spawn

This artefact will use PyTorch, which provides "scalable distributed training and performance optimization in research and production," and integrates directly into Unity (PyTorch). Additionally, I will be using a standardized library that uses PyTorch called Stable-Baselines3, which is "a set of reliable implementations of reinforcement learning algorithms in PyTorch," (Stable-Baselines3 2022). Using these two tools will allow me to produce an effective AI using reinforcement learning within the time scope of this project.

## Production Timeline

There are six weeks of production time pending the approval of this proposal. Using AGILE as a development life cycle model, the first week will consist of research and planning the software's architecture. Weeks two through four will be spent developing and testing the software using user feedback along the way to optimize the experience. Weeks five and six will consist of training the AI and polishing to assure the AI has enough training time to produce meaningful results. The AI will be completed as soon as possible with the game world and game elements following thereafter.

## Similar Projects

The game developers for *VANISH* (2013) ran a study using their game that attempted to determine if "biofeedback-enabled adaptive methods have a significant impact on any specific aspect of the players' gameplay experience," (Nogueira et al. 2016).  The study used heartrate, skin conductivity, and facial electromyography to alter game generation. Their study concluded that "biofeedback-augmented gameplay is suitable as both a dramatic enhancer and a regulator of the player experience," (Nogueira et al. 2016).

The biggest issue with this study is that they do not explain why they chose certain physiological inputs to affect specific aspects of gameplay. For example, there is no explanation given for why valence was attached to monster generations instead of arousal. All of their results use a combination of three disconnected physiological inputs. In this artefact, there will only be one physiological input which will provide a more definitive look at how heartrate can affect AI decision making in video games.  

# Bibliography

GAMEJOLT. 2014.'VANISH by 3DrunkMen'. Available at: https://gamejolt.com/games/vanish/29440 [accessed 2 February 2023].

NOGUEIRA, Pedro A., Torres VASCO, Rui RODRIGUES, Eugénio OLIVEIRA and Lennart E. NACKE. 2016. 'Vanishing scares: biofeedback modulation of affective player experiences in a procedural horror game'. *Journal on Multimodal User Interfaces*, 10, 31-62.

PYTORCH. 'Home page'. Available at: https://pytorch.org/ [accessed 2 February 2023].

SARKER, I.H. 2021. 'Machine Learning: Algorithms, Real-World Applications and Research Directions'. *SN Computer Science*, 2(160).

STABLE-BASELINES3. 'Stable-Baselines3 Docs - Reliable Reinforcement Learning Implementations'. Available at: https://stable-baselines3.readthedocs.io/en/master/ [accessed 2 February 2023].

*VANISH*. 2014. 3DrunkMen.
